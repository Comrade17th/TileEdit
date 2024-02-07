using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ReactiveObstacle : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private bool _isOncePlayable;

    private bool _isOnceEntered;

    private void OnTriggerEnter()
    {
        Debug.Log("Entered");

        if(_isOncePlayable){
            if(_isOnceEntered == false)
            {
                _isOnceEntered = true;
                _audioSource.Play();
            }
        } 
        else
        {
            _audioSource.Play();
        }
    }
}
