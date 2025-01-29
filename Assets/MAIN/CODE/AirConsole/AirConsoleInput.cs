using UnityEngine;

public class AirConsoleInput : MonoBehaviour, IInput
{
    public bool isStopped = false;

    ItemCollector item;
    Motor motor;
    Transform t;
    Hand hand;
    Animator anim;

    bool isPressing = false;

    [Header("AirnConsole")]

    private Rigidbody rigidBody;



    float horizontal = 0;
    float vertical = 0;

    //private float playerSpeed = 0.1f;
    //private float jumpForce = 350f;

    //private bool isInSphere;

    Vector2 magnitude = Vector2.zero;

    void Awake()
    {
        motor = new Motor(transform.GetComponent<CharacterController>(), transform);
        anim = GetComponentInChildren<Animator>();
        t = transform;
        item = GetComponent<ItemCollector>();
    }

    void Update()
    {
        hand = item.getHand();
        hand.anim = anim;

        if (isPressing)
        {
            hand?.Hold(t);
            anim?.SetBool("suck", true);
        }

        magnitude.x = horizontal;
        magnitude.y = vertical;

        anim.SetFloat("Forward", magnitude.magnitude);

        motor.Move(horizontal, vertical);
    }



    public void ButtonInput(string input, bool pressed)
    {
        int direction = pressed? 1 : 0;
        //Debug.LogError(input);
        switch (input)
        {
            case "right":
                horizontal = direction;
                break;
            case "left":
                horizontal = -direction;
                break;
            case "up":
                vertical = direction;
                break;
            case "down":
                vertical = -direction;
                break;

            case "button":
                if (pressed)
                {
                    isPressing = true;
                }
                else
                {
                    isPressing = false;
                    hand?.Release(t);
                    anim.SetBool("suck", false);
                }
                break;

            case "btn_reset":
                PlayerEvents.onPlayerDeath.Invoke(transform);
                break;
        }
    }

    public void JoystickInput(Vector2 v2, bool pressed)
    {
        if (!pressed)
        {
            horizontal = 0;
            vertical = 0;
        }
        else
        {
            horizontal = v2.x;
            vertical = v2.y;
        }
    }

    public void SetStop(bool b)
    {
        isStopped = b;
    }
}
