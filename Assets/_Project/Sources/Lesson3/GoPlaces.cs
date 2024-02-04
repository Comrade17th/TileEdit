using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pointsParent;

    private Transform[] _points;
    private int _currentPoint = 0;

    private void Start() {
        _points = new Transform[_pointsParent.childCount];

        for (int i = 0; i < _pointsParent.childCount; i++)
            _points[i] = _pointsParent.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform point = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position , point.position, _speed * Time.deltaTime);

        if (transform.position == point.position)  
            NextPointTakerLogic();
    }

    public Vector3 NextPointTakerLogic(){
        _currentPoint++;

        if (_currentPoint == _points.Length)
            _currentPoint = 0;

        // useless block?
        Vector3 thisPointVector = _points[_currentPoint].transform.position;
        transform.forward = thisPointVector - transform.position;

        return thisPointVector;   
    }
}