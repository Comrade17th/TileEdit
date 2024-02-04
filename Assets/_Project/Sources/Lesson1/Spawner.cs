using System.Collections.Generic;
using UnityEngine;

namespace Lesson1{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private float _delay = 2.0f;
        [SerializeField] private float _repeatRate = 2.0f;
        [SerializeField] private List<Transform> _targets;
        [SerializeField] private List<Transform> _spawnPoints;

        private void Start(){
            InvokeRepeating(nameof(Spawn), _delay, _repeatRate);
        }

        private void Spawn(){
            Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
            Vector3 targetPosition = _targets[Random.Range(0, _targets.Count)].position;
            Enemy enemy = Instantiate(_enemyPrefab, spawnPosition, transform.rotation);
            
            enemy.SetTargetPosition(targetPosition);
        }
    }
}