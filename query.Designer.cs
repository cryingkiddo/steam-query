namespace steamquery {
    partial class query {
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
            this.label_serverinfo = new System.Windows.Forms.Label();
            this.textbox_serverinfo = new System.Windows.Forms.TextBox();
            this.button_refresh = new System.Windows.Forms.Button();
            this.label_players = new System.Windows.Forms.Label();
            this.listbox_players = new System.Windows.Forms.ListBox();
            this.label_score = new System.Windows.Forms.Label();
            this.label_duration = new System.Windows.Forms.Label();
            this.label_score_out = new System.Windows.Forms.Label();
            this.label_duration_out = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_serverinfo
            // 
            this.label_serverinfo.AutoSize = true;
            this.label_serverinfo.Location = new System.Drawing.Point(12, 9);
            this.label_serverinfo.Name = "label_serverinfo";
            this.label_serverinfo.Size = new System.Drawing.Size(59, 13);
            this.label_serverinfo.TabIndex = 0;
            this.label_serverinfo.Text = "Server Info";
            // 
            // textbox_serverinfo
            // 
            this.textbox_serverinfo.Location = new System.Drawing.Point(15, 25);
            this.textbox_serverinfo.Multiline = true;
            this.textbox_serverinfo.Name = "textbox_serverinfo";
            this.textbox_serverinfo.ReadOnly = true;
            this.textbox_serverinfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textbox_serverinfo.Size = new System.Drawing.Size(227, 316);
            this.textbox_serverinfo.TabIndex = 1;
            // 
            // button_refresh
            // 
            this.button_refresh.BackgroundImage = global::steamquery.Properties.Resources.refresh1;
            this.button_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_refresh.Location = new System.Drawing.Point(572, 317);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(24, 24);
            this.button_refresh.TabIndex = 22;
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.onRefreshButtonClick);
            // 
            // label_players
            // 
            this.label_players.AutoSize = true;
            this.label_players.Location = new System.Drawing.Point(248, 9);
            this.label_players.Name = "label_players";
            this.label_players.Size = new System.Drawing.Size(41, 13);
            this.label_players.TabIndex = 23;
            this.label_players.Text = "Players";
            // 
            // listbox_players
            // 
            this.listbox_players.FormattingEnabled = true;
            this.listbox_players.Location = new System.Drawing.Point(248, 25);
            this.listbox_players.Name = "listbox_players";
            this.listbox_players.Size = new System.Drawing.Size(208, 316);
            this.listbox_players.TabIndex = 24;
            this.listbox_players.SelectedIndexChanged += new System.EventHandler(this.onPlayersListBoxSelectedIndexChanged);
            // 
            // label_score
            // 
            this.label_score.AutoSize = true;
            this.label_score.Location = new System.Drawing.Point(462, 25);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(38, 13);
            this.label_score.TabIndex = 25;
            this.label_score.Text = "Score:";
            // 
            // label_duration
            // 
            this.label_duration.AutoSize = true;
            this.label_duration.Location = new System.Drawing.Point(462, 42);
            this.label_duration.Name = "label_duration";
            this.label_duration.Size = new System.Drawing.Size(50, 13);
            this.label_duration.TabIndex = 26;
            this.label_duration.Text = "Duration:";
            // 
            // label_score_out
            // 
            this.label_score_out.AutoSize = true;
            this.label_score_out.Location = new System.Drawing.Point(498, 25);
            this.label_score_out.Name = "label_score_out";
            this.label_score_out.Size = new System.Drawing.Size(0, 13);
            this.label_score_out.TabIndex = 27;
            // 
            // label_duration_out
            // 
            this.label_duration_out.AutoSize = true;
            this.label_duration_out.Location = new System.Drawing.Point(509, 42);
            this.label_duration_out.Name = "label_duration_out";
            this.label_duration_out.Size = new System.Drawing.Size(0, 13);
            this.label_duration_out.TabIndex = 28;
            // 
            // query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 351);
            this.Controls.Add(this.label_duration_out);
            this.Controls.Add(this.label_score_out);
            this.Controls.Add(this.label_duration);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.listbox_players);
            this.Controls.Add(this.label_players);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.textbox_serverinfo);
            this.Controls.Add(this.label_serverinfo);
            this.Name = "query";
            this.Text = "Steam Query - Server Query";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onClose);
            this.Load += new System.EventHandler(this.onLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_serverinfo;
        private System.Windows.Forms.TextBox textbox_serverinfo;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Label label_players;
        private System.Windows.Forms.ListBox listbox_players;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Label label_duration;
        private System.Windows.Forms.Label label_score_out;
        private System.Windows.Forms.Label label_duration_out;
    }
}