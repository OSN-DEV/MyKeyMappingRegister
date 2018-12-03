namespace MyKeyMappingGenerator {
    partial class MainForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.cMode1 = new MyLib.WF.Component.RadioButtonEx();
            this.cMode2 = new MyLib.WF.Component.RadioButtonEx();
            this.cScanCode1 = new MyLib.WF.Component.LabelEx(this.components);
            this.cScanCode2 = new MyLib.WF.Component.LabelEx(this.components);
            this.cWindowsKey2 = new MyLib.WF.Component.LabelEx(this.components);
            this.cWindowsKey1 = new MyLib.WF.Component.LabelEx(this.components);
            this.cSave = new MyLib.WF.Component.ButtonEx(this.components);
            this.cKeyList = new MyLib.WF.Component.DataGridViewEx();
            this.cColScanCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cColFlags1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cColWindowsKey1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cColScanCode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cColFlags2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cColWindowsKey2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cColEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cColDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cFlags2 = new MyLib.WF.Component.LabelEx(this.components);
            this.cFlags1 = new MyLib.WF.Component.LabelEx(this.components);
            this.menuStripEx1 = new MyLib.WF.Component.MenuStripEx(this.components);
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cFile_New = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.cFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.cFile_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.registryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRegistry_CreateRegisterFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cKeyCodeList = new MyLib.WF.Component.ComboboxEx();
            this.cRegistry_Register = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.cKeyList)).BeginInit();
            this.menuStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cMode1
            // 
            this.cMode1.Appearance = System.Windows.Forms.Appearance.Button;
            this.cMode1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cMode1.Location = new System.Drawing.Point(12, 38);
            this.cMode1.Name = "cMode1";
            this.cMode1.Size = new System.Drawing.Size(70, 28);
            this.cMode1.TabIndex = 0;
            this.cMode1.Text = "Before";
            this.cMode1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cMode1.UseVisualStyleBackColor = true;
            // 
            // cMode2
            // 
            this.cMode2.Appearance = System.Windows.Forms.Appearance.Button;
            this.cMode2.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cMode2.Location = new System.Drawing.Point(12, 77);
            this.cMode2.Name = "cMode2";
            this.cMode2.Size = new System.Drawing.Size(70, 26);
            this.cMode2.TabIndex = 1;
            this.cMode2.Text = "After";
            this.cMode2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cMode2.UseVisualStyleBackColor = true;
            // 
            // cScanCode1
            // 
            this.cScanCode1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cScanCode1.Location = new System.Drawing.Point(88, 38);
            this.cScanCode1.Name = "cScanCode1";
            this.cScanCode1.Size = new System.Drawing.Size(46, 26);
            this.cScanCode1.TabIndex = 2;
            this.cScanCode1.Text = "0xXX";
            this.cScanCode1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cScanCode2
            // 
            this.cScanCode2.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cScanCode2.Location = new System.Drawing.Point(88, 77);
            this.cScanCode2.Name = "cScanCode2";
            this.cScanCode2.Size = new System.Drawing.Size(46, 26);
            this.cScanCode2.TabIndex = 3;
            this.cScanCode2.Text = "0xXX";
            this.cScanCode2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cWindowsKey2
            // 
            this.cWindowsKey2.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cWindowsKey2.Location = new System.Drawing.Point(211, 77);
            this.cWindowsKey2.Name = "cWindowsKey2";
            this.cWindowsKey2.Size = new System.Drawing.Size(147, 26);
            this.cWindowsKey2.TabIndex = 5;
            this.cWindowsKey2.Text = "cWindowsKey2";
            this.cWindowsKey2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cWindowsKey1
            // 
            this.cWindowsKey1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cWindowsKey1.Location = new System.Drawing.Point(211, 38);
            this.cWindowsKey1.Name = "cWindowsKey1";
            this.cWindowsKey1.Size = new System.Drawing.Size(147, 26);
            this.cWindowsKey1.TabIndex = 4;
            this.cWindowsKey1.Text = "cWindowsKey1";
            this.cWindowsKey1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cSave
            // 
            this.cSave.Location = new System.Drawing.Point(542, 78);
            this.cSave.Name = "cSave";
            this.cSave.Size = new System.Drawing.Size(47, 26);
            this.cSave.TabIndex = 6;
            this.cSave.Text = "＋";
            this.cSave.UseVisualStyleBackColor = true;
            this.cSave.Click += new System.EventHandler(this.cSave_Click);
            // 
            // cKeyList
            // 
            this.cKeyList.AllowUserToAddRows = false;
            this.cKeyList.AllowUserToResizeRows = false;
            this.cKeyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cKeyList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cColScanCode1,
            this.cColFlags1,
            this.cColWindowsKey1,
            this.cColScanCode2,
            this.cColFlags2,
            this.cColWindowsKey2,
            this.cColEdit,
            this.cColDelete});
            this.cKeyList.Location = new System.Drawing.Point(12, 123);
            this.cKeyList.MultiSelect = false;
            this.cKeyList.Name = "cKeyList";
            this.cKeyList.ReadOnly = true;
            this.cKeyList.RowHeadersVisible = false;
            this.cKeyList.RowTemplate.Height = 21;
            this.cKeyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.cKeyList.Size = new System.Drawing.Size(577, 187);
            this.cKeyList.TabIndex = 7;
            this.cKeyList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cKeyList_CellContentClick);
            // 
            // cColScanCode1
            // 
            this.cColScanCode1.HeaderText = "Before";
            this.cColScanCode1.Name = "cColScanCode1";
            this.cColScanCode1.ReadOnly = true;
            this.cColScanCode1.Width = 55;
            // 
            // cColFlags1
            // 
            this.cColFlags1.HeaderText = "";
            this.cColFlags1.Name = "cColFlags1";
            this.cColFlags1.ReadOnly = true;
            this.cColFlags1.Width = 80;
            // 
            // cColWindowsKey1
            // 
            this.cColWindowsKey1.HeaderText = "";
            this.cColWindowsKey1.Name = "cColWindowsKey1";
            this.cColWindowsKey1.ReadOnly = true;
            this.cColWindowsKey1.Width = 80;
            // 
            // cColScanCode2
            // 
            this.cColScanCode2.HeaderText = "After";
            this.cColScanCode2.Name = "cColScanCode2";
            this.cColScanCode2.ReadOnly = true;
            this.cColScanCode2.Width = 55;
            // 
            // cColFlags2
            // 
            this.cColFlags2.HeaderText = "";
            this.cColFlags2.Name = "cColFlags2";
            this.cColFlags2.ReadOnly = true;
            this.cColFlags2.Width = 80;
            // 
            // cColWindowsKey2
            // 
            this.cColWindowsKey2.HeaderText = "";
            this.cColWindowsKey2.Name = "cColWindowsKey2";
            this.cColWindowsKey2.ReadOnly = true;
            this.cColWindowsKey2.Width = 80;
            // 
            // cColEdit
            // 
            this.cColEdit.HeaderText = "";
            this.cColEdit.Name = "cColEdit";
            this.cColEdit.ReadOnly = true;
            this.cColEdit.Width = 60;
            // 
            // cColDelete
            // 
            this.cColDelete.HeaderText = "";
            this.cColDelete.Name = "cColDelete";
            this.cColDelete.ReadOnly = true;
            this.cColDelete.Width = 60;
            // 
            // cFlags2
            // 
            this.cFlags2.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cFlags2.Location = new System.Drawing.Point(130, 77);
            this.cFlags2.Name = "cFlags2";
            this.cFlags2.Size = new System.Drawing.Size(73, 26);
            this.cFlags2.TabIndex = 10;
            this.cFlags2.Text = "Extended";
            this.cFlags2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cFlags1
            // 
            this.cFlags1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cFlags1.Location = new System.Drawing.Point(130, 38);
            this.cFlags1.Name = "cFlags1";
            this.cFlags1.Size = new System.Drawing.Size(73, 26);
            this.cFlags1.TabIndex = 9;
            this.cFlags1.Text = "Extended";
            this.cFlags1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStripEx1
            // 
            this.menuStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.registryToolStripMenuItem});
            this.menuStripEx1.Location = new System.Drawing.Point(0, 0);
            this.menuStripEx1.Name = "menuStripEx1";
            this.menuStripEx1.Size = new System.Drawing.Size(599, 24);
            this.menuStripEx1.TabIndex = 11;
            this.menuStripEx1.Text = "menuStripEx1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cFile_New,
            this.toolStripSeparator3,
            this.cFile_Open,
            this.cFile_Save,
            this.cFile_SaveAs,
            this.toolStripSeparator1,
            this.cFile_Exit});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // cFile_New
            // 
            this.cFile_New.Name = "cFile_New";
            this.cFile_New.Size = new System.Drawing.Size(120, 22);
            this.cFile_New.Text = "New(&N)";
            this.cFile_New.Click += new System.EventHandler(this.cFile_New_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(117, 6);
            // 
            // cFile_Open
            // 
            this.cFile_Open.Name = "cFile_Open";
            this.cFile_Open.Size = new System.Drawing.Size(120, 22);
            this.cFile_Open.Text = "Open(&O)";
            this.cFile_Open.Click += new System.EventHandler(this.cFile_Open_Click);
            // 
            // cFile_Save
            // 
            this.cFile_Save.Name = "cFile_Save";
            this.cFile_Save.Size = new System.Drawing.Size(120, 22);
            this.cFile_Save.Text = "Save(&S)";
            this.cFile_Save.Click += new System.EventHandler(this.cFile_Save_Click);
            // 
            // cFile_SaveAs
            // 
            this.cFile_SaveAs.Name = "cFile_SaveAs";
            this.cFile_SaveAs.Size = new System.Drawing.Size(120, 22);
            this.cFile_SaveAs.Text = "Save As";
            this.cFile_SaveAs.Click += new System.EventHandler(this.cFile_SaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // cFile_Exit
            // 
            this.cFile_Exit.Name = "cFile_Exit";
            this.cFile_Exit.Size = new System.Drawing.Size(120, 22);
            this.cFile_Exit.Text = "Exit(&X)";
            this.cFile_Exit.Click += new System.EventHandler(this.cFile_Exit_Click);
            // 
            // registryToolStripMenuItem
            // 
            this.registryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cRegistry_Register,
            this.cRegistry_CreateRegisterFile});
            this.registryToolStripMenuItem.Name = "registryToolStripMenuItem";
            this.registryToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.registryToolStripMenuItem.Text = "Registry";
            // 
            // cRegistry_CreateRegisterFile
            // 
            this.cRegistry_CreateRegisterFile.Name = "cRegistry_CreateRegisterFile";
            this.cRegistry_CreateRegisterFile.Size = new System.Drawing.Size(167, 22);
            this.cRegistry_CreateRegisterFile.Text = "CreateRegisterFile";
            this.cRegistry_CreateRegisterFile.Click += new System.EventHandler(this.cRegistry_CreateRegisterFile_Click);
            // 
            // cKeyCodeList
            // 
            this.cKeyCodeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cKeyCodeList.FormattingEnabled = true;
            this.cKeyCodeList.Location = new System.Drawing.Point(364, 78);
            this.cKeyCodeList.Name = "cKeyCodeList";
            this.cKeyCodeList.Size = new System.Drawing.Size(147, 25);
            this.cKeyCodeList.TabIndex = 12;
            this.cKeyCodeList.TabStop = false;
            this.cKeyCodeList.SelectedIndexChanged += new System.EventHandler(this.cKeyCodeList_SelectedIndexChanged);
            // 
            // cRegistry_Register
            // 
            this.cRegistry_Register.Name = "cRegistry_Register";
            this.cRegistry_Register.Size = new System.Drawing.Size(167, 22);
            this.cRegistry_Register.Text = "Register";
            this.cRegistry_Register.Click += new System.EventHandler(this.cRegistry_Register_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(599, 322);
            this.Controls.Add(this.cKeyCodeList);
            this.Controls.Add(this.cFlags2);
            this.Controls.Add(this.cFlags1);
            this.Controls.Add(this.cKeyList);
            this.Controls.Add(this.cSave);
            this.Controls.Add(this.cWindowsKey2);
            this.Controls.Add(this.cWindowsKey1);
            this.Controls.Add(this.cScanCode2);
            this.Controls.Add(this.cScanCode1);
            this.Controls.Add(this.cMode2);
            this.Controls.Add(this.cMode1);
            this.Controls.Add(this.menuStripEx1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MainMenuStrip = this.menuStripEx1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyKeyMappinggenerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cKeyList)).EndInit();
            this.menuStripEx1.ResumeLayout(false);
            this.menuStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyLib.WF.Component.RadioButtonEx cMode1;
        private MyLib.WF.Component.RadioButtonEx cMode2;
        private MyLib.WF.Component.LabelEx cScanCode1;
        private MyLib.WF.Component.LabelEx cScanCode2;
        private MyLib.WF.Component.LabelEx cWindowsKey2;
        private MyLib.WF.Component.LabelEx cWindowsKey1;
        private MyLib.WF.Component.ButtonEx cSave;
        private MyLib.WF.Component.DataGridViewEx cKeyList;
        private MyLib.WF.Component.LabelEx cFlags2;
        private MyLib.WF.Component.LabelEx cFlags1;
        private MyLib.WF.Component.MenuStripEx menuStripEx1;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cFile_New;
        private System.Windows.Forms.ToolStripMenuItem cFile_Open;
        private System.Windows.Forms.ToolStripMenuItem cFile_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cFile_Exit;
        private MyLib.WF.Component.ComboboxEx cKeyCodeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn cColScanCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cColFlags1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cColWindowsKey1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cColScanCode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cColFlags2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cColWindowsKey2;
        private System.Windows.Forms.DataGridViewLinkColumn cColEdit;
        private System.Windows.Forms.DataGridViewLinkColumn cColDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cFile_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem registryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cRegistry_CreateRegisterFile;
        private System.Windows.Forms.ToolStripMenuItem cRegistry_Register;
    }
}

