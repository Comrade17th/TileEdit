using UnityEngine;

namespace Lesson1{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 0.05f;

        private Vector3 _targetPosition;    
        
        private void Update(){
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed);
        }

        public void SetTargetPosition(Vector3 targetPosition){
            Debug.Log($"Target: {targetPosition}");
            _targetPosition = targetPosition;
        }
    }
}