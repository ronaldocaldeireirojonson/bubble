using UnityEngine;
using UnityEngine.Events;

public class GameEventTrigger : MonoBehaviour
{
    public UnityEvent<Transform> onPlayerEnterEvent;
    public UnityEvent onBubbleEnterEvent;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            onPlayerEnterEvent.Invoke(other.transform);

        if(other.CompareTag("bubble"))
            onBubbleEnterEvent.Invoke();
    }
}
