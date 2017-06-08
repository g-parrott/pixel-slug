using System.Collections.Generic;

using UnityEngine;

public class StoryGraph<NodeType>
{
    private List<int[]> _adjacencyLists = new List<int[]>();

    private NodeType[] _data = new NodeType[Size];

    private NodeType _current;

    public int DataIndex { get; private set; }

    public const int Size = 12;

    public StoryGraph()
    {
        SetupGraph();
    }

    public NodeType GetCurrent()
    {
        return _current;
    }

    public int GetIndex(NodeType node)
    {
        int i = 0;
        foreach (var n in _data)
        {
            if (n.Equals(node))
            {
                return i;
            }

            i += 1;
        }

        return -1;
    }

    public void SetCurrent(NodeType next)
    {
        _current = next;

        int i = 0;
        foreach (var node in _data)
        {
            if (_data.Equals(next))
            {
                DataIndex = i;
                break;
            }

            i += 1;
        }
    }

    public void SetCurrent(int index)
    {
        _current = _data[index];
        DataIndex = index;
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

    public List<NodeType> Choices()
    {
        return Choices(CurrentIndex());
    }

    public int CurrentIndex()
    {
        for (int i = 0; i < _data.Length; i += 1)
        {
            if (_data[i].Equals(_current))
            {
                return i;
            }
        }

        Debug.Log("StoryGraph Warning: In CurrentIndex(), could not find the index of the current node. Be careful");
        return -1;
    }

    public bool IsTerminal(int index)
    {
        if (index < 0 || index >= _adjacencyLists.Count)
        {
            Debug.Log("StoryGraph Warning: Calling IsTerminal() with invalid index parameter. This script will break");
            return false;
        }

        return _adjacencyLists[index] == null;
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
        _adjacencyLists.Add(new int[2]);

        // 8 connects to 10 and 12
        _adjacencyLists.Add(new int[2]);

        // 9 is a terminal node
        _adjacencyLists.Add(new int[2]);

        // 10 is a terminal node
        _adjacencyLists.Add(new int[2]);

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

        _adjacencyLists[6][0] = 1;
        _adjacencyLists[6][1] = 2;

        _adjacencyLists[7][0] = 10;
        _adjacencyLists[7][1] = 12;

        _adjacencyLists[8][0] = 2;
        _adjacencyLists[8][1] = 3;

        _adjacencyLists[9][0] = 5;
        _adjacencyLists[9][1] = 7;

        _adjacencyLists[10][0] = 2;

        _adjacencyLists[11][0] = 1;       
    }
}