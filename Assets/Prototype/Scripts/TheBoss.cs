using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

// behavior script for boss character
[RequireComponent(typeof(AudioSource))]
public class TheBoss : MonoBehaviour
{
    // represents the radius of the sphere within which the boss will interact with the player
    public float _interactionRadius = 2f;

    // represents the time between voice lines
    public float _interactionDelay = 2.5f;

    public List<AudioClip> _audioClips = new List<AudioClip>();

    private const string _playerTag = "Player";

    private float _timeSinceLastInteraction = 2.5f;

    private float _timeSinceResponseRequested = 0f;

    private bool _shouldRespond = false;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
    }

    private void Update()
    {
        _timeSinceLastInteraction += Time.deltaTime;

        if (_shouldRespond)
        {
            _timeSinceResponseRequested += Time.deltaTime;
        }

        if (_timeSinceResponseRequested > _interactionDelay)
        {
            _shouldRespond = false;
            _timeSinceLastInteraction = 0f;
            _timeSinceResponseRequested = 0f;

            _audioSource.clip = ChooseClip();
            _audioSource.Play();
        }

        // modulate the color of the boss if they are in range to talk
        if (IsPlayerInRange())
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    public void RespondToPlayer()
    {
        if (IsPlayerInRange() && !_shouldRespond && _timeSinceLastInteraction > _interactionDelay)
        {
            _shouldRespond = true;
        }
    }

    private bool IsPlayerInRange()
    {
        var overlapCast = Physics.OverlapSphere(transform.position, _interactionRadius);

        foreach (var col in overlapCast)
        {
            if (col.tag == _playerTag)
            {
                return true;
            }
        }

        return false;
    }

    private AudioClip ChooseClip()
    {
        // TODO: Make this meaningful
        return _audioClips[Random.Range(0, _audioClips.Count)];
    }
}