namespace steamquery
{
    partial class adduser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textbox_accountlink = new System.Windows.Forms.TextBox();
            this.label_accountlink = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textbox_accountlink
            // 
            this.textbox_accountlink.Location = new System.Drawing.Point(12, 25);
            this.textbox_accountlink.Name = "textbox_accountlink";
            this.textbox_accountlink.Size = new System.Drawing.Size(284, 20);
            this.textbox_accountlink.TabIndex = 4;
            // 
            // label_accountlink
            // 
            this.label_accountlink.AutoSize = true;
            this.label_accountlink.Location = new System.Drawing.Point(12, 9);
            this.label_accountlink.Name = "label_accountlink";
            this.label_accountlink.Size = new System.Drawing.Size(232, 13);
            this.label_accountlink.TabIndex = 5;
            this.label_accountlink.Text = "Custom URL | Full URL | SteamID3 | SteamID64";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(302, 23);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 6;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.onOkButtonClick);
            // 
            // adduser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 56);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_accountlink);
            this.Controls.Add(this.textbox_accountlink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adduser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam Query - Add User";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onClose);
            this.Load += new System.EventHandler(this.onLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textbox_accountlink;
        private System.Windows.Forms.Label label_accountlink;
        private System.Windows.Forms.Button button_ok;
    }
}

