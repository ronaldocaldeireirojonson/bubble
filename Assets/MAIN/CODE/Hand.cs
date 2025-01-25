using UnityEngine;
using System;

[Serializable]
public class Hand
{
    public GameObject emptyHandGraphic;
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

        if(item != newItem)
        {
            Debug.Log("NEW ITEM");
            item = newItem;
            currentItem = UnityEngine.Object.Instantiate(newItem.prefab, itemPivot);
            Debug.Log(currentItem.transform.name);
        }

        if(emptyHandGraphic != null)
            emptyHandGraphic.SetActive(false);
    }

    public void Hold(Transform caster)
    {
        if(item == null)
        {
            
            return;
        }

        item.Hold(caster);
    }

    public void Release(Transform caster)
    {
        if(item == null)
        {
            
            return;
        }

        item.Release(caster);
    }
}
