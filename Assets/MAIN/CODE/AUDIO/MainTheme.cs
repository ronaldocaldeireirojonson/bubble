using UnityEngine;

public class MainTheme : MonoBehaviour
{
    public AudioClip intro;
    public AudioClip theme;

    bool isTheme = false;
    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = intro;
        source.Play();
    }

    void Update()
    {
        if (!source.isPlaying && !isTheme)
        {
            isTheme = true;
            source.clip = theme;
            source.loop = true;
            source.Play();
        }
    }
}
