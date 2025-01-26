using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FmodPlayMenuMusic : MonoBehaviour
{
    EventInstance coolAudioEventInstance;

    const string coolAudioReferenceString = "event:/musics/menu_music";


    void Start()
    {

        coolAudioEventInstance = RuntimeManager.CreateInstance(coolAudioReferenceString);
        coolAudioEventInstance.start();
    }


    private void OnDestroy()
    {
        coolAudioEventInstance.release();
    }

}
