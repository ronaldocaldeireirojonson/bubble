using UnityEngine;

public class Bubble : MonoBehaviour, IPushable
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
            Vector3 hitPoint = hit.ClosestPoint(t.position);
            Vector3 direction = Vector3.Cross(targetVelocity, hitPoint);
            targetVelocity = Vector3.zero;
            Debug.DrawLine(hitPoint, hitPoint + direction, Color.red);
            AddSpeed(direction);
        }
    }

    public void Stop()
    {
        targetVelocity = Vector3.zero;
    }

    public void SetPosition(Vector3 pos)
    {
        t.position = new Vector3(pos.x, t.position.y, pos.z);
    }

    public void Teleport(Transform point)
    {
        targetVelocity = Vector3.zero;
        t.position = point.position + point.forward * 2.5f;
        AddSpeed(point.forward);
    }

    public void Push(Vector3 dir)
    {
        AddSpeed(dir);
    }

    void AddSpeed(Vector3 vel)
    {
        vel.y = Mathf.Min(vel.y, 0);
        targetVelocity += vel;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ground"))
        {
            PlayerEvents.onBubbleDeath.Invoke(this);
        }
    }
}
