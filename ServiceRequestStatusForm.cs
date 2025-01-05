using MetroFramework;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ServiceRequestStatusForm : Form
    {
        private readonly ServiceRequestTree serviceRequestTree;

        public MetroColorStyle Style { get; internal set; }
        public MetroThemeStyle Theme { get; internal set; }

        public ServiceRequestStatusForm(ServiceRequestTree serviceRequestTree)
        {
            InitializeComponent();
            this.serviceRequestTree = serviceRequestTree;
        }

        private void ServiceRequestStatusForm_Load(object sender, EventArgs e)
        {
            // Populate both the DataGridView and the chart when the form loads
            PopulateDataGridView();
            PopulateChart();
        }

        
        // Populates the DataGridView with all service requests.
       
        private void PopulateDataGridView()
        {
            dgvServiceRequests.Rows.Clear();

            foreach (var request in serviceRequestTree.GetAllRequests())
            {
                dgvServiceRequests.Rows.Add(
                    request.RequestId,
                    request.Location,
                    request.Category,
                    request.Status,
                    request.Description);
            }
        }

        
        private void PopulateChart()
        {
            // Clear any existing series in the chart
            chartProgress.Series.Clear();

            // Initialize counts for Pending and Completed statuses
            int pendingCount = 0;
            int completedCount = 0;

           
            foreach (var request in serviceRequestTree.GetAllRequests())
            {
                if (request.Status == "Pending") pendingCount++;
                else if (request.Status == "Completed") completedCount++;
            }

            // Create a new series for the chart
            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Service Request Status")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                IsValueShownAsLabel = true // Show values directly on the chart
            };

            
            series.Points.AddXY("Pending", pendingCount);
            series.Points.AddXY("Completed", completedCount);

           
            chartProgress.Series.Add(series);

            // Set label style to avoid overlap and improve readability
            series["PieLabelStyle"] = "Outside";

            
            chartProgress.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;

           
            chartProgress.ChartAreas[0].Area3DStyle.Enable3D = false; // Set to true for a 3D effect
            chartProgress.ChartAreas[0].BackColor = System.Drawing.Color.White;
        }

        private void dgvServiceRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
