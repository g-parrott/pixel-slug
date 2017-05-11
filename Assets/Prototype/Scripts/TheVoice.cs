using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public struct TaggedVoiceLine
{
    public string _uid;

    public AudioClip _audioClip;

    public List<string> _tags;
}

[System.Serializable]
public struct InputAxisTagPair
{
    public string _inputAxis;

    public string _tag;
}

// ensure the GameObject this script is attached to has an AudioSource component
[RequireComponent(typeof(AudioSource))]
public class TheVoice : MonoBehaviour
{
    public List<TaggedVoiceLine> _voiceLines = new List<TaggedVoiceLine>();

    public List<InputAxisTagPair> _axisTagPairs = new List<InputAxisTagPair>();

    private Dictionary<string, string> _axisTagMap = new Dictionary<string, string>();

    private Dictionary<string, TaggedVoiceLine> _idVoiceLineMap = new Dictionary<string, TaggedVoiceLine>();

    private AudioSource _audioSource;

    // sentinel to keep track of whether audio has fired or not this frame
    private bool _played = false;

    private void Start()
    {
        // setup audio source
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;

        // make sure there's something in the _voiceLines list
        if (_voiceLines.Count == 0)
        {
            Debug.Log("TheVoice warning: There are no TaggedVoiceLine objects added to this component. This script will break");
        }

        // make sure there's something in the _axisTagPairs list
        if (_axisTagPairs.Count == 0)
        {
            Debug.Log("TheVoice warning: There are no InputAxisTagPair(s) added to this component. This script will break");
        }

        // add voice lines to dictionary
        foreach (var line in _voiceLines)
        {
            _idVoiceLineMap.Add(line._uid, line);
        }

        // add axis tag pairs to the private dictionary
        foreach (var pair in _axisTagPairs)
        {
            _axisTagMap.Add(pair._inputAxis, pair._tag);
        }
    }

    private void Update()
    {
        // find the input axis that was pressed and play a random voice line with a matching tag
        foreach (var axisTagPair in _axisTagPairs)
        {
            float axisValue = Input.GetAxis(axisTagPair._inputAxis);

            if (!Mathf.Approximately(axisValue, 0) && !_played)
            {
                _audioSource.clip = SelectAudioClipByTag(axisTagPair._tag);
                _audioSource.Play();
                _played = true;

                // let the boss respond if this GameObject is close enough
                GameObject.FindGameObjectWithTag("Boss").GetComponent<TheBoss>().RespondToPlayer();
            }
        }

        // reset the sentinel
        _played = false;
    }

    // select a random clip from the list of clips with the given tag
    private AudioClip SelectAudioClipByTag(string tag)
    {
        List<AudioClip> clipsWithTag = GetAudioClipsByTag(tag);

        int randomIndex = Random.Range(0, clipsWithTag.Count);

        return clipsWithTag[randomIndex];
    }

    private List<TaggedVoiceLine> GetVoiceLinesWithTag(string tag)
    {
        List<TaggedVoiceLine> toReturn = new List<TaggedVoiceLine>();
        foreach (var line in _voiceLines)
        {
            if (line._tags.Contains(tag))
            {
                toReturn.Add(line);
            }
        }
        return toReturn;
    }

    private List<AudioClip> GetAudioClipsByTag(string tag)
    {
        List<AudioClip> toReturn = new List<AudioClip>();
        foreach (var line in _voiceLines)
        {
            if (line._tags.Contains(tag))
            {
                toReturn.Add(line._audioClip);
            }
        }
        return toReturn;
    }

    private TaggedVoiceLine GetVoiceLineByUID(string uid)
    {
        return _idVoiceLineMap[uid];
    }

    private AudioClip GetAudioClipByUID(string uid)
    {
        return _idVoiceLineMap[uid]._audioClip;
    }
}
