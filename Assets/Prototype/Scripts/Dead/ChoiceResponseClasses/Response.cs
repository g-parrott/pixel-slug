using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Response
{
    [System.Serializable]
    public struct ResponseContent
    {
        public string _text;
        
        public AudioClip _sound;
    }
    
    public ResponseType _type;

    public ChoiceType _inResponseTo;

    public List<ResponseContent> _responses = new List<ResponseContent>(); 

    private int _currentResponse = -1;

    public ResponseContent GetNextResponse()
    {
        _currentResponse += (_currentResponse == _responses.Count) ? 0 : 1;

        return _responses[_currentResponse];
    }
}

// IDEA: Employee playing video games on the job. Thanks Jeremy