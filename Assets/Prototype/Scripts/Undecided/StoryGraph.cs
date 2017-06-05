using System.Collections.Generic;

using UnityEngine;

public class StoryGraph<NodeType>
{
    private List<int[]> _adjacencyLists = new List<int[]>();

    private NodeType[] _data = new NodeType[Size];

    NodeType _current;

    public const int Size = 12;

    public StoryGraph()
    {
        SetupGraph();
    }

    public NodeType GetCurrent()
    {
        return _current;
    }

    public void SetCurrent(NodeType next)
    {
        _current = next;
    }

    public bool AddVertexData(NodeType data, int index)
    {
        if (index < 0 || index >= 12)
        {
            Debug.Log("StoryGraph warning: Calling AddVertexData() with invalid index. This script will break and this function will return false");
            return false;
        }

        _data[index] = data;

        return true;
    }

    public List<NodeType> Choices(int index)
    {
        if (index < 0 || index >= 12)
        {
            Debug.Log("StoryGraph warning: Calling Choices() with invalid index. This script will break and this function will return null");
            return null;
        }
        
        var r = new List<NodeType>();
        
        if (_adjacencyLists[index] == null)
        {
            return null;
        }
        
        foreach (var i in _adjacencyLists[index])
        {
            r.Add(_data[AsIndex(i)]);
        }
        
        return r;
    }

    private int AsIndex(int i)
    {
        return i - 1;
    }

    // setup the adjacency lists
    private void SetupGraph()
    {
         // 1 connects to 3 and 6
        _adjacencyLists.Add(new int[2]);

        // 2 connects to 4 and 9
        _adjacencyLists.Add(new int[2]);

        // 3 connects to 5
        _adjacencyLists.Add(new int[1]);

        // 4 connects to 5 and 7
        _adjacencyLists.Add(new int[2]);

        // 5 connects to 6 and 7
        _adjacencyLists.Add(new int[2]);

        // 6 connects to 8 and 11 
        _adjacencyLists.Add(new int[2]);

        // 7 is a terminal node
        _adjacencyLists.Add(null);

        // 8 connects to 10 and 12
        _adjacencyLists.Add(new int[2]);

        // 9 is a terminal node
        _adjacencyLists.Add(null);

        // 10 is a terminal node
        _adjacencyLists.Add(null);

        // 11 connects to 2
        _adjacencyLists.Add(new int[1]);
        
        // 12 connects to 1
        _adjacencyLists.Add(new int[1]);

        _adjacencyLists[0][0] = 3;
        _adjacencyLists[0][1] = 6;
        
        _adjacencyLists[1][0] = 4;
        _adjacencyLists[1][1] = 9;

        _adjacencyLists[2][0] = 5;

        _adjacencyLists[3][0] = 5;
        _adjacencyLists[3][1] = 7;

        _adjacencyLists[4][0] = 6;
        _adjacencyLists[4][1] = 7;

        _adjacencyLists[5][0] = 8;
        _adjacencyLists[5][1] = 11;

        _adjacencyLists[7][0] = 10;
        _adjacencyLists[7][1] = 12;

        _adjacencyLists[10][0] = 2;

        _adjacencyLists[11][0] = 1;       
    }
}