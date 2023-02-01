using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    private GameObject[] _wayPoint;
    private int _wayPointIndex;
    private Vector3 _direction;
    private bool _ready;
    
    private float _speed;
    
    [SerializeField][Range(0f,5f)][Min(0f)]
    private float _distanceThreshold;

    public void SetWaypoints(GameObject[] waypoint)
    {
        _wayPoint = waypoint;
        _wayPointIndex = 0;
        _direction = _wayPoint[_wayPointIndex].transform.position;
        _ready = true;
    }

    private void Update()
    {
        if(_ready)
        {
            transform.position = Vector3.Lerp(transform.position, _direction, _speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _direction) < _distanceThreshold)
            {
                if (_wayPoint.Length - 1 > _wayPointIndex) _wayPointIndex++;
                _direction = _wayPoint[_wayPointIndex].transform.position;
            }
        }
    }

    public void SetNotReady()
    {
        _ready = false;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
