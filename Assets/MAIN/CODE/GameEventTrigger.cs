using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class CustomEvent: UnityEvent<Transform> 
{

}

public class GameEventTrigger : MonoBehaviour
{
    public CustomEvent onPlayerEnterEvent;
    public UnityEvent onBubbleEnterEvent;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            onPlayerEnterEvent.Invoke(other.transform);

        if(other.CompareTag("bubble"))
            onBubbleEnterEvent.Invoke();
    }
}
