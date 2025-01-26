using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    Transform t;
    Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
        t.LookAt(cam.position);
    }
}
