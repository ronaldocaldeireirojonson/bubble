using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class TransformEvent: UnityEvent<Transform> 
{

}

[Serializable]
public class BubbleEvent: UnityEvent<Bubble> 
{

}

public class GameEventTrigger : MonoBehaviour
{
    public TransformEvent onPlayerEnterEvent;
    public BubbleEvent onBubbleEnterEvent;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            onPlayerEnterEvent.Invoke(other.transform);

        if(other.CompareTag("bubble"))
            onBubbleEnterEvent.Invoke(other.transform.GetComponent<Bubble>());
    }
}
