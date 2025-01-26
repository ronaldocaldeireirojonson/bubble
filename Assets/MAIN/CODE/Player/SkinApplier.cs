using UnityEngine;

public class SkinApplier : MonoBehaviour
{
    public SkinnedMeshRenderer render;

    public void ApplyMaterial(Material mat)
    {
        render.material = mat;
    }
}
