using UnityEngine;

namespace Lesson2{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private float _delay = 2.0f;
        [SerializeField] private float _repeatRate = 2.0f;
        [SerializeField] private Transform _target;

        private void Start(){
            InvokeRepeating(nameof(Spawn), _delay, _repeatRate);
        }

        private void Spawn(){
            Vector3 spawnPosition = transform.position;
            Enemy enemy = Instantiate(_enemyPrefab, spawnPosition, transform.rotation);
            
            enemy.SetTargetPosition(_target);
        }
    }
}