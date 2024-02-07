using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HouseSensor : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.GetComponent<Thief>()) 
            _alarm.TurnOn();
    }

    private void OnTriggerExit(Collider collider) 
    {
        if (collider.transform.GetComponent<Thief>()) 
            _alarm.TurnOff();
    }
}
