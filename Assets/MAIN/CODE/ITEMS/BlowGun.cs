using UnityEngine;

public class BlowGun : Item
{
    public float forwardOffset = 1;
    public float overlapRadius = 2;
    public float maxForce = 5;
    public float forceModifier = 1;
    
    float force = 0;

    public override void Hold(Transform caster)
    {
        force += Time.deltaTime;
    }

    public override void Release(Transform caster)
    {
        force = Mathf.Min(force, maxForce);

        Collider[] hitColliders = Physics.OverlapSphere(caster.position + caster.forward * forwardOffset, overlapRadius);
        IPushable pushable = null;

        foreach (Collider hit in hitColliders)
        {
            pushable = hit.GetComponent<IPushable>();
            if(pushable != null)
            {
                Vector3 direction = (hit.transform.position - caster.position);
                direction.y = 0;
                pushable.Push(direction * forceModifier * force);
            }
        }

        force = 0;
    }
}
