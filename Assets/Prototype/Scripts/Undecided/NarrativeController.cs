using System.Collections.Generic;

using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    public List<StoryNode> _nodes = new List<StoryNode>();

    private StoryGraph<StoryNode> _graph = new StoryGraph<StoryNode>();

    private GameObject _speechBubble;

    private GameObject _audioSystem;

    private void Start()
    {
        int i = 0;
        foreach (var node in _nodes)
        {
            _graph.AddVertexData(node, i);
            i += 1;
        }
    }

    private void Update()
    {
    }
}