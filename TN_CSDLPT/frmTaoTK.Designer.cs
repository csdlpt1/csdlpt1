
namespace TN_CSDLPT
{
    partial class frmTaoTK
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
            System.Windows.Forms.Label mAGVLabel;
            this.grcQuyen = new DevExpress.XtraEditors.GroupControl();
            this.rdGV = new System.Windows.Forms.RadioButton();
            this.rdCoSo = new System.Windows.Forms.RadioButton();
            this.rdTruong = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTao = new System.Windows.Forms.Button();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUsername = new System.Windows.Forms.ComboBox();
            this.gIAOVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new TN_CSDLPT.DS();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gIAOVIENTableAdapter = new TN_CSDLPT.DSTableAdapters.GIAOVIENTableAdapter();
            this.tableAdapterManager = new TN_CSDLPT.DSTableAdapters.TableAdapterManager();
            mAGVLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grcQuyen)).BeginInit();
            this.grcQuyen.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gIAOVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            this.SuspendLayout();
            // 
            // mAGVLabel
            // 
            mAGVLabel.AutoSize = true;
            mAGVLabel.Location = new System.Drawing.Point(530, 134);
            mAGVLabel.Name = "mAGVLabel";
            mAGVLabel.Size = new System.Drawing.Size(104, 22);
            mAGVLabel.TabIndex = 7;
            mAGVLabel.Text = "User Name:";
            // 
            // grcQuyen
            // 
            this.grcQuyen.Controls.Add(this.rdGV);
            this.grcQuyen.Controls.Add(this.rdCoSo);
            this.grcQuyen.Controls.Add(this.rdTruong);
            this.grcQuyen.Dock = System.Windows.Forms.DockStyle.Top;
            this.grcQuyen.Location = new System.Drawing.Point(0, 0);
            this.grcQuyen.Name = "grcQuyen";
            this.grcQuyen.Size = new System.Drawing.Size(1100, 277);
            this.grcQuyen.TabIndex = 0;
            this.grcQuyen.Text = "groupControl1";
            // 
            // rdGV
            // 
            this.rdGV.AutoSize = true;
            this.rdGV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdGV.Location = new System.Drawing.Point(716, 183);
            this.rdGV.Name = "rdGV";
            this.rdGV.Size = new System.Drawing.Size(143, 26);
            this.rdGV.TabIndex = 5;
            this.rdGV.TabStop = true;
            this.rdGV.Text = "GIẢNG VIÊN";
            this.rdGV.UseVisualStyleBackColor = true;
            this.rdGV.CheckedChanged += new System.EventHandler(this.rdGV_CheckedChanged);
            // 
            // rdCoSo
            // 
            this.rdCoSo.AutoSize = true;
            this.rdCoSo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCoSo.Location = new System.Drawing.Point(716, 127);
            this.rdCoSo.Name = "rdCoSo";
            this.rdCoSo.Size = new System.Drawing.Size(88, 26);
            this.rdCoSo.TabIndex = 4;
            this.rdCoSo.TabStop = true;
            this.rdCoSo.Text = "SƠ CỞ";
            this.rdCoSo.UseVisualStyleBackColor = true;
            this.rdCoSo.CheckedChanged += new System.EventHandler(this.rdCoSo_CheckedChanged);
            // 
            // rdTruong
            // 
            this.rdTruong.AutoSize = true;
            this.rdTruong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTruong.Location = new System.Drawing.Point(716, 75);
            this.rdTruong.Name = "rdTruong";
            this.rdTruong.Size = new System.Drawing.Size(114, 26);
            this.rdTruong.TabIndex = 3;
            this.rdTruong.TabStop = true;
            this.rdTruong.Text = "TRƯỜNG";
            this.rdTruong.UseVisualStyleBackColor = true;
            this.rdTruong.CheckedChanged += new System.EventHandler(this.rdTruong_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnTao);
            this.panel1.Controls.Add(this.txtConfirmPass);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(mAGVLabel);
            this.panel1.Controls.Add(this.cmbUsername);
            this.panel1.Controls.Add(this.txtLoginName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 277);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 342);
            this.panel1.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(883, 298);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(130, 33);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTao
            // 
            this.btnTao.Location = new System.Drawing.Point(644, 298);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(130, 33);
            this.btnTao.TabIndex = 15;
            this.btnTao.Text = "Tạo tài khoản";
            this.btnTao.UseVisualStyleBackColor = true;
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(651, 232);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(362, 30);
            this.txtConfirmPass.TabIndex = 14;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(651, 186);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(362, 30);
            this.txtPass.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(477, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "Confirm Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password:";
            // 
            // cmbUsername
            // 
            this.cmbUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gIAOVIENBindingSource, "MAGV", true));
            this.cmbUsername.DataSource = this.gIAOVIENBindingSource;
            this.cmbUsername.DisplayMember = "MAGV";
            this.cmbUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsername.FormattingEnabled = true;
            this.cmbUsername.Location = new System.Drawing.Point(651, 126);
            this.cmbUsername.Name = "cmbUsername";
            this.cmbUsername.Size = new System.Drawing.Size(362, 30);
            this.cmbUsername.TabIndex = 8;
            this.cmbUsername.ValueMember = "MAGV";
            // 
            // gIAOVIENBindingSource
            // 
            this.gIAOVIENBindingSource.DataMember = "GIAOVIEN";
            this.gIAOVIENBindingSource.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(651, 65);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(362, 30);
            this.txtLoginName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(527, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Login Name:";
            // 
            // gIAOVIENTableAdapter
            // 
            this.gIAOVIENTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.CT_BAITHITableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager.GIAOVIENTableAdapter = this.gIAOVIENTableAdapter;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TN_CSDLPT.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmTaoTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 619);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grcQuyen);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTaoTK";
            this.Text = "frmTaoTK";
            this.Load += new System.EventHandler(this.frmTaoTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcQuyen)).EndInit();
            this.grcQuyen.ResumeLayout(false);
            this.grcQuyen.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gIAOVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcQuyen;
        private System.Windows.Forms.RadioButton rdGV;
        private System.Windows.Forms.RadioButton rdCoSo;
        private System.Windows.Forms.RadioButton rdTruong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.Label label2;
        private DS dS;
        private System.Windows.Forms.BindingSource gIAOVIENBindingSource;
        private DSTableAdapters.GIAOVIENTableAdapter gIAOVIENTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbUsername;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTao;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}