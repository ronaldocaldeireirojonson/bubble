using UnityEngine;

public class PhysicsProp : MonoBehaviour, IPushable
{
    public float force = 200;

    public void Push(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir * force, ForceMode.Force);
    }

    public void Stop()
    {
        
    }
}
