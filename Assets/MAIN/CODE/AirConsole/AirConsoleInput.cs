using UnityEngine;

public class AirConsoleInput : MonoBehaviour
{
    public bool isStopped = false;

    ItemCollector item;
    Motor motor;
    Transform t;
    Hand hand;

    bool isPressing = false;

    [Header("AirnConsole")]

    private Rigidbody rigidBody;



    float horizontal = 0;
    float vertical = 0;

    //private float playerSpeed = 0.1f;
    //private float jumpForce = 350f;

    //private bool isInSphere;

    void Awake()
    {
        motor = new Motor(transform.GetComponent<CharacterController>(), transform);
        t = transform;
        item = GetComponent<ItemCollector>();
    }

    void Update()
    {
        hand = item.getHand();

        if (isPressing) hand?.Hold(t);

        motor.Move(horizontal, vertical);
    }

    public void ButtonInput(string input)
    {
        Debug.LogError(input);
        switch (input)
        {
            case "right":
                horizontal = 1;
                break;
            case "left":
                horizontal = -1;
                break;
            case "right-up":
                horizontal = 0;
                break;
            case "left-up":
                horizontal = 0;
                break;

            case "up":
                vertical = 1;
                break;
            case "down":
                vertical = -1;
                break;
            case "up-up":
                vertical = 0;
                break;
            case "down-up":
                vertical = 0;
                break;

            case "interact":
                isPressing = true;
                break;

            case "interact-up":
                isPressing = false;
                hand.Release(t);
                break;
        }
    }

    public void ButtonInput(string input, bool pressed)
    {
        //Debug.LogError(input);
        switch (input)
        {
            case "right":
                horizontal = pressed? 1:0;
                break;
            case "left":
                horizontal = pressed ? -1 : 0;
                break;

            case "up":
                vertical = pressed ? 1 : 0;
                break;
            case "down":
                vertical = pressed ? -1 : 0;
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
                }
                break;
        }
    }
}
