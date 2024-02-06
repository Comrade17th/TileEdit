using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _force;
    [SerializeField] float _repeatRate;

    private void Start() {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        bool _isShooting = true;

        while (_isShooting){
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().transform.up = direction;
            bullet.GetComponent<Rigidbody>().velocity = direction * _force;

            yield return new WaitForSeconds(_repeatRate);
        }
    }
}