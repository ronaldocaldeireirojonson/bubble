using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    public GameObject prefab;

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
