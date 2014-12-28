using System;
using System.Drawing;
using System.Windows.Forms;
using CryptoLocalChat.Properties;

namespace CryptoLocalChat {
	public partial class DialogForm : Form {

		#region Constants
			#region Timings (ms)
			private const int MSG_DELAY = 1000;
			private const int UI_RFRSH_PERIOD = 300;
			#endregion

			#region Messages displaying
			private readonly static Color IN_COLOR = Color.DarkGreen;
			private readonly static Color OUT_COLOR = Color.SkyBlue;
			private const HorizontalAlignment IN_ALIGN = HorizontalAlignment.Left;
			private const HorizontalAlignment OUT_ALIGN = HorizontalAlignment.Right;
			#endregion
		#endregion

		#region Serving Objects
		EncryptedDialog _dialog;
		#endregion

		#region Structing
		public DialogForm() {
			InitializeComponent();
			_dialog = new EncryptedDialog();
			_dialog.OnStatusChanged += RefreshUI;
			_dialog.OnMessageReceived += _dialog_MessageReceived;

			RefreshUI(this, _dialog.GetState());
		}
		#endregion

		#region Dialog events
			void RefreshUI(object sender, EncryptedDialog.DialogState e) {
				switch (_dialog.GetState()) {
					case EncryptedDialog.DialogState.Disconnected:
						menu_dialog.Enabled = false;
						menu_disconnect.Enabled = false;
						menu_wait.Enabled = true;
						menu_connect.Enabled = true;
						tb_message.Enabled = false;
						l_co.BackColor = Color.Crimson;
						l_in.BackColor = l_out.BackColor = Color.LightGray;
						break;
					case EncryptedDialog.DialogState.Connecting:
						menu_dialog.Enabled = false;
						menu_disconnect.Enabled = false;
						menu_wait.Enabled = true;
						menu_connect.Enabled = true;
						tb_message.Enabled = false;
						l_co.BackColor = Color.DarkOrange;
						l_in.BackColor = l_out.BackColor = Color.LightGray;
						break;
					case EncryptedDialog.DialogState.Connected:
						menu_dialog.Enabled = true;
						menu_disconnect.Enabled = true;
						menu_wait.Enabled = false;
						menu_connect.Enabled = false;
						tb_message.Enabled = true;
						l_co.BackColor = Color.DarkGreen;
						l_in.BackColor = l_out.BackColor = Color.Crimson;
						break;
					case EncryptedDialog.DialogState.EncryptedIn:
						menu_dialog.Enabled = true;
						menu_disconnect.Enabled = true;
						menu_wait.Enabled = false;
						menu_connect.Enabled = false;
						tb_message.Enabled = true;
						l_co.BackColor = l_in.BackColor = Color.DarkGreen;
						l_out.BackColor = Color.Crimson;
						break;
					case EncryptedDialog.DialogState.KeysAccepting:
						menu_dialog.Enabled = true;
						menu_disconnect.Enabled = true;
						menu_wait.Enabled = false;
						menu_connect.Enabled = false;
						tb_message.Enabled = true;
						l_co.BackColor = Color.DarkGreen;
						l_out.BackColor = Color.Coral;
						break;
					case EncryptedDialog.DialogState.EncryptedOut:
						menu_dialog.Enabled = true;
						menu_disconnect.Enabled = true;
						menu_wait.Enabled = false;
						menu_connect.Enabled = false;
						tb_message.Enabled = true;
						l_co.BackColor = l_out.BackColor = Color.DarkGreen;
						l_in.BackColor = Color.Crimson;
						break;
					case EncryptedDialog.DialogState.EncryptedAll:
						menu_dialog.Enabled = true;
						menu_disconnect.Enabled = true;
						menu_wait.Enabled = false;
						menu_connect.Enabled = false;
						tb_message.Enabled = true;
						l_co.BackColor = l_out.BackColor = l_in.BackColor = Color.DarkGreen;
						break;
					default:
						throw new ArgumentOutOfRangeException("newState");
				}
			}
			private void _dialog_MessageReceived(object sender, string message) {
				DisplayMessage(message, IN_ALIGN, IN_COLOR);
			}
		#endregion

		#region Private functions/procedures
			private void DisplayMessage(String message, HorizontalAlignment alignment, Color color) {
				lv_dialog.Items.Add(message);
				lv_dialog.Items[lv_dialog.Items.Count - 1].ForeColor = color;
				lv_dialog.Items[lv_dialog.Items.Count - 1].EnsureVisible();
			}
		#endregion

		#region UI events
		private void ожидатьToolStripMenuItem1_Click(object sender, EventArgs e){
			_dialog.BecomeAServerAndWait(tb_ip_s.Text, Convert.ToInt32(tb_port_s.Text));
		}
		private void вызватьToolStripMenuItem_Click(object sender, EventArgs e) {
			_dialog.BecomeAClientAndConnect(tb_ip_c.Text, Convert.ToInt32(tb_port_c.Text));
		}
		private void tb_message_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter && tb_message.Enabled) {
				_dialog.SendMessage(tb_message.Text);
				DisplayMessage(tb_message.Text, OUT_ALIGN, OUT_COLOR);
				tb_message.Text = "";
			}
		}
		private void Menu_about_Click(object sender, EventArgs e) {
			MessageBox.Show(this, Resources.About, "Крипточатик");
		}
		private void menu_disconnect_Click(object sender, EventArgs e) {
			_dialog.Disconnect();
		}
		#endregion

		private void menu_generateAndSendRSA_Click(object sender, EventArgs e) {
			_dialog.MakeAndSendKeys();
		}

	}
}