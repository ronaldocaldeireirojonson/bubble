using UnityEngine;
using System;

[Serializable]
public class Hand
{
    public GameObject emptyHandGraphic;
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
            if(emptyHandGraphic != null)
                emptyHandGraphic.SetActive(true);
            
            newItem = null;
            return;
        }

        item = newItem;
        item.transform.SetParent(itemPivot);
        item.transform.localPosition = Vector3.zero;
        item.transform.rotation = Quaternion.identity;

        if(quad == null){
            quad = UnityEngine.Object.Instantiate(item.quadPrefab);
        }

        item.quad = quad;

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
