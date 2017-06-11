using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = gameObject.GetComponentInChildren<Text>();
    }

    private void Update()
    {
    }

    public void SetText(StoryNode node)
    {
        _text.text = node._text;
    }
}