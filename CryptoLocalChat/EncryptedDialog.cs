using System;
using System.Security.Cryptography;
using System.Text;

using SimpleIP;

namespace CryptoLocalChat
{

	delegate void DialogMessageReceived(object sender, string message);
	delegate void DialogStateChanged(object sender, EncryptedDialog.DialogState newState);

	class EncryptedDialog{

		#region Enums
		public enum DialogState { Disconnected, Connecting, Connected, EncryptedIn, KeysAccepting, EncryptedOut, EncryptedAll};
		private DialogState _state;
		private DialogState State{
			get{return _state;}
			set{ _state = value; if (OnStatusChanged != null) OnStatusChanged(this, _state); }
		}
		#endregion

		#region Constants
		public const int DEFAULT_RSA_KEY_LENGTH_BITS = 4096;
		private const short MESSAGE_TYPE_BYTE_NUMBER = 0;
		private const short MESSAGE_TYPE_LENGTH = 1;
		private const short MODULUS_LENGTH_LENGTH = 4;
		private const byte MT_TEXT = 0x0;
		private const byte MT_KEYS = 0x1;
		#endregion

		#region Events
		public event DialogStateChanged OnStatusChanged;
		public event DialogMessageReceived OnMessageReceived;
		#endregion

		#region Parameters
			#region private
			private int _rsaDecKeyLength_;
			private int _rsaDecKeyLengthBytes;
			private int _rsaDecKeyLength{ set{_rsaDecKeyLength_ = value; _rsaDecKeyLengthBytes = _rsaDecKeyLength_/8;} get{return _rsaDecKeyLength_;} }
			private int _rsaEncKeyLength;
			#endregion
		#endregion

		#region Serving Objects
		Encoding _coder = Encoding.Unicode;

		RSACryptoServiceProvider _decryptor = new RSACryptoServiceProvider();
		RSACryptoServiceProvider _encryptor = new RSACryptoServiceProvider();

		private TCPConnection _connection; // THE WRAPPER OF WRAPPERS. >_<
		#endregion

		#region Structing
		public EncryptedDialog(){
			State = DialogState.Disconnected;
			_rsaDecKeyLength = DEFAULT_RSA_KEY_LENGTH_BITS;
			Initialise();
		}
		public EncryptedDialog(int rsaEncKeyLengthBits) {
			State = DialogState.Disconnected;
			_rsaDecKeyLength = rsaEncKeyLengthBits;
			Initialise();
		}

		private void Initialise() {
			_connection = new TCPConnection();
			_connection.OnConnectionEstablished += OnConnectionEstablished;
			_connection.OnMessageReceived += InnerMessageReceived;
		}
		#endregion

		#region Event Handlers
		private void OnConnectionEstablished(object sender, EventArgs e) {
			State = DialogState.Connected;
		}

		private void InnerMessageReceived(object sender, IPMessageEventArgs e) {
			switch(State) {
				case DialogState.Connected:
					switch (e.Message[MESSAGE_TYPE_BYTE_NUMBER]) {
						case MT_TEXT:
							if (OnMessageReceived != null) 
								OnMessageReceived(this, _coder.GetString(e.Message, MESSAGE_TYPE_LENGTH, e.Length - MESSAGE_TYPE_LENGTH));
							break;
						case MT_KEYS:
							State = DialogState.KeysAccepting;
							AcceptKeys(e.Message);
							State = DialogState.EncryptedOut;
							break;
					}
					break;
				case DialogState.EncryptedIn:
					switch (e.Message[MESSAGE_TYPE_BYTE_NUMBER]) {
						case MT_TEXT:
							if (OnMessageReceived != null){
								var textPart = new byte[e.Length - MESSAGE_TYPE_LENGTH];
								for (int i = 1; i < e.Message.Length; i++)
									textPart[i - 1] = e.Message[i];
								var text = _decryptor.Decrypt(textPart, true);
								OnMessageReceived(this, _coder.GetString(text));
								}
							break;
						case MT_KEYS:
							State = DialogState.KeysAccepting;
							AcceptKeys(e.Message);
							State = DialogState.EncryptedAll;
							break;
					}
					break;
				case DialogState.EncryptedOut:
					switch (e.Message[MESSAGE_TYPE_BYTE_NUMBER]) {
						case MT_TEXT:
							if (OnMessageReceived != null)
								OnMessageReceived(this, _coder.GetString(e.Message, MESSAGE_TYPE_LENGTH, e.Length - MESSAGE_TYPE_LENGTH));
							break;
						case MT_KEYS:
							State = DialogState.KeysAccepting;
							AcceptKeys(e.Message);
							State = DialogState.EncryptedOut;
							break;
					}
					break;
				case DialogState.EncryptedAll:
					switch (e.Message[MESSAGE_TYPE_BYTE_NUMBER]) {
						case MT_TEXT:
							if (OnMessageReceived != null){
								var textPart = new byte[e.Length - MESSAGE_TYPE_LENGTH];
								for(int i=1; i<e.Message.Length; i++)
									textPart[i-1] = e.Message[i];
								var text = _decryptor.Decrypt(textPart, true);
								OnMessageReceived(this, _coder.GetString(text));
								}
							break;
						case MT_KEYS:
							State = DialogState.KeysAccepting;
							AcceptKeys(e.Message);
							State = DialogState.EncryptedAll;
							break;
						}
					break;
			}
		}

