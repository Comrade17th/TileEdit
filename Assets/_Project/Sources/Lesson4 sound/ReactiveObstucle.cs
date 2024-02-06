using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ReactiveObstacle : MonoBehaviour{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private bool _isOncePlayable;

    private bool _onceEntered;

    private void OnTriggerEnter(){
        Debug.Log("Entered");

        if(_isOncePlayable){
            if(_onceEntered == false){
                _onceEntered = true;
                _audioSource.Play();
            }
        } 
        else{
            _audioSource.Play();
        }
    }
}
