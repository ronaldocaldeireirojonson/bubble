using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour
{
    public Transform[] respawns;
    public AudioSource source;

    int currentRespawn = 0;

    void OnEnable()
    {
        source = GetComponent<AudioSource>();
        PlayerEvents.onPlayerDeath.AddListener(onPlayerDeath);
        PlayerEvents.onRespawnSet.AddListener(onRespawnSet);
        PlayerEvents.onBubbleDeath.AddListener(onBubbleRespawn);
    }

    void OnDisable()
    {
        PlayerEvents.onPlayerDeath.RemoveListener(onPlayerDeath);
        PlayerEvents.onRespawnSet.RemoveListener(onRespawnSet);
        PlayerEvents.onBubbleDeath.RemoveListener(onBubbleRespawn);
    }

    public void PlayAudio(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void onPlayerDeath(Transform t)
    {
        StartCoroutine(handlePlayerDeath(t));
    }

    IEnumerator handlePlayerDeath(Transform t)
    {
        t.GetComponent<IInput>().SetStop(true);
        t.position = respawns[currentRespawn].position;
        yield return new WaitForSeconds(.23f);
        t.GetComponent<IInput>().SetStop(false);
    }

    public void onBubbleRespawn(Bubble bubble)
    {
        StartCoroutine(handleBubbleDeath(bubble));
    }

    IEnumerator handleBubbleDeath(Bubble bubble)
    {
        bubble.Stop();
        yield return new WaitForSeconds(.23f);
        bubble.SetPosition(respawns[currentRespawn].position);
    }

    public void onRespawnSet(int newRespawn)
    {
        currentRespawn = newRespawn;
    }
}
