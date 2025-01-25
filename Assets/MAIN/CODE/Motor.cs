using UnityEngine;

public class Motor
{
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private Vector3 velocity;
    public float gravity = -9.81f;

    Transform t;
    Transform camera;
    CharacterController controller;

    public Motor(CharacterController _controller, Transform _t)
    {
        controller = _controller;
        t = _t;
        camera = Camera.main.transform;
    }

    public void Move(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(t.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            t.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move((moveDirection.normalized + (Vector3.up * gravity)) * speed * Time.deltaTime);
        }
    }
}