		#endregion

		#region Private functions/procedures
			private void AcceptKeys(byte[] message) {
				var mKeyLen = BitConverter.ToInt32(message, MESSAGE_TYPE_LENGTH);
				_rsaEncKeyLength = mKeyLen;
				
				byte[] m = new byte[mKeyLen];
				for (int i = MESSAGE_TYPE_LENGTH + MODULUS_LENGTH_LENGTH; i < MESSAGE_TYPE_LENGTH + MODULUS_LENGTH_LENGTH + mKeyLen; i++)
					m[i - MESSAGE_TYPE_LENGTH - MODULUS_LENGTH_LENGTH] = message[i];

				byte[] exp = new byte[message.Length - MESSAGE_TYPE_LENGTH - MODULUS_LENGTH_LENGTH - mKeyLen];
				for(int i = MESSAGE_TYPE_LENGTH + MODULUS_LENGTH_LENGTH + mKeyLen; i< message.Length; i++)
					exp[i-MESSAGE_TYPE_LENGTH - MODULUS_LENGTH_LENGTH - mKeyLen] = message[i];

				var pars = new RSAParameters {
					Modulus = m, Exponent = exp
				};

				_encryptor.ImportParameters(pars);
			}
		#endregion

		#region Gettings
		public DialogState GetState() {return State;}
		public int GetEncryptingKeyLength() {return _rsaEncKeyLength;}
		#endregion

		#region Public commands
			#region BecomeAServer
			public void BecomeAServerAndWait(int port) {
				_connection.BecomeAServerAndWait("", port);
				State = DialogState.Connecting;
			}
			public void BecomeAServerAndWait(string ip, int port) {
				_connection.BecomeAServerAndWait(ip, port);
				State = DialogState.Connecting;
			}
			#endregion

			#region BecomeAClient
			public void BecomeAClientAndConnect(string ip, int port) {
				_connection.BecomeAClientAndConnect(ip, port);
				State = DialogState.Connecting;
			}
			#endregion

			public void SendMessage(string message) {
				var msgBytes = _coder.GetBytes(message);
				switch (State) {
					case DialogState.EncryptedOut:
					case DialogState.EncryptedAll:
						msgBytes = _encryptor.Encrypt(msgBytes, true);
						break;
					case DialogState.Connected:
					case DialogState.EncryptedIn:
						break;
					case DialogState.KeysAccepting:
						throw new Exception("The encryptor is getting ready yet!");
					default:
						throw new Exception("Not connected!");
				}
				var msgToSend = new byte[msgBytes.Length+1];
				msgBytes.CopyTo(msgToSend, MESSAGE_TYPE_LENGTH);
				msgToSend[MESSAGE_TYPE_BYTE_NUMBER] = MT_TEXT;
				_connection.Send(msgToSend);
			}

			public void MakeAndSendKeys() {
				if (((State == DialogState.Disconnected) || (State == DialogState.Connecting))) throw new Exception("Not connected!");
				_decryptor = new RSACryptoServiceProvider(_rsaDecKeyLength);
				var pars = _decryptor.ExportParameters(false);
				var m = pars.Modulus;
				var exp = pars.Exponent;

				byte[] message = new byte[MESSAGE_TYPE_LENGTH + MODULUS_LENGTH_LENGTH + m.Length + exp.Length];
				byte[] mL = BitConverter.GetBytes(_rsaDecKeyLengthBytes);
				
				message[MESSAGE_TYPE_BYTE_NUMBER] = MT_KEYS;
				for(int i=MESSAGE_TYPE_LENGTH; i<(MESSAGE_TYPE_LENGTH + MODULUS_LENGTH_LENGTH); i++)
					message[i] = mL[i-MESSAGE_TYPE_LENGTH];
				for (int i = (MESSAGE_TYPE_LENGTH + MODULUS_LENGTH_LENGTH); i < (MESSAGE_TYPE_LENGTH + MODULUS_LENGTH_LENGTH + _rsaDecKeyLengthBytes); i++)
					message[i] = m[i - MESSAGE_TYPE_LENGTH - MODULUS_LENGTH_LENGTH];
				for (int i = (MESSAGE_TYPE_LENGTH + MODULUS_LENGTH_LENGTH + _rsaDecKeyLengthBytes); i < message.Length; i++)
					message[i] = exp[i - MESSAGE_TYPE_LENGTH - MODULUS_LENGTH_LENGTH - _rsaDecKeyLengthBytes];
				_connection.Send(message);

				if(State==DialogState.EncryptedOut)
					State = DialogState.EncryptedAll;
				else 
					State = DialogState.EncryptedIn;
			}

			public void Disconnect() {
				if(State == DialogState.Disconnected) return;
				_connection.Close();
				_connection = new TCPConnection();
				State = DialogState.Disconnected;
			}
		#endregion

	}
}
