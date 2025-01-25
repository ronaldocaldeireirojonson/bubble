using UnityEngine;
using System.Collections;

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
        StartCoroutine(handlePlayerDeath(t));
    }

    IEnumerator handlePlayerDeath(Transform t)
    {
        t.GetComponent<InputController>().isStopped = true;
        t.position = respawns[currentRespawn].position;
        yield return new WaitForSeconds(1);
        t.GetComponent<InputController>().isStopped = false;
    }

    public void onRespawnSet(int newRespawn)
    {
        currentRespawn = newRespawn;
    }
}
