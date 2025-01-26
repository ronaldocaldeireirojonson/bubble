using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GetHigh : MonoBehaviour
{
    public Volume volume;
    public LensDistortion fisheye;
    public float targetDistorition = 5;
    float defaultDistortion;

    void Start()
    {
        if (volume.profile.TryGet(out fisheye))
        {
            Debug.Log("Lens Distortion found in the Volume Profile.");
        }

        defaultDistortion = fisheye.intensity.value;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (fisheye != null)
                fisheye.intensity.value = targetDistorition;  
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (fisheye != null)
                fisheye.intensity.value = defaultDistortion;   
        }
    }
}
