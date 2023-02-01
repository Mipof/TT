using System.Collections;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    private GameObject[] _wayPoint;
    private int _wayPointIndex;
    private bool _ready;
    
    private float _speed;
    
    [SerializeField][Range(0f,50f)][Min(0f)]
    private float _distanceThreshold;

    public void SetWaypoints(GameObject[] waypoint)
    {
        _wayPoint = waypoint;
        _wayPointIndex = 0;
        _ready = true;
        StartCoroutine(MoveToNextWaypoint());
    }

    public void SetNotReady()
    {
        _ready = false;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    IEnumerator MoveToNextWaypoint()
    {
        float distance = Vector3.Distance(transform.position, _wayPoint[_wayPointIndex].transform.position);
        while (_ready && distance > _distanceThreshold && GameManager.Instance.GameState == GameState.PLAY)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPoint[_wayPointIndex].transform.position,
                Time.deltaTime * _speed);
            distance = Vector3.Distance(transform.position, _wayPoint[_wayPointIndex].transform.position);
            yield return null;
        }

        if (_wayPointIndex < _wayPoint.Length - 1)
        {
            _wayPointIndex++;
            StartCoroutine(MoveToNextWaypoint());
        }
    }
}
