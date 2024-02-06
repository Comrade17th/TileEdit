using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _changeRate = 0.1f;
    [SerializeField] private float _repeatRate = 1.0f;

    private bool _isIncreasing;
    private float _maxVolume = 1;
    private float _minVolume = 0;
    private float _delay = 0;

    private void Start(){
        _audioSource.volume = _minVolume;
    }

    private void OnTriggerEnter(Collider collider){
        if(collider.transform.GetComponent<Thief>()){
            Debug.Log("Thief entered");
            _isIncreasing = true;
            
            _audioSource.Play();
            InvokeRepeating(nameof(ChangeVolume), _delay, _repeatRate);
        }
    }

    private void OnTriggerExit(Collider collider){
        if(collider.transform.GetComponent<Thief>()){
            Debug.Log("Thief exit");
            _isIncreasing = false;
        }
    }

   private void ChangeVolume(){
        if(_isIncreasing){
            Debug.Log($"Increase");
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _changeRate * Time.deltaTime);
        }
        else{
            Debug.Log($"Decrease");
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _changeRate * -1f * Time.deltaTime);
        }

        if(_audioSource.volume == 0)
                _audioSource.Stop();

        Debug.Log($"Volume: {_audioSource.volume}");
   }
}
