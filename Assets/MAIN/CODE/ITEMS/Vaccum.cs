using UnityEngine;

public class Vaccum : Item
{
    public GameObject quad;

    public float forwardOffset = 5;
    public float arrowVisualMultiplier = 5;
    public float suctionForce = 1;
    public float suctionStopThreashold = 1;

    public override void Hold(Transform caster)
    {
        quad.transform.rotation = caster.rotation;
        quad.transform.position = caster.position;
        quad.transform.localScale = new Vector3(1, 1, forwardOffset);
        Collider[] hitColliders = Physics.OverlapCapsule(caster.position, caster.position + caster.forward * forwardOffset, 1);

        IPushable pushable = null;

        foreach (Collider hit in hitColliders)
        {
            pushable = hit.GetComponent<IPushable>();
            if(pushable != null)
            {
                Vector3 direction = (hit.transform.position - caster.position);
                if(direction.magnitude < suctionStopThreashold)
                {
                    pushable.Stop();
                    return;
                }

                direction.y = 0;
                pushable.Push(-direction * Time.deltaTime * suctionForce);
            }
        }
    }

    public override void Release(Transform caster)
    {
        quad.transform.position = new Vector3(9999, 9999, 9999);

        Collider[] hitColliders = Physics.OverlapSphere(caster.position + caster.forward * forwardOffset, 1);
        IPushable pushable = null;

        foreach (Collider hit in hitColliders)
        {
            pushable = hit.GetComponent<IPushable>();
            if(pushable != null)
            {
                Vector3 direction = (hit.transform.position - caster.position);

                if(direction.magnitude < suctionStopThreashold)
                    pushable.Stop();
            }
        }
    }
}
