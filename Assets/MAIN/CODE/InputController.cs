using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool isStopped = false;

    ItemCollector item;
    Motor motor;
    Transform t;
    Hand hand;

    bool isPressingUse = false;

    void Awake()
    {
        motor = new Motor(transform.GetComponent<CharacterController>(), transform);
        t = transform;
        item = GetComponent<ItemCollector>();
    }

    void Update()
    {
        if(isStopped) return;
        
        if(Input.GetAxis("Jump") > 0)
        {
            hand = item.getHand();

            if(hand != null)
            {
                hand.Hold(t);
                isPressingUse = true;
            }
        } else
        {
            if(hand != null)
            {
                if(isPressingUse)
                {
                    hand.Release(t);
                    isPressingUse = false;
                }
            }
        }

        motor.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
