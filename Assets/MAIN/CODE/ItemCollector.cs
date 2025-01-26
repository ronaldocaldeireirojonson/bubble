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
            Collectable co = other.GetComponent<Collectable>();
            if(co != null)
            {
                GameObject go = UnityEngine.Object.Instantiate(other.GetComponent<Collectable>().prefab);
                go.transform.position = Vector3.zero;
                hand.HoldItem(go.GetComponent<Item>());
            }
        }
    }
}
