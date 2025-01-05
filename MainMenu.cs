using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainMenu : Form
    {

        private ServiceRequestTree _serviceRequestTree = new ServiceRequestTree();
        public MainMenu()
        {
            InitializeComponent();

            // Set the form to be resizable
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;

            // Assuming you have buttons like btnServiceRequestStatus, btnReportIssues, etc.
            // Set the Anchor properties for each button so they resize appropriately
            btnServiceRequestStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnReportIssues.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnEventsAnnouncements.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.btnServiceRequestStatus.Click += new System.EventHandler(this.btnServiceRequestStatus_Click);



        }



        private void btnServiceRequestStatus_Click(object sender, EventArgs e)
        {
            ServiceRequestStatusForm statusForm = new ServiceRequestStatusForm(_serviceRequestTree);
            statusForm.ShowDialog();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            // Open ReportIssuesForm and pass the tree
            ReportIssuesForm reportIssuesForm = new ReportIssuesForm(_serviceRequestTree);
            reportIssuesForm.Show();
        }

        private void btnEventsAnnouncements_Click(object sender, EventArgs e)
        {
            LocalEventsForm eventsForm = new LocalEventsForm();
            eventsForm.Show();
        }

       

        private void MainMenu_Load_1(object sender, EventArgs e)
        {

        }
    }
}
