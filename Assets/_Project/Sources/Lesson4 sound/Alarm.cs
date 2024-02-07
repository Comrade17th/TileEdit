using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Alarm : MonoBehaviour 
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField, Min(1)] private int _changesPerSecond = 10;

    [SerializeField] private float _maxSeconds = 5.0f;

    private Coroutine _coroutine;
    private float _changeRate;
    private float _secondsPerChange;
    private float _maxVolume = 1;
    private float _minVolume = 0;

    private void Start() {
        _changeRate = _maxVolume / (_maxSeconds * _changesPerSecond);
        _secondsPerChange = _maxSeconds / (_maxVolume / _changeRate);
        _audioSource.volume = _minVolume;
    }

    public void TurnOn(){
        _audioSource.Play();

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
        while (_audioSource.volume != targetVolume) 
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _changeRate);
            yield return new WaitForSeconds(_secondsPerChange);
        }

        if(_audioSource.volume == _minVolume)
            _audioSource.Stop();

        yield break;
    }
}
