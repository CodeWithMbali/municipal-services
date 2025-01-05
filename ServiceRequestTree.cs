using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class ServiceRequestTree
    {
        private ServiceRequestNode root;

       
        public void AddServiceRequest(ReportedIssue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            ServiceRequestNode newNode = new ServiceRequestNode(issue.RequestId, issue.Location, issue.Category, "Pending");
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Insert(root, newNode);
            }
        }

       
        // Inserts a new node into the binary tree.
        
        private void Insert(ServiceRequestNode current, ServiceRequestNode newNode)
        {
            if (newNode.RequestId < current.RequestId)
            {
                if (current.Left == null)
                {
                    current.Left = newNode;
                }
                else
                {
                    Insert(current.Left, newNode);
                }
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = newNode;
                }
                else
                {
                    Insert(current.Right, newNode);
                }
            }
        }

        
        // Retrieves all service requests as a list.
        
        public List<ReportedIssue> GetAllRequests()
        {
            List<ReportedIssue> requests = new List<ReportedIssue>();
            TraverseTree(root, requests);
            return requests;
        }

        
        // Traverses the tree in-order and collects the reported issues.
        
        private void TraverseTree(ServiceRequestNode node, List<ReportedIssue> requests)
        {
            if (node == null) return;

            TraverseTree(node.Left, requests);

            requests.Add(new ReportedIssue
            {
                RequestId = node.RequestId,
                Location = node.Location,
                Category = node.Category,
                Description = node.Status, // Assuming status could be stored in the description.
                MediaFilePath = "" 
            });

            TraverseTree(node.Right, requests);
        }

        
        // Updates the status of a service request by request ID.
       
        public bool UpdateRequestStatus(int requestId, string newStatus)
        {
            ServiceRequestNode node = FindNodeById(root, requestId);
            if (node != null)
            {
                node.Status = newStatus;
                return true;
            }
            return false;
        }

        
        // Finds a node by its request ID.
     
        private ServiceRequestNode FindNodeById(ServiceRequestNode node, int requestId)
        {
            if (node == null) return null;

            if (node.RequestId == requestId) return node;

            return requestId < node.RequestId
                ? FindNodeById(node.Left, requestId)
                : FindNodeById(node.Right, requestId);
        }
    }

    
    // Represents a node in the service request tree.
   
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
            Left = null;
            Right = null;
        }
    }
}
