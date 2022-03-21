using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    InventoryComponent Item;
    [SerializeField]Image buttonImage;
    Sprite emptySprite;
    private void Start()
    {
        if(buttonImage == null)
        {
            buttonImage = GetComponent<Image>();
            if(buttonImage == null)
            {
                buttonImage = GetComponentInChildren<Image>();
            }
        }

        if(buttonImage == null)
        {
            Debug.LogError("Hey! " + gameObject.name + " cannot find its Image component!");
        }
        else
        {
            emptySprite = buttonImage.sprite;
        }

    }

    public bool IsEmpty()
    {
        return Item = null;
    }

    public void StoreItem(InventoryComponent newItem)
    {
        Item = newItem;
        buttonImage.sprite = Item.GetSprite();
        Item.DroppedDown();
    }


    public InventoryComponent GrabItem()
    {
        Item.PickedUp();
        buttonImage.sprite = emptySprite;
        InventoryComponent returnItem = Item;
        Item = null;
        return returnItem;
    }

}
