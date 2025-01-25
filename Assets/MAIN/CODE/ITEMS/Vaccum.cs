using UnityEngine;

public class Vaccum : Item
{
    public GameObject arrow;

    public float forwardOffset = 1;
    public float overlapRadius = 2;
    public float maxForce = 5;
    public float forceModifier = 1;
    public float arrowVisualMultiplier = 5;
    public float suctionForce = 1;
    public float suctionStopThreashold = 1;
    public Vector3 boxRange;

    public override void Hold(Transform caster)
    {
        arrow.transform.rotation = caster.rotation;
        arrow.transform.position = caster.position + caster.forward * 2;
        Collider[] hitColliders = Physics.OverlapBox(caster.position + caster.forward * forwardOffset, boxRange, Quaternion.identity);
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
        arrow.transform.position = new Vector3(9999, 9999, 9999);

        Collider[] hitColliders = Physics.OverlapSphere(caster.position + caster.forward * forwardOffset, overlapRadius);
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
