using UnityEngine;

public class RouteFollower : MonoBehaviour
{
    [SerializeField] private Transform _waypointsParent;
    [SerializeField] private float _speed = 5f;
    private Transform[] _waypoints;
    private int _currentWaypoint = 0;

    private void Start(){
        _waypoints = new Transform[_waypointsParent.childCount];

        for (int i = 0; i < _waypointsParent.childCount; i++)
            _waypoints[i] = _waypointsParent.GetChild(i).GetComponent<Transform>();
    }

    private void Update(){
        if(transform.position == _waypoints[_currentWaypoint].position){
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}
