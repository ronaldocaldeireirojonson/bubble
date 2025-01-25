using UnityEngine;

public class BlowGun : Item
{
    public GameObject quad;
    public float overlapRadius = 1;
    public float maxForce = 5;
    public float windUpSpeed = .2f;
    public AnimationCurve curve;
    float force = 0;
    float percent = 0;

    public override void Hold(Transform caster)
    {
        percent += Time.deltaTime * windUpSpeed;
        force = curve.Evaluate(percent) * maxForce;
        force = Mathf.Min(force, maxForce);
        quad.transform.rotation = caster.rotation;
        quad.transform.position = caster.position;
        quad.transform.localScale = new Vector3(1, 1, force);
    }

    public override void Release(Transform caster)
    {
        force = Mathf.Min(force, maxForce);
        quad.transform.position = new Vector3(9999, 9999, 9999);

        Collider[] hitColliders = Physics.OverlapCapsule(caster.position, caster.position + (caster.forward * force), overlapRadius);

        IPushable pushable = null;

        foreach (Collider hit in hitColliders)
        {
            pushable = hit.GetComponent<IPushable>();
            if(pushable != null)
            {
                Vector3 direction = (hit.transform.position - caster.position).normalized;
                direction.y = 0;
                pushable.Push(direction * force);
            }
        }

        force = 0;
        percent = 0;
    }
}
