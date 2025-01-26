using UnityEngine;

public class HatController : MonoBehaviour
{
    public GameObject currentHat;
    public Transform hatPivot;

    public void ChangeHat(GameObject hat)
    {
        if(currentHat != null)
            Destroy(currentHat);
        
        Instantiate(hat, hatPivot);
        currentHat = hat;
    }
}
