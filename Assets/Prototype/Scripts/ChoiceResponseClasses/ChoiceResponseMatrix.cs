using System.Collections.Generic;

using UnityEngine;

public class ChoiceResponseMatrix
{
    private Dictionary<ChoiceType, Dictionary<ResponseType, float>> _matrix = new Dictionary<ChoiceType, Dictionary<ResponseType, float>>();

    public Dictionary<ResponseType, float> GetChoiceWeights(ChoiceType choice) 
    {
        return _matrix[choice];
    }

    public float GetWeight(ChoiceType choice, ResponseType response)
    {
        return _matrix[choice][response];
    }
}