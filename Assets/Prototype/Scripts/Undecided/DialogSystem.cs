using System.Collections.Generic;

using UnityEngine;

public class DialogSystem<Choice, Response>
{
    private Dictionary<Choice, AudioClip> _choiceAudioMap = new Dictionary<Choice, AudioClip>();

    private Dictionary<Response, AudioClip> _responseAudioMap = new Dictionary<Response, AudioClip>();

    private Dictionary<Choice, Response> _choiceResponseMap = new Dictionary<Choice, Response>();

    public void AddChoiceResponsePair(Choice choice, Response response)
    {
        _choiceResponseMap.Add(choice, response);
    }

    public void AddChoiceAudioPair(Choice choice, AudioClip clip)
    {
        _choiceAudioMap.Add(choice, clip);
    }

    public void AddResponseAudioPair(Response response, AudioClip clip)
    {
        _responseAudioMap.Add(response, clip);
    }

    public Response GetResponse(Choice choice)
    {
        return _choiceResponseMap[choice];
    }

    public AudioClip GetAudioClip(Choice choice)
    {
        return _choiceAudioMap[choice];
    }

    public AudioClip GetAudioClip(Response response)
    {
        return _responseAudioMap[response];
    }
}
