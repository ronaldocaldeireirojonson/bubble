using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool isStopped = false;

    ItemCollector item;
    Motor motor;
    Transform t;
    Hand hand;
    Animator anim;

    bool isPressingUse = false;

    void Awake()
    {
        motor = new Motor(transform.GetComponent<CharacterController>(), transform);
        anim = GetComponentInChildren<Animator>();
        t = transform;
        item = GetComponent<ItemCollector>();
    }

    void Update()
    {
        if(isStopped) return;
        
        if(Input.GetAxis("Jump") > 0)
        {
            hand = item.getHand();
            hand.anim = anim;

            if(hand != null)
            {
                hand.Hold(t);
                anim.SetBool("suck", true);
                isPressingUse = true;
            }
        } else
        {
            if(hand != null)
            {
                if(isPressingUse)
                {
                    hand.Release(t);
                    anim.SetBool("suck", false);
                    isPressingUse = false;
                }
            }
        }

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0 ,Input.GetAxisRaw("Vertical"));
        anim.SetFloat("Forward", input.magnitude);
        motor.Move(input.x, input.z);
    }
}
