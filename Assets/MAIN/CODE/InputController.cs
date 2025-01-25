using UnityEngine;

public class InputController : MonoBehaviour
{
    Motor motor;

    void Awake()
    {
        motor = new Motor(transform.GetComponent<CharacterController>(), transform);
    }

    void Update()
    {
        motor.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
