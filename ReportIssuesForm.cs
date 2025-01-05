using MetroFramework;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        private ServiceRequestTree _serviceRequestTree;
        private string selectedFilePath = string.Empty;

        public ReportIssuesForm(ServiceRequestTree serviceRequestTree)
        {
            InitializeComponent();
            _serviceRequestTree = serviceRequestTree;
        }

        public MetroColorStyle Style { get; internal set; }
        public MetroThemeStyle Theme { get; internal set; }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            ofdAttachMedia.Filter = "Image Files|*.jpg;*.jpeg;*.png|Document Files|*.pdf;*.docx";
            if (ofdAttachMedia.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = ofdAttachMedia.FileName;
                MessageBox.Show("File attached: " + selectedFilePath);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLocation.Text) || string.IsNullOrEmpty(rtbDescription.Text) || cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            ReportedIssue issue = new ReportedIssue
            {
                RequestId = new Random().Next(1000, 9999),
                Location = txtLocation.Text,
                Category = cmbCategory.SelectedItem.ToString(),
                Description = rtbDescription.Text,
                MediaFilePath = selectedFilePath
            };

            _serviceRequestTree.AddServiceRequest(issue);

            MessageBox.Show("Issue reported successfully!");
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            selectedFilePath = string.Empty;
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }

    public class ReportedIssue
    {
        public int RequestId { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MediaFilePath { get; set; }
        public object Status { get; set; } = "Pending"; // Default status is "Pending"
    }

}
