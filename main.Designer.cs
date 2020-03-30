namespace steamquery {
    partial class main {
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
            this.listbox_users = new System.Windows.Forms.ListBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.label_users = new System.Windows.Forms.Label();
            this.label_steamname = new System.Windows.Forms.Label();
            this.label_steamid64 = new System.Windows.Forms.Label();
            this.label_privacy = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.label_gamename = new System.Windows.Forms.Label();
            this.label_gameserverip = new System.Windows.Forms.Label();
            this.label_steamname_out = new System.Windows.Forms.Label();
            this.label_steamid64_out = new System.Windows.Forms.Label();
            this.label_privacy_out = new System.Windows.Forms.Label();
            this.label_status_out = new System.Windows.Forms.Label();
            this.label_gamename_out = new System.Windows.Forms.Label();
            this.label_gameserverip_out = new System.Windows.Forms.Label();
            this.label_steamname_out2 = new System.Windows.Forms.Label();
            this.label_gamename_out2 = new System.Windows.Forms.Label();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_queryinfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listbox_users
            // 
            this.listbox_users.FormattingEnabled = true;
            this.listbox_users.Location = new System.Drawing.Point(12, 25);
            this.listbox_users.Name = "listbox_users";
            this.listbox_users.Size = new System.Drawing.Size(217, 199);
            this.listbox_users.TabIndex = 0;
            this.listbox_users.SelectedIndexChanged += new System.EventHandler(this.onUsersListBoxSelectedIndexChanged);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(12, 230);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(104, 23);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.onAddButtonClick);
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(125, 230);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(104, 23);
            this.button_remove.TabIndex = 2;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.onRemoveButtonClick);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(125, 259);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(104, 23);
            this.button_load.TabIndex = 4;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.onLoadButtonClick);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(12, 259);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(104, 23);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.onSaveButtonClick);
            // 
            // label_users
            // 
            this.label_users.AutoSize = true;
            this.label_users.Location = new System.Drawing.Point(12, 9);
            this.label_users.Name = "label_users";
            this.label_users.Size = new System.Drawing.Size(34, 13);
            this.label_users.TabIndex = 5;
            this.label_users.Text = "Users";
            // 
            // label_steamname
            // 
            this.label_steamname.AutoSize = true;
            this.label_steamname.Location = new System.Drawing.Point(235, 25);
            this.label_steamname.Name = "label_steamname";
            this.label_steamname.Size = new System.Drawing.Size(71, 13);
            this.label_steamname.TabIndex = 6;
            this.label_steamname.Text = "Steam Name:";
            // 
            // label_steamid64
            // 
            this.label_steamid64.AutoSize = true;
            this.label_steamid64.Location = new System.Drawing.Point(235, 42);
            this.label_steamid64.Name = "label_steamid64";
            this.label_steamid64.Size = new System.Drawing.Size(63, 13);
            this.label_steamid64.TabIndex = 7;
            this.label_steamid64.Text = "SteamID64:";
            // 
            // label_privacy
            // 
            this.label_privacy.AutoSize = true;
            this.label_privacy.Location = new System.Drawing.Point(235, 59);
            this.label_privacy.Name = "label_privacy";
            this.label_privacy.Size = new System.Drawing.Size(88, 13);
            this.label_privacy.TabIndex = 8;
            this.label_privacy.Text = "Account Privacy:";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(235, 76);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(40, 13);
            this.label_status.TabIndex = 9;
            this.label_status.Text = "Status:";
            // 
            // label_gamename
            // 
            this.label_gamename.AutoSize = true;
            this.label_gamename.Location = new System.Drawing.Point(235, 93);
            this.label_gamename.Name = "label_gamename";
            this.label_gamename.Size = new System.Drawing.Size(38, 13);
            this.label_gamename.TabIndex = 10;
            this.label_gamename.Text = "Game:";
            // 
            // label_gameserverip
            // 
            this.label_gameserverip.AutoSize = true;
            this.label_gameserverip.Location = new System.Drawing.Point(235, 110);
            this.label_gameserverip.Name = "label_gameserverip";
            this.label_gameserverip.Size = new System.Drawing.Size(85, 13);
            this.label_gameserverip.TabIndex = 11;
            this.label_gameserverip.Text = "Game Server IP:";
            // 
            // label_steamname_out
            // 
            this.label_steamname_out.AutoSize = true;
            this.label_steamname_out.Location = new System.Drawing.Point(304, 25);
            this.label_steamname_out.Name = "label_steamname_out";
            this.label_steamname_out.Size = new System.Drawing.Size(0, 13);
            this.label_steamname_out.TabIndex = 12;
            // 
            // label_steamid64_out
            // 
            this.label_steamid64_out.AutoSize = true;
            this.label_steamid64_out.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_steamid64_out.Location = new System.Drawing.Point(296, 42);
            this.label_steamid64_out.Name = "label_steamid64_out";
            this.label_steamid64_out.Size = new System.Drawing.Size(0, 13);
            this.label_steamid64_out.TabIndex = 13;
            this.label_steamid64_out.Click += new System.EventHandler(this.onLabelSteamID64Click);
            // 
            // label_privacy_out
            // 
            this.label_privacy_out.AutoSize = true;
            this.label_privacy_out.Location = new System.Drawing.Point(321, 59);
            this.label_privacy_out.Name = "label_privacy_out";
            this.label_privacy_out.Size = new System.Drawing.Size(0, 13);
            this.label_privacy_out.TabIndex = 14;
            // 
            // label_status_out
            // 
            this.label_status_out.AutoSize = true;
            this.label_status_out.Location = new System.Drawing.Point(273, 76);
            this.label_status_out.Name = "label_status_out";
            this.label_status_out.Size = new System.Drawing.Size(0, 13);
            this.label_status_out.TabIndex = 15;
            // 
            // label_gamename_out
            // 
            this.label_gamename_out.AutoSize = true;
            this.label_gamename_out.Location = new System.Drawing.Point(271, 93);
            this.label_gamename_out.Name = "label_gamename_out";
            this.label_gamename_out.Size = new System.Drawing.Size(0, 13);
            this.label_gamename_out.TabIndex = 16;
            // 
            // label_gameserverip_out
            // 
            this.label_gameserverip_out.AutoSize = true;
            this.label_gameserverip_out.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_gameserverip_out.Location = new System.Drawing.Point(318, 110);
            this.label_gameserverip_out.Name = "label_gameserverip_out";
            this.label_gameserverip_out.Size = new System.Drawing.Size(0, 13);
            this.label_gameserverip_out.TabIndex = 17;
            this.label_gameserverip_out.Click += new System.EventHandler(this.onLabelGameServerIPClick);
            // 
            // label_steamname_out2
            // 
            this.label_steamname_out2.AutoSize = true;
            this.label_steamname_out2.Location = new System.Drawing.Point(235, 42);
            this.label_steamname_out2.Name = "label_steamname_out2";
            this.label_steamname_out2.Size = new System.Drawing.Size(0, 13);
            this.label_steamname_out2.TabIndex = 19;
            // 
            // label_gamename_out2
            // 
            this.label_gamename_out2.AutoSize = true;
            this.label_gamename_out2.Location = new System.Drawing.Point(235, 110);
            this.label_gamename_out2.Name = "label_gamename_out2";
            this.label_gamename_out2.Size = new System.Drawing.Size(0, 13);
            this.label_gamename_out2.TabIndex = 20;
            // 
            // button_refresh
            // 
            this.button_refresh.BackgroundImage = global::steamquery.Properties.Resources.refresh1;
            this.button_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_refresh.Location = new System.Drawing.Point(450, 259);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(24, 24);
            this.button_refresh.TabIndex = 21;
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.onRefreshButtonClick);
            // 
            // button_queryinfo
            // 
            this.button_queryinfo.Location = new System.Drawing.Point(235, 135);
            this.button_queryinfo.Name = "button_queryinfo";
            this.button_queryinfo.Size = new System.Drawing.Size(135, 23);
            this.button_queryinfo.TabIndex = 22;
            this.button_queryinfo.Text = "Query Info";
            this.button_queryinfo.UseVisualStyleBackColor = true;
            this.button_queryinfo.Click += new System.EventHandler(this.onQueryInfoButtonClick);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 291);
            this.Controls.Add(this.button_queryinfo);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.label_gamename_out2);
            this.Controls.Add(this.label_steamname_out2);
            this.Controls.Add(this.label_gameserverip_out);
            this.Controls.Add(this.label_gamename_out);
            this.Controls.Add(this.label_status_out);
            this.Controls.Add(this.label_privacy_out);
            this.Controls.Add(this.label_steamid64_out);
            this.Controls.Add(this.label_steamname_out);
            this.Controls.Add(this.label_gameserverip);
            this.Controls.Add(this.label_gamename);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label_privacy);
            this.Controls.Add(this.label_steamid64);
            this.Controls.Add(this.label_steamname);
            this.Controls.Add(this.label_users);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.listbox_users);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam Query";
            this.Load += new System.EventHandler(this.onLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_users;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label_users;
        private System.Windows.Forms.Label label_steamname;
        private System.Windows.Forms.Label label_steamid64;
        private System.Windows.Forms.Label label_privacy;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label_gamename;
        private System.Windows.Forms.Label label_gameserverip;
        private System.Windows.Forms.Label label_steamname_out;
        private System.Windows.Forms.Label label_steamid64_out;
        private System.Windows.Forms.Label label_privacy_out;
        private System.Windows.Forms.Label label_status_out;
        private System.Windows.Forms.Label label_gamename_out;
        private System.Windows.Forms.Label label_gameserverip_out;
        private System.Windows.Forms.Label label_steamname_out2;
        private System.Windows.Forms.Label label_gamename_out2;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_queryinfo;
    }
}