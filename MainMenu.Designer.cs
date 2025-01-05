namespace MunicipalServicesApp
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnReportIssues = new System.Windows.Forms.Button();
            this.btnEventsAnnouncements = new System.Windows.Forms.Button();
            this.btnServiceRequestStatus = new System.Windows.Forms.Button();
            this.lblMainMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReportIssues
            // 
            this.btnReportIssues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReportIssues.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportIssues.ForeColor = System.Drawing.Color.White;
            this.btnReportIssues.Location = new System.Drawing.Point(253, 171);
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.Padding = new System.Windows.Forms.Padding(5);
            this.btnReportIssues.Size = new System.Drawing.Size(487, 60);
            this.btnReportIssues.TabIndex = 0;
            this.btnReportIssues.Text = "Report Issues";
            this.btnReportIssues.UseVisualStyleBackColor = false;
            this.btnReportIssues.Click += new System.EventHandler(this.btnReportIssues_Click);
            // 
            // btnEventsAnnouncements
            // 
            this.btnEventsAnnouncements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEventsAnnouncements.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEventsAnnouncements.ForeColor = System.Drawing.Color.White;
            this.btnEventsAnnouncements.Location = new System.Drawing.Point(253, 258);
            this.btnEventsAnnouncements.Name = "btnEventsAnnouncements";
            this.btnEventsAnnouncements.Padding = new System.Windows.Forms.Padding(5);
            this.btnEventsAnnouncements.Size = new System.Drawing.Size(487, 60);
            this.btnEventsAnnouncements.TabIndex = 1;
            this.btnEventsAnnouncements.Text = "Local Events and Announcements";
            this.btnEventsAnnouncements.UseVisualStyleBackColor = false;
            this.btnEventsAnnouncements.Click += new System.EventHandler(this.btnEventsAnnouncements_Click);
            // 
            // btnServiceRequestStatus
            // 
            this.btnServiceRequestStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnServiceRequestStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServiceRequestStatus.ForeColor = System.Drawing.Color.White;
            this.btnServiceRequestStatus.Location = new System.Drawing.Point(253, 343);
            this.btnServiceRequestStatus.Name = "btnServiceRequestStatus";
            this.btnServiceRequestStatus.Padding = new System.Windows.Forms.Padding(5);
            this.btnServiceRequestStatus.Size = new System.Drawing.Size(487, 57);
            this.btnServiceRequestStatus.TabIndex = 2;
            this.btnServiceRequestStatus.Text = "Service Request Status";
            this.btnServiceRequestStatus.UseVisualStyleBackColor = false;
            this.btnServiceRequestStatus.Click += new System.EventHandler(this.btnServiceRequestStatus_Click);
            // 
            // lblMainMenu
            // 
            this.lblMainMenu.BackColor = System.Drawing.SystemColors.MenuText;
            this.lblMainMenu.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainMenu.ForeColor = System.Drawing.Color.White;
            this.lblMainMenu.Location = new System.Drawing.Point(127, 44);
            this.lblMainMenu.Name = "lblMainMenu";
            this.lblMainMenu.Size = new System.Drawing.Size(707, 68);
            this.lblMainMenu.TabIndex = 3;
            this.lblMainMenu.Text = "Municipal Services Main Menu";
            this.lblMainMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1133, 520);
            this.Controls.Add(this.lblMainMenu);
            this.Controls.Add(this.btnServiceRequestStatus);
            this.Controls.Add(this.btnEventsAnnouncements);
            this.Controls.Add(this.btnReportIssues);
            this.Name = "MainMenu";
            this.Text = " ";
            this.Load += new System.EventHandler(this.MainMenu_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReportIssues;
        private System.Windows.Forms.Button btnEventsAnnouncements;
        private System.Windows.Forms.Button btnServiceRequestStatus;
        private System.Windows.Forms.Label lblMainMenu;
    }
}

