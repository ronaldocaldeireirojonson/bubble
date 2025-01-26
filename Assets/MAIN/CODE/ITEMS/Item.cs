using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    public GameObject quadPrefab;
    public GameObject quad;

    public virtual void Setup()
    {

    }
    
    public virtual void Hold(Transform caster)
    {
    }

    public virtual void Release(Transform caster)
    {
    }
}
