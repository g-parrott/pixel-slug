using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public struct Bounds
{
    float _xMin;

    float _yMin;

    float _xMax;

    float _yMax;
}

public enum Choice
{
    A,
    B,
    C,
    D
}

public enum SpectrumFunction
{
    MoveAway,
    MoveTowards,
    MovePerpendicularUp,
    MovePerpendicularDown
}

public class Spectrum : MonoBehaviour
{
    public Bounds _bounds;

    private Dictionary<Choice, SpectrumFunction> _choiceFunctionMap = new Dictionary<Choice, SpectrumFunction>();

    private Dictionary<GameObject, Vector2> _workerPositions = new Dictionary<GameObject, Vector2>();

    private Vector2 _playerPosition;

    private void Start()
    {
        // TODO: grab workers from scene and put them in their respective positions on the spectrum
    }

    private void Update()
    {

    }
}
