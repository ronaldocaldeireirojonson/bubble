using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents
{
    public static UnityEvent<Transform> onPlayerDeath = new UnityEvent<Transform>();
    public static UnityEvent<Transform> onBubbleDeath = new UnityEvent<Transform>();
    public static UnityEvent<int> onRespawnSet = new UnityEvent<int>();

    public static void TriggerEvent<T>(string eventString, T param)
    {
        Debug.Log(eventString);
        switch(eventString)
        {
            case "onPlayerDeath":
                onPlayerDeath.Invoke(param as Transform);
                break;
            case "onBubbleDeath":
                onPlayerDeath.Invoke(param as Transform);
                break;
            case "onRespawnSet":
                onRespawnSet.Invoke(int.Parse(param as string));
                break;
        }
    }
}
