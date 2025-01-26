using UnityEngine;

public class HatController : MonoBehaviour
{
    public GameObject currentHat;
    public Transform hatPivot;

    public void ChangeHat(GameObject hat)
    {
        if(currentHat != null)
            Destroy(currentHat);
        
        currentHat = Instantiate(hat, hatPivot);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("item"))
        {
            CollectHat hat = other.GetComponent<CollectHat>();

            if(hat != null)
            {
                ChangeHat(hat.prefab);
            }
        }
    }
}
