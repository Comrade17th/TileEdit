using System.Collections.Generic;
using UnityEngine;

namespace Lesson2{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private float _delay = 10f;
        [SerializeField] private float _repeatRate = 0.5f;
        [SerializeField] private List<Transform> _moveDirections;
        [SerializeField] private List<Transform> _spawnPoints;

        private void Start(){
            InvokeRepeating(nameof(Spawn), _delay, _repeatRate);
        }

        private void Spawn(){
            Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
            Vector3 moveDirection = _moveDirections[Random.Range(0, _moveDirections.Count)].localPosition;
            Enemy enemy = Instantiate(_enemyPrefab, spawnPosition, transform.rotation);
            
            enemy.SetMoveDirection(moveDirection);
        }
    }
}