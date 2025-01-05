public class ReportedIssue
{
    public int RequestId { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string MediaFilePath { get; set; }
    public object Status { get; set; } = "Pending"; // Default status is "Pending"
}
