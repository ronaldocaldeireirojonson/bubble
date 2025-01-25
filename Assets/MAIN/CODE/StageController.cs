using UnityEngine;

public class StageController : MonoBehaviour
{
    public Transform[] respawns;

    int currentRespawn = 0;

    void OnEnable()
    {
        PlayerEvents.onPlayerDeath.AddListener(onPlayerDeath);
        PlayerEvents.onRespawnSet.AddListener(onRespawnSet);
    }

    void OnDisable()
    {
        PlayerEvents.onPlayerDeath.RemoveListener(onPlayerDeath);
        PlayerEvents.onRespawnSet.RemoveListener(onRespawnSet);
    }

    public void onPlayerDeath(Transform t)
    {
        Debug.Log(t.name);
        t.position = respawns[currentRespawn].position;
    }

    public void onRespawnSet(int newRespawn)
    {
        currentRespawn = newRespawn;
    }
}
