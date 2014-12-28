namespace CryptoLocalChat {
	partial class DialogForm {
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.подключениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_wait = new System.Windows.Forms.ToolStripMenuItem();
			this.tb_ip_s = new System.Windows.Forms.ToolStripTextBox();
			this.tb_port_s = new System.Windows.Forms.ToolStripTextBox();
			this.ожидатьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_connect = new System.Windows.Forms.ToolStripMenuItem();
			this.tb_ip_c = new System.Windows.Forms.ToolStripTextBox();
			this.tb_port_c = new System.Windows.Forms.ToolStripTextBox();
			this.вызватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_disconnect = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_dialog = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_generateAndSendRSA = new System.Windows.Forms.ToolStripMenuItem();
			this.блокнотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.назначитьБлокнотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сгенерироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tb_genKeySize = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.синхронизироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.useOTPComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.rSAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ПодготовитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.синхронноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.создатьСвоиКлючиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ключиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.здешниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tb_keyHereM = new System.Windows.Forms.ToolStripTextBox();
			this.tb_keyHereE = new System.Windows.Forms.ToolStripTextBox();
			this.собеседникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tb_keyThereM = new System.Windows.Forms.ToolStripTextBox();
			this.tb_keyThereE = new System.Windows.Forms.ToolStripTextBox();
			this.useRSAComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.menu_about = new System.Windows.Forms.ToolStripMenuItem();
			this.tb_message = new System.Windows.Forms.TextBox();
			this.lv_dialog = new System.Windows.Forms.ListView();
			this.lv_d_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.l_in = new System.Windows.Forms.Label();
			this.l_out = new System.Windows.Forms.Label();
			this.l_co = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключениеToolStripMenuItem,
            this.menu_dialog,
            this.menu_about});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(751, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// подключениеToolStripMenuItem
			// 
			this.подключениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_wait,
            this.menu_connect,
            this.toolStripSeparator1,
            this.menu_disconnect});
			this.подключениеToolStripMenuItem.Name = "подключениеToolStripMenuItem";
			this.подключениеToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
			this.подключениеToolStripMenuItem.Text = "Подключение";
			// 
			// menu_wait
			// 
			this.menu_wait.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_ip_s,
            this.tb_port_s,
            this.ожидатьToolStripMenuItem1});
			this.menu_wait.Name = "menu_wait";
			this.menu_wait.Size = new System.Drawing.Size(152, 22);
			this.menu_wait.Text = "Ожидание";
			this.menu_wait.ToolTipText = "Стать сервером.";
			// 
			// tb_ip_s
			// 
			this.tb_ip_s.Name = "tb_ip_s";
			this.tb_ip_s.Size = new System.Drawing.Size(100, 23);
			this.tb_ip_s.Text = "0.0.0.0";
			this.tb_ip_s.ToolTipText = "IP для ожидания. По умолчанию - любой.";
			// 
			// tb_port_s
			// 
			this.tb_port_s.Name = "tb_port_s";
			this.tb_port_s.Size = new System.Drawing.Size(100, 23);
			this.tb_port_s.Text = "65000";
			this.tb_port_s.ToolTipText = "Порт для ожидания.";
			// 
			// ожидатьToolStripMenuItem1
			// 
			this.ожидатьToolStripMenuItem1.Name = "ожидатьToolStripMenuItem1";
			this.ожидатьToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
			this.ожидатьToolStripMenuItem1.Text = "Ожидать";
			this.ожидатьToolStripMenuItem1.Click += new System.EventHandler(this.ожидатьToolStripMenuItem1_Click);
			// 
			// menu_connect
			// 
			this.menu_connect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_ip_c,
            this.tb_port_c,
            this.вызватьToolStripMenuItem});
			this.menu_connect.Name = "menu_connect";
			this.menu_connect.Size = new System.Drawing.Size(152, 22);
			this.menu_connect.Text = "Вызов";
			this.menu_connect.ToolTipText = "Стать клиентом.";
			// 
			// tb_ip_c
			// 
			this.tb_ip_c.Name = "tb_ip_c";
			this.tb_ip_c.Size = new System.Drawing.Size(100, 23);
			this.tb_ip_c.Text = "127.0.0.1";
			this.tb_ip_c.ToolTipText = "IP для вызова. По умолчанию - на localhost.";
			// 
			// tb_port_c
			// 
			this.tb_port_c.Name = "tb_port_c";
			this.tb_port_c.Size = new System.Drawing.Size(100, 23);
			this.tb_port_c.Text = "65000";
			this.tb_port_c.ToolTipText = "Порт для вызова.";
			// 
			// вызватьToolStripMenuItem
			// 
			this.вызватьToolStripMenuItem.Name = "вызватьToolStripMenuItem";
			this.вызватьToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.вызватьToolStripMenuItem.Text = "Вызвать";
			this.вызватьToolStripMenuItem.Click += new System.EventHandler(this.вызватьToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// menu_disconnect
			// 
			this.menu_disconnect.Name = "menu_disconnect";
			this.menu_disconnect.Size = new System.Drawing.Size(152, 22);
			this.menu_disconnect.Text = "Отключиться";
			this.menu_disconnect.Click += new System.EventHandler(this.menu_disconnect_Click);
			// 
			// menu_dialog
			// 
			this.menu_dialog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_generateAndSendRSA,
            this.блокнотToolStripMenuItem,
            this.rSAToolStripMenuItem});
			this.menu_dialog.Name = "menu_dialog";
			this.menu_dialog.Size = new System.Drawing.Size(59, 20);
			this.menu_dialog.Text = "Диалог";
			// 
			// menu_generateAndSendRSA
			// 
			this.menu_generateAndSendRSA.Name = "menu_generateAndSendRSA";
			this.menu_generateAndSendRSA.Size = new System.Drawing.Size(365, 22);
			this.menu_generateAndSendRSA.Text = "Сгенерировать ключи RSA и послать открытую пару";
			this.menu_generateAndSendRSA.Click += new System.EventHandler(this.menu_generateAndSendRSA_Click);
			// 
			// блокнотToolStripMenuItem
			// 
			this.блокнотToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.назначитьБлокнотToolStripMenuItem,
            this.сгенерироватьToolStripMenuItem,
            this.синхронизироватьToolStripMenuItem,
            this.useOTPComboBox});
			this.блокнотToolStripMenuItem.Name = "блокнотToolStripMenuItem";
			this.блокнотToolStripMenuItem.Size = new System.Drawing.Size(365, 22);
			this.блокнотToolStripMenuItem.Text = "Блокнот";
			this.блокнотToolStripMenuItem.Visible = false;
			// 
			// назначитьБлокнотToolStripMenuItem
			// 
			this.назначитьБлокнотToolStripMenuItem.Name = "назначитьБлокнотToolStripMenuItem";
			this.назначитьБлокнотToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.назначитьБлокнотToolStripMenuItem.Text = "Назначить";
			this.назначитьБлокнотToolStripMenuItem.ToolTipText = "Выбрать существующий файл блокнота.";
			// 
			// сгенерироватьToolStripMenuItem
			// 
			this.сгенерироватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_genKeySize,
            this.toolStripMenuItem1});
			this.сгенерироватьToolStripMenuItem.Name = "сгенерироватьToolStripMenuItem";
			this.сгенерироватьToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.сгенерироватьToolStripMenuItem.Text = "Сгенерировать";
			this.сгенерироватьToolStripMenuItem.ToolTipText = "Создать новый файл блокнота key.otp и назначить его.";
			// 
			// tb_genKeySize
			// 
			this.tb_genKeySize.Name = "tb_genKeySize";
			this.tb_genKeySize.Size = new System.Drawing.Size(100, 23);
			this.tb_genKeySize.Text = "10";
			this.tb_genKeySize.ToolTipText = "Размер будущего файла-ключа в мегабайтах.";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem1.Text = "Начать";
			// 
			// синхронизироватьToolStripMenuItem
			// 
			this.синхронизироватьToolStripMenuItem.Name = "синхронизироватьToolStripMenuItem";
			this.синхронизироватьToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.синхронизироватьToolStripMenuItem.Text = "Синхронизировать";
			this.синхронизироватьToolStripMenuItem.ToolTipText = "Уравнять к большему смещения по блокноту с собеседником.";
			// 
			// useOTPComboBox
			// 
			this.useOTPComboBox.Items.AddRange(new object[] {
            "Не использовать",
            "Использовать"});
			this.useOTPComboBox.Name = "useOTPComboBox";
			this.useOTPComboBox.Size = new System.Drawing.Size(121, 23);
			// 
			// rSAToolStripMenuItem
			// 
			this.rSAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ПодготовитьToolStripMenuItem,
            this.ключиToolStripMenuItem,
            this.useRSAComboBox});
			this.rSAToolStripMenuItem.Name = "rSAToolStripMenuItem";
			this.rSAToolStripMenuItem.Size = new System.Drawing.Size(365, 22);
			this.rSAToolStripMenuItem.Text = "RSA";
			this.rSAToolStripMenuItem.Visible = false;
			// 
			// ПодготовитьToolStripMenuItem
			// 
			this.ПодготовитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.синхронноToolStripMenuItem,
            this.создатьСвоиКлючиToolStripMenuItem});
			this.ПодготовитьToolStripMenuItem.Name = "ПодготовитьToolStripMenuItem";
			this.ПодготовитьToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.ПодготовитьToolStripMenuItem.Text = "Подготовить";
			// 
			// синхронноToolStripMenuItem
			// 
			this.синхронноToolStripMenuItem.Name = "синхронноToolStripMenuItem";
			this.синхронноToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.синхронноToolStripMenuItem.Text = "Синхронно";
			// 
			// создатьСвоиКлючиToolStripMenuItem
			// 
			this.создатьСвоиКлючиToolStripMenuItem.Name = "создатьСвоиКлючиToolStripMenuItem";
			this.создатьСвоиКлючиToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.создатьСвоиКлючиToolStripMenuItem.Text = "Создать свои ключи";
			// 
			// ключиToolStripMenuItem
			// 
			this.ключиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.здешниеToolStripMenuItem,
            this.собеседникаToolStripMenuItem});
			this.ключиToolStripMenuItem.Name = "ключиToolStripMenuItem";
			this.ключиToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.ключиToolStripMenuItem.Text = "Ключи";
			// 
			// здешниеToolStripMenuItem
			// 
			this.здешниеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_keyHereM,
            this.tb_keyHereE});
			this.здешниеToolStripMenuItem.Name = "здешниеToolStripMenuItem";
			this.здешниеToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.здешниеToolStripMenuItem.Text = "Здешние";
			// 
			// tb_keyHereM
			// 
			this.tb_keyHereM.Name = "tb_keyHereM";
			this.tb_keyHereM.Size = new System.Drawing.Size(100, 23);
			// 
			// tb_keyHereE
			// 
			this.tb_keyHereE.Name = "tb_keyHereE";
			this.tb_keyHereE.Size = new System.Drawing.Size(100, 23);
			// 
			// собеседникаToolStripMenuItem
			// 
			this.собеседникаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_keyThereM,
            this.tb_keyThereE});
			this.собеседникаToolStripMenuItem.Name = "собеседникаToolStripMenuItem";
			this.собеседникаToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.собеседникаToolStripMenuItem.Text = "Собеседника";
			// 
			// tb_keyThereM
			// 
			this.tb_keyThereM.Name = "tb_keyThereM";
			this.tb_keyThereM.Size = new System.Drawing.Size(100, 23);
			// 
			// tb_keyThereE
			// 
			this.tb_keyThereE.Name = "tb_keyThereE";
			this.tb_keyThereE.Size = new System.Drawing.Size(100, 23);
			// 
			// useRSAComboBox
			// 
			this.useRSAComboBox.Items.AddRange(new object[] {
            "Не использовать",
            "Использовать"});
			this.useRSAComboBox.Name = "useRSAComboBox";
			this.useRSAComboBox.Size = new System.Drawing.Size(121, 23);
			// 
			// menu_about
			// 
			this.menu_about.Name = "menu_about";
			this.menu_about.Size = new System.Drawing.Size(94, 20);
			this.menu_about.Text = "О программе";
			this.menu_about.Click += new System.EventHandler(this.Menu_about_Click);
			// 
			// tb_message
			// 
			this.tb_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tb_message.Location = new System.Drawing.Point(12, 339);
			this.tb_message.Name = "tb_message";
			this.tb_message.Size = new System.Drawing.Size(727, 20);
			this.tb_message.TabIndex = 5;
			this.tb_message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_message_KeyDown);
			// 
			// lv_dialog
			// 
			this.lv_dialog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lv_dialog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_d_columnHeader});
			this.lv_dialog.Location = new System.Drawing.Point(12, 27);
			this.lv_dialog.Name = "lv_dialog";
			this.lv_dialog.Size = new System.Drawing.Size(727, 306);
			this.lv_dialog.TabIndex = 8;
			this.lv_dialog.UseCompatibleStateImageBehavior = false;
			this.lv_dialog.View = System.Windows.Forms.View.List;
			// 
			// lv_d_columnHeader
			// 
			this.lv_d_columnHeader.Text = "";
			this.lv_d_columnHeader.Width = 671;
			// 
			// l_in
			// 
			this.l_in.AutoSize = true;
			this.l_in.BackColor = System.Drawing.SystemColors.Control;
			this.l_in.Location = new System.Drawing.Point(96, 366);
			this.l_in.Name = "l_in";
			this.l_in.Size = new System.Drawing.Size(54, 13);
			this.l_in.TabIndex = 9;
			this.l_in.Text = "INCRYPT";
			// 
			// l_out
			// 
			this.l_out.AutoSize = true;
			this.l_out.Location = new System.Drawing.Point(156, 366);
			this.l_out.Name = "l_out";
			this.l_out.Size = new System.Drawing.Size(66, 13);
			this.l_out.TabIndex = 10;
			this.l_out.Text = "OUTCRYPT";
			// 
			// l_co
			// 
			this.l_co.AutoSize = true;
			this.l_co.Location = new System.Drawing.Point(12, 366);
			this.l_co.Name = "l_co";
			this.l_co.Size = new System.Drawing.Size(78, 13);
			this.l_co.TabIndex = 11;
			this.l_co.Text = "CONNECTION";
			// 
			// DialogForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(751, 388);
			this.Controls.Add(this.l_co);
			this.Controls.Add(this.l_out);
			this.Controls.Add(this.l_in);
			this.Controls.Add(this.lv_dialog);
			this.Controls.Add(this.tb_message);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "DialogForm";
			this.Text = "Dialog";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem подключениеToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_dialog;
		private System.Windows.Forms.ToolStripMenuItem menu_about;
		private System.Windows.Forms.ToolStripMenuItem menu_wait;
		private System.Windows.Forms.ToolStripTextBox tb_port_s;
		private System.Windows.Forms.ToolStripMenuItem ожидатьToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menu_connect;
		private System.Windows.Forms.ToolStripTextBox tb_ip_c;
		private System.Windows.Forms.ToolStripMenuItem вызватьToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox tb_ip_s;
		private System.Windows.Forms.ToolStripTextBox tb_port_c;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menu_disconnect;
		private System.Windows.Forms.TextBox tb_message;
		private System.Windows.Forms.ListView lv_dialog;
		private System.Windows.Forms.ToolStripMenuItem блокнотToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem назначитьБлокнотToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem синхронизироватьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сгенерироватьToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox tb_genKeySize;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripComboBox useOTPComboBox;
		private System.Windows.Forms.ToolStripMenuItem rSAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ПодготовитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripComboBox useRSAComboBox;
		private System.Windows.Forms.ToolStripMenuItem синхронноToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem создатьСвоиКлючиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ключиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem здешниеToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox tb_keyHereM;
		private System.Windows.Forms.ToolStripTextBox tb_keyHereE;
		private System.Windows.Forms.ToolStripMenuItem собеседникаToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox tb_keyThereM;
		private System.Windows.Forms.ToolStripTextBox tb_keyThereE;
        private System.Windows.Forms.ColumnHeader lv_d_columnHeader;
		private System.Windows.Forms.ToolStripMenuItem menu_generateAndSendRSA;
		private System.Windows.Forms.Label l_in;
		private System.Windows.Forms.Label l_out;
		private System.Windows.Forms.Label l_co;
	}
}

