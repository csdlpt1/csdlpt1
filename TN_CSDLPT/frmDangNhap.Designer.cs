
namespace TN_CSDLPT
{
    partial class frmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label tENCNLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdSV = new System.Windows.Forms.RadioButton();
            this.rdGV = new System.Windows.Forms.RadioButton();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tENCNComboBox = new System.Windows.Forms.ComboBox();
            this.bdsDSPM = new System.Windows.Forms.BindingSource(this.components);
            this.tN_CSDLPTDataSet = new TN_CSDLPT.TN_CSDLPTDataSet();
            this.v_DS_PHANMANHTableAdapter = new TN_CSDLPT.TN_CSDLPTDataSetTableAdapters.V_DS_PHANMANHTableAdapter();
            this.tableAdapterManager = new TN_CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager();
            tENCNLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tN_CSDLPTDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tENCNLabel
            // 
            tENCNLabel.AutoSize = true;
            tENCNLabel.Location = new System.Drawing.Point(199, 92);
            tENCNLabel.Name = "tENCNLabel";
            tENCNLabel.Size = new System.Drawing.Size(64, 22);
            tENCNLabel.TabIndex = 0;
            tENCNLabel.Text = "Cơ sở:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdSV);
            this.groupBox1.Controls.Add(this.rdGV);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnDangNhap);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.txtLogin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(tENCNLabel);
            this.groupBox1.Controls.Add(this.tENCNComboBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rdSV
            // 
            this.rdSV.AutoSize = true;
            this.rdSV.Location = new System.Drawing.Point(495, 128);
            this.rdSV.Name = "rdSV";
            this.rdSV.Size = new System.Drawing.Size(105, 26);
            this.rdSV.TabIndex = 17;
            this.rdSV.TabStop = true;
            this.rdSV.Text = "Sinh viên";
            this.rdSV.UseVisualStyleBackColor = true;
            this.rdSV.CheckedChanged += new System.EventHandler(this.rdSV_CheckedChanged);
            // 
            // rdGV
            // 
            this.rdGV.AutoSize = true;
            this.rdGV.Location = new System.Drawing.Point(335, 128);
            this.rdGV.Name = "rdGV";
            this.rdGV.Size = new System.Drawing.Size(117, 26);
            this.rdGV.TabIndex = 16;
            this.rdGV.TabStop = true;
            this.rdGV.Text = "Giảng viên";
            this.rdGV.UseVisualStyleBackColor = true;
            this.rdGV.CheckedChanged += new System.EventHandler(this.rdGV_CheckedChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(495, 287);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(107, 35);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(312, 287);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(107, 35);
            this.btnDangNhap.TabIndex = 14;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(311, 234);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(291, 30);
            this.txtPass.TabIndex = 13;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(311, 170);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(291, 30);
            this.txtLogin.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mật khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tài khoản:";
            // 
            // tENCNComboBox
            // 
            this.tENCNComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDSPM, "TENCN", true));
            this.tENCNComboBox.DataSource = this.bdsDSPM;
            this.tENCNComboBox.DisplayMember = "TENCN";
            this.tENCNComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tENCNComboBox.FormattingEnabled = true;
            this.tENCNComboBox.Location = new System.Drawing.Point(311, 84);
            this.tENCNComboBox.Name = "tENCNComboBox";
            this.tENCNComboBox.Size = new System.Drawing.Size(289, 30);
            this.tENCNComboBox.TabIndex = 1;
            this.tENCNComboBox.ValueMember = "TENSERVER";
            this.tENCNComboBox.SelectedIndexChanged += new System.EventHandler(this.tENCNComboBox_SelectedIndexChanged);
            // 
            // bdsDSPM
            // 
            this.bdsDSPM.DataMember = "V_DS_PHANMANH";
            this.bdsDSPM.DataSource = this.tN_CSDLPTDataSet;
            // 
            // tN_CSDLPTDataSet
            // 
            this.tN_CSDLPTDataSet.DataSetName = "TN_CSDLPTDataSet";
            this.tN_CSDLPTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_DS_PHANMANHTableAdapter
            // 
            this.v_DS_PHANMANHTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = TN_CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDangNhap";
            this.Text = "frmDangNhap";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tN_CSDLPTDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private TN_CSDLPTDataSet tN_CSDLPTDataSet;
        private System.Windows.Forms.BindingSource bdsDSPM;
        private TN_CSDLPTDataSetTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
        private TN_CSDLPTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.RadioButton rdSV;
        private System.Windows.Forms.RadioButton rdGV;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tENCNComboBox;
    }
}