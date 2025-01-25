using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents
{
    public static UnityEvent<Transform> onPlayerDeath = new UnityEvent<Transform>();
    public static UnityEvent<Transform> onBubbleDeath = new UnityEvent<Transform>();
    public static UnityEvent<int> onRespawnSet = new UnityEvent<int>();
}
