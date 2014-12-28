using System;
using System.IO;
using System.Windows.Forms;

namespace OneTimePad{
	public class OtpCryptor : IDisposable {
		#region Fields

		private FileStream _padStream;
		private BinaryWriter _padWriter;
		private BinaryReader _padReader;
		private long _padPosition;
		private readonly Random _random = new Random();

		#endregion

		#region Properties
		/// <summary>
		/// Файловый поток с файлом блокнота
		/// </summary>
		public String PadFile {
			set {
				_padStream = new FileStream(value, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
				_padWriter = new BinaryWriter(_padStream);
				_padReader = new BinaryReader(_padStream);
				_padPosition = _padReader.ReadInt64();
				if (_padPosition > _padStream.Length)
					throw new ArgumentException("File isn't a valid One-Time Pad file");
				_padStream.Position = _padPosition;
			}
		}
		/// <summary>
		/// Оставшаяся длина файла блокнота
		/// </summary>
		public long LengthLeft {
			get { return _padStream.Length - _padStream.Position; }
		}
		/// <summary>
		/// Длина файла блокнота
		/// </summary>
		public long Length {
			get { return _padStream.Length; }
		}
		/// <summary>
		/// Текущая позиция в файле блокнота. ВНИМАНИЕ! Не стоит уменьшать это значение, всё, что вы получите - эксепшн.
		/// </summary>
		public long Position {
			get { return _padPosition; }
			set {
				if (value < _padPosition) {
					throw new Exception("Несанкционированная попытка использования машины времени!");
				}
				if (value > _padStream.Length) {
					throw new Exception("Несанкционированная попытка побега из блокнота!");
				}
				if (value == _padPosition) {
					return;
				}
				ErasePad(_padPosition, value - _padPosition);
				_padPosition = value;
				WritePosition();
			}
		}
		public bool SyncPosition(long newPos){
			if(newPos<Position) 
				return false;
			Position = newPos;
			return true;
		}

		#endregion

		#region Structing
		public OtpCryptor(String filePath) {
			PadFile = filePath;
		}
		#endregion

		#region Cryptors
		public void Encrypt(byte[] inputBytes) {
			if (LengthLeft < inputBytes.Length) {
				throw new Exception("Файл блокнота кончился");
			}
			byte[] key = _padReader.ReadBytes(inputBytes.Length);
			for (int i = 0; i < inputBytes.Length; i++) {
				inputBytes[i] ^= key[i];
			}
			ErasePad(_padPosition, inputBytes.LongLength);
			_padPosition = _padStream.Position;
			WritePosition();
		}
		/// <summary>
		/// Шифрует полученный массив байт и заполняет соответствующий кусок блокнота мусором
		/// </summary>
		/// <param name="inputBytes">массив байтов для шифрования</param>
		/// <returns>зашифрованный массив</returns>
		//public byte[] Encrypt(byte[] inputBytes) {
		//	if (LengthLeft < inputBytes.Length) {
		//		throw new Exception("Файл блокнота кончился");
		//	}
		//	byte[] key = _padReader.ReadBytes(inputBytes.Length);
		//	for (int i = 0; i < inputBytes.Length; i++) {
		//		key[i] ^= inputBytes[i];
		//	}
		//	ErasePad(_padPosition, inputBytes.LongLength);
		//	_padPosition = _padStream.Position;
		//	WritePosition();
		//	return key;
		//}

		/// <summary>
		/// Расшифровывает полученный массив байт и заполняет соответствующий кусок блокнота мусором
		/// </summary>
		/// <param name="inputBytes">массив байтов для расшифрования</param>
		/// <returns>расшифрованный массив</returns>
		public void Decrypt(byte[] inputBytes) {
			if (LengthLeft < inputBytes.Length) {
				throw new Exception("Файл блокнота кончился");
			}
			byte[] key = _padReader.ReadBytes(inputBytes.Length);
			for (int i = 0; i < inputBytes.Length; i++) {
				inputBytes[i] ^= key[i];
			}
			ErasePad(_padPosition, inputBytes.LongLength);
			_padPosition = _padStream.Position;
			WritePosition();
		}
		//public byte[] Decrypt(byte[] inputBytes) {
		//	if (LengthLeft < inputBytes.Length) {
		//		throw new Exception("Файл блокнота кончился");
		//	}
		//	byte[] key = _padReader.ReadBytes(inputBytes.Length);
		//	for (int i = 0; i < inputBytes.Length; i++) {
		//		key[i] ^= inputBytes[i];
		//	}
		//	ErasePad(_padPosition, inputBytes.LongLength);
		//	_padPosition = _padStream.Position;
		//	WritePosition();
		//	return key;
		//}

		#endregion

		#region Internals
		/// <summary>
		/// Заполняет кусок блокнота мусором
		/// </summary>
		/// <param name="position">начало куска</param>
		/// <param name="length">длина куска</param>
		private void ErasePad(long position, long length) {
			_padStream.Position = position;
			var clBytes = new byte[length];
			_random.NextBytes(clBytes);
			_padWriter.Write(clBytes);
			_padWriter.Flush();
		}
		/// <summary>
		/// Просто пишет позицию в файл
		/// </summary>
		private void WritePosition() {
			_padStream.Position = 0;
			_padWriter.Write(_padPosition);
			_padWriter.Flush();
			_padStream.Position = _padPosition;
		}

		#endregion

		public void Dispose() {
			_padReader.Dispose();
			_padWriter.Dispose();
			_padStream.Dispose();
		}
	}

	static class OTPFileWork{
		#region CreateOTP
		public static void CreateOTP(int seed, int size){
            Random rand = new Random(seed);
            var crStream = new FileStream("key.otp", FileMode.Create, FileAccess.Write, FileShare.None);
            var crWriter = new BinaryWriter(crStream);
            crWriter.Write((long) 8);
            var buf = new byte[1024*1024];
            for (int i = 0; i < size; i++){
                rand.NextBytes(buf);
                crWriter.Write(buf);
            }
            crWriter.Flush();
			crStream.Close();
			crWriter.Close();
		}
		public static void CreateOTP(int size) {
			Random rand = new Random();
			var crStream = new FileStream("key.otp", FileMode.Create, FileAccess.Write, FileShare.None);
			var crWriter = new BinaryWriter(crStream);
			crWriter.Write((long)8);
			var buf = new byte[1024 * 1024];
			for (int i = 0; i < size; i++) {
				rand.NextBytes(buf);
				crWriter.Write(buf);
			}
			crWriter.Flush();
			crStream.Close();
			crWriter.Close();
		}
		#endregion

		#region AdoptOTP
		public static void AdobtOTP(String filePath){
            if (filePath == "")
                return;
			var adStream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.None);
            var adWriter = new BinaryWriter(adStream);
            adWriter.Write((long) 9);
            adWriter.Flush();
		}
		public static void AdobtOTP() {
			var adDialog = new OpenFileDialog();
			adDialog.ShowDialog();
			if (adDialog.SafeFileName == "")
				return;
			var adStream = new FileStream(adDialog.FileName, FileMode.Open, FileAccess.Write, FileShare.None);
			var adWriter = new BinaryWriter(adStream);
			adWriter.Write((long)9);
			adWriter.Flush();
		}
		#endregion
	}
}