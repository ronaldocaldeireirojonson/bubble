using UnityEngine;

public class BlowGun : Item
{
    public GameObject arrow;

    public Vector3 pointA;
    public Vector3 pointB;
    public Material planeMaterial;

    public float forwardOffset = 1;
    public float overlapRadius = 2;
    public float maxForce = 5;
    public float forceModifier = 1;
    public float arrowVisualMultiplier = 5;

    GameObject plane;
    float force = 0;

    public override void Hold(Transform caster)
    {
        force += Time.deltaTime;
        force = Mathf.Min(force, maxForce);
        arrow.transform.rotation = caster.rotation;
        arrow.transform.position = caster.position + caster.forward * force * arrowVisualMultiplier;
    }

    public override void Release(Transform caster)
    {
        force = Mathf.Min(force, maxForce);
        arrow.transform.position = new Vector3(9999, 9999, 9999);

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

    void DrawPlane(Vector3 a, Vector3 b)
    {
        Vector3 center = (a + b) / 2f;
        Vector3 direction = b - a;

        if(plane == null)
            plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        plane.transform.position = center;

        float distance = direction.magnitude;
        plane.transform.localScale = new Vector3(distance / 10f, 1f, 0.1f);

        if (planeMaterial != null)
        {
            plane.GetComponent<Renderer>().material = planeMaterial;
        }
    }
}
