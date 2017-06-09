/**
 * NarrativeController.cs
 * Author: Gabriel Parrott
 */

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

// Interface to what is essentially a graph traversal with textual/audio representation of the traversal
[RequireComponent(typeof(AudioSource))]
public class NarrativeController : MonoBehaviour
{
    // the radius in which the player may interact with an npc
    public float _interactionRadius = 5f;

    // the nodes we will add to the graph
    public List<StoryNode> _nodes = new List<StoryNode>();

    // the clips that will be used for npc harmonies
    public List<AudioClip> _responseClips = new List<AudioClip>();

    // the keys which correspond to the player traversing the graph/making sound/changing the textual representation
    public KeyCode[] _actionKeys = new KeyCode[4] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };

    // A light we will change the color of depending on the state of the graph traversal
    public Light _light;

    // the text we will change depending on the state of the graph traversal
    public Text _text;

    // the graph representation of the narrative
    private StoryGraph<StoryNode> _graph = new StoryGraph<StoryNode>();

    // utility collection to make translating keyboard input events to integers easier
    private Dictionary<KeyCode, int> _keyToIndexMap = new Dictionary<KeyCode, int>();

    // the AudioSource object we will use to play sound on a computer
    private AudioSource _audioSource;

    private void Start()
    {
        // get the AudioSource reference and setup its defaults
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
        _audioSource.playOnAwake = false;

        // grab the vertex data from the StoryNode(s) input into the editor
        int i = 0;
        foreach (var node in _nodes)
        {
            _graph.AddVertexData(node, i);
            i += 1;
        }

        // start at the beginning
        _graph.SetCurrent(0);

        _text.text = _graph.GetCurrent()._text;

        // setup the dictionary to map KeyCode(s) to integers to make it easier to translate KeyCode(s) to graph traversal actions
        _keyToIndexMap.Add(_actionKeys[0], 0);
        _keyToIndexMap.Add(_actionKeys[1], 1);
        _keyToIndexMap.Add(_actionKeys[2], 2);
        _keyToIndexMap.Add(_actionKeys[3], 3);
    }

    private void Update()
    {
        foreach (var code in _actionKeys)
        {
            if (Input.GetKeyDown(code))
            {
                // find the proper node to traverse to
                TraverseNext(code);

                // set the clip of the AudioSource to reflect the current state of the graph traversal
                UpdateClip();

                // play the player audio clip
                PlayCurrent();

                // harmonize with an npc if the player is close enough
                Harmonize();

                // set the mood ;)
                UpdateLighting();

                // say what needs to be said
                UpdateText();
            }
        }
    }

    /// <summary>
    /// Traverse to the next node in the graph, depending on the KeyCode that is passed in
    /// </summary>
    /// <param name="key">A KeyCode that determines which edge will be traversed</param>
    private void TraverseNext(KeyCode key)
    {
        int input = _keyToIndexMap[key];
        StoryNode nextNode = ChooseNext(input);
        _graph.SetCurrent(nextNode);
    }

    private void UpdateClip()
    {
        _audioSource.clip = GetClip();
    }

    private void PlayCurrent()
    {
        _audioSource.Play();
    }

    private void Harmonize()
    {
        // play the npc response to the player's decision if the player is in range of an interactable npc
        var interactableObject = GetInteractableObjectInRange();
        if (interactableObject != null)
        {
            var source = interactableObject.GetComponent<AudioSource>();

            // debugging
            if (source == null)
            {
                Debug.Log("NarrativeController Warning: In Update(); Interactable object has no AudioSource. This script will not behave as expected");
            }

            source.clip = GetResponseClip();
            source.Play();
        }
    }

    private void UpdateLighting()
    {
        var node = _graph.GetCurrent();
        _light.color += node._color * node._colorAddAmount * ((node._colorAddDirection) ? 1 : -1); 
    }

    private void UpdateText()
    {
        _text.text = _graph.GetCurrent()._text;
    }

    private GameObject GetInteractableObjectInRange()
    {
        var sphereOverlap = Physics.OverlapSphere(transform.position, _interactionRadius);

        foreach (var collider in sphereOverlap)
        {
            // please don't mind the spelling error
            if (collider.tag == "Interactable")
            {
                return collider.gameObject;
            }
        }

        return null;
    }

    private AudioClip GetClip()
    {
        return _graph.GetCurrent()._sound;
    }

    private StoryNode ChooseNext(int input)
    {
        // get the next possible nodes
        var choices = _graph.Choices();

        // if this is terminal node, return null
        if (choices == null)
        {
            return null;
        }

        // if the node has 1 outward edge, ignore the parameter and return the next one 
        if (choices.Count == 1)
        {
            return choices[0];
        }

        // if the node has more than one outward edge, return the first if input is 1 or 2, and return the second if input is 2 or 3
        if (input == 1 || input == 2)
        {
            return choices[0];
        }
        else
        {
            return choices[1];
        }
    }

    private AudioClip GetResponseClip()
    {
        // get the next possible nodes
        var choices = _graph.Choices();

        // return null if there is no way to go from here
        if (choices == null)
        {
            return null;
        }

        // the clip is randomly chosen from the list of possible ways to traverse
        var choice = choices[Random.Range(0, choices.Count)];

        // make sure we use the right instrument for the response
        return _responseClips[_graph.GetIndex(choice)];
    }
}