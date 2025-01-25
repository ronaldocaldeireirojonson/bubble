using UnityEngine;

public class WindZone : MonoBehaviour
{
    public float multiplier = .5f;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("bubble"))
        {   
            other.GetComponent<Bubble>().Push(transform.forward * multiplier);
        }
    }
}
