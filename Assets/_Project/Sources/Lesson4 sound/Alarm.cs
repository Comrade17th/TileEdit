using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Alarm : MonoBehaviour 
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private int _changesPerSecond = 10;

    [SerializeField] private float _maxSeconds = 5.0f;

    private Coroutine _coroutine;
    private float _changeRate;
    private float _secondsPerChange;
    private float _maxVolume = 1;
    private float _minVolume = 0;

    private void Start() {
        _changeRate = _maxVolume / (_maxSeconds * _changesPerSecond);
        _audioSource.volume = _minVolume;
    }

    // private void OnTriggerEnter(Collider collider)
    // {
    //     if (collider.transform.GetComponent<Thief>()) 
    //     {
    //         Debug.Log("Thief entered");
    //         _isIncreasing = true;

    //         _audioSource.Play();
    //         InvokeRepeating(nameof(ChangeVolume), _delay, _repeatRate);
    //     }
    // }

    // private void OnTriggerExit(Collider collider) 
    // {
    //     if (collider.transform.GetComponent<Thief>()) 
    //     {
    //         Debug.Log("Thief exit");
    //         _isIncreasing = false;
    //     }
    // }

    public void TurnOn(){
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void TurnOff(){
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume) 
    {
        if (_audioSource.volume > targetVolume)
            _changeRate = Mathf.Abs(_changeRate);
        else
            _changeRate = -Mathf.Abs(_changeRate);

        while (_audioSource.volume != targetVolume) 
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _changeRate);
            Debug.Log($"Volume: {_audioSource.volume}");
            yield return new WaitForSeconds(_secondsPerChange);
        }

        yield break;
    }
}
