public class ServiceRequestNode
{
    public int RequestId { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }
    public string Status { get; set; }

    public ServiceRequestNode Left { get; set; }
    public ServiceRequestNode Right { get; set; }

    public ServiceRequestNode(int requestId, string location, string category, string status)
    {
        RequestId = requestId;
        Location = location;
        Category = category;
        Status = status;
    }
}
