using UnityEngine;

public class RotateMe : MonoBehaviour
{
    public float speed =2;
    
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
