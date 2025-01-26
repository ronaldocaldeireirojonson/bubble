using UnityEngine;
using System;

[Serializable]
public class Hand
{
    public GameObject emptyHandGraphic;
    public Animator anim;
    public Transform itemPivot;
    
    GameObject currentItem;
    Item item;

    public void HoldItem(Item newItem)
    {
        if(currentItem != null)
        {
            UnityEngine.Object.Destroy(currentItem);
            currentItem = null;
        }

        if(newItem == null)
        {
            if(emptyHandGraphic != null)
                emptyHandGraphic.SetActive(true);
            
            newItem = null;
            return;
        }

        item = newItem;
        currentItem = UnityEngine.Object.Instantiate(newItem.prefab, itemPivot);

        if(emptyHandGraphic != null)
        emptyHandGraphic.SetActive(false);
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
