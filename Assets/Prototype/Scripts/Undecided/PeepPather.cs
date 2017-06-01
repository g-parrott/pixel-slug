using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

// Given a list of GameObject(s), uses the NavMeshAgent attached
// to this GameObject to path between the given list of GameObject(s)
// in order of their position within the list
[RequireComponent(typeof(NavMeshAgent))]
public class PeepPather : MonoBehaviour
{
    // the list of destinations to cycle between
    public List<GameObject> _toPathTo = new List<GameObject>();

    // the distance within which the agent will wait until moving to the  next destination
    public float _acceptableDistance = 0.25f;

    // time to spend waiting in seconds
    public float _timeToWaitAtDestination = 1f;

    // timer used to control how long until the agent moves
    // to the next destination
    private float _timeWaiting = 0;

    // used to keep track of which destination we are currently going towards
    private int _destinationIndex = 0;

    // reference to the NavMeshAgent component
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // check if we're close enough to start counting the time unitl we leave
        if (IsInAcceptableDistance())
        {
            _timeWaiting += Time.deltaTime;
        }

        // check if we've waiting long enough
        if (_timeWaiting >= _timeToWaitAtDestination)
        {
            // increment destination index with looparound
            _destinationIndex = (_destinationIndex == _toPathTo.Count - 1) ? 0 : _destinationIndex + 1;
            
            // set the next destination
            _agent.SetDestination(_toPathTo[_destinationIndex].transform.position);

            // reset the timer
            _timeWaiting = 0;
        }
    }

    // compute the distance from the agent to the destination and determine if
    // the agent is within a certain distance of the destination 
    private bool IsInAcceptableDistance()
    {
        var distance = Vector3.Distance(transform.position, _agent.destination);
        return distance <= _acceptableDistance;
    }
}