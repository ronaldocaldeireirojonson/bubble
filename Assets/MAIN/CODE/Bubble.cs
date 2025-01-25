using UnityEngine;

public class Bubble : MonoBehaviour
{   
    public Vector3 targetVelocity;
    public float amplitude = .2f;
    public float frequency = 1;
    public float speed = 2;
    public float maxVelocity = 30;

    public float deceleration = 2;
    public float overlapRadius = 1;

    public LayerMask ground;
    Transform t;
    Rigidbody rb;

    void Start()
    {
        t = transform;
        rb = GetComponent<Rigidbody>();
        targetVelocity = Vector3.zero;
    }
    
    void FixedUpdate()
    {
        CheckCollision();

        Vector3 moveDir = targetVelocity * Time.deltaTime * deceleration;
        targetVelocity -= moveDir * Time.deltaTime;

        targetVelocity.x = Mathf.Clamp(targetVelocity.x, -maxVelocity, maxVelocity);
        targetVelocity.y = Mathf.Clamp(targetVelocity.y, -maxVelocity, maxVelocity);
        targetVelocity.z = Mathf.Clamp(targetVelocity.z, -maxVelocity, maxVelocity);

        rb.MovePosition(t.position + targetVelocity * Time.deltaTime * speed);
    }

    void CheckCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(t.position, overlapRadius, ground);
        foreach (Collider hit in hitColliders)
        {
            Debug.Log(hit.transform.name);
            Vector3 hitPoint = hit.ClosestPoint(t.position);
            Vector3 direction = (hitPoint - t.position).normalized;
            AddSpeed(-direction * 5);    
        }
    }

    void AddSpeed(Vector3 vel)
    {
        targetVelocity += vel;
    }
}
