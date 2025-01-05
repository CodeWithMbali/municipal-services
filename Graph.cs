using System.Collections.Generic;

public class Graph
{
    private Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

    public void AddEdge(int requestId, int dependentRequestId)
    {
        if (!adjacencyList.ContainsKey(requestId))
        {
            adjacencyList[requestId] = new List<int>();
        }
        adjacencyList[requestId].Add(dependentRequestId);
    }

    public List<int> GetDependencies(int requestId)
    {
        return adjacencyList.ContainsKey(requestId) ? adjacencyList[requestId] : new List<int>();
    }
}
