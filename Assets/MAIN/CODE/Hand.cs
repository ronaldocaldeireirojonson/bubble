using UnityEngine;
using System;

[Serializable]
public class Hand
{
    public Animator anim;
    public Transform itemPivot;
    
    [SerializeField]
    GameObject currentItem;
    [SerializeField]
    Item item;

    GameObject quad;

    public void HoldItem(Item newItem)
    {
        if(item != null)
        {
            UnityEngine.Object.Destroy(item.gameObject);
            item = null;
        }

        if(newItem == null)
        {
            newItem = null;
            return;
        }

        Debug.Log(newItem.transform.name);

        item = newItem;
        item.transform.SetParent(itemPivot);
        item.transform.localPosition = Vector3.zero;
        item.transform.rotation = Quaternion.identity;

        if(quad == null){
            quad = UnityEngine.Object.Instantiate(item.quadPrefab);
        }

        item.quad = quad;
    }

    public void Hold(Transform caster)
    {
        if(item == null)
        {
            
            return;
        }

        if(anim != null)
            anim.SetBool(item.animKey, true);

        item.Hold(caster);
    }

    public void Release(Transform caster)
    {
        if(item == null)
        {
            
            return;
        }

        if(anim != null)
            anim.SetBool(item.animKey, false);

        item.Release(caster);
    }
}
