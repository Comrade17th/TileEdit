using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HouseSensor : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.TryGetComponent<Thief>(out Thief thief)) 
            _alarm.TurnOn();
    }

    private void OnTriggerExit(Collider collider) 
    {
        if (collider.transform.TryGetComponent<Thief>(out Thief thief)) 
            _alarm.TurnOff();
    }
}
