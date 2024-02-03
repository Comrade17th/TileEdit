using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 0.05f;
    private Vector3 _movementDirection;    
    
    private void Update(){
        if(_movementDirection != null){
            transform.Translate(_movementDirection * _movementSpeed);
        }
    }

    public void SetMoveDirection(Vector3 direction){
        Debug.Log($"Speed: {_movementSpeed} Direction: {direction} Norm: {direction.normalized}");
        _movementDirection = direction.normalized;
        
    }
}
