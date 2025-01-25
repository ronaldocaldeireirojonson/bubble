using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField]
    Hand hand;

    public Hand getHand()
    {
        return hand;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("item"))
        {
            hand.HoldItem(other.GetComponent<Item>());
        }
    }
}
