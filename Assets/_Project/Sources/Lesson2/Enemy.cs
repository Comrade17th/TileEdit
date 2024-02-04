using UnityEngine;

namespace Lesson2{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 0.05f;

        private Transform _target;    
        
        private void Update(){
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _movementSpeed);
        }

        public void SetTargetPosition(Transform target){
            _target = target;
        }
    }
}