namespace _1611030057付成杰
{
    partial class frm_passwd_modify
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
            this.txt_new_passwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_old_passwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_new_passwd
            // 
            this.txt_new_passwd.Location = new System.Drawing.Point(175, 104);
            this.txt_new_passwd.Name = "txt_new_passwd";
            this.txt_new_passwd.Size = new System.Drawing.Size(234, 25);
            this.txt_new_passwd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入新密码";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(66, 167);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(131, 47);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确认";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.Btn_ok_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(251, 167);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(131, 47);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "取消";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.Btn_exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "请输入旧密码";
            // 
            // txt_old_passwd
            // 
            this.txt_old_passwd.Location = new System.Drawing.Point(175, 45);
            this.txt_old_passwd.Name = "txt_old_passwd";
            this.txt_old_passwd.Size = new System.Drawing.Size(234, 25);
            this.txt_old_passwd.TabIndex = 5;
            // 
            // frm_passwd_modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 253);
            this.Controls.Add(this.txt_old_passwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_new_passwd);
            this.Name = "frm_passwd_modify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.frm_passwd_modify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_new_passwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_old_passwd;
    }
}