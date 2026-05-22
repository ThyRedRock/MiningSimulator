using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originalParent;
    CanvasGroup canvasGroup;

    Slot storedSlot;

    public GameObject gameC;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        gameC = GameObject.Find("GameController");
    }   

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // save og parent
        transform.SetParent(transform.root); //Above other canvas
        canvasGroup.blocksRaycasts = false; 
        canvasGroup.alpha = 0.6f; // semi- transparent during drag
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // follow the mouse 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; //enable raycasts
        canvasGroup.alpha = 1f; // no longer transparent

        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>(); // slot where item dropped 
        GameObject Dobject =  eventData.pointerEnter?.gameObject;
        if(dropSlot == null)
        {
            GameObject dropItem = eventData.pointerEnter;
            if(dropItem != null)
            {
                dropSlot = dropItem.GetComponentInParent<Slot>();
            }
        }
        Slot originalSlot = originalParent.GetComponent<Slot>();

        if (originalParent != null)
        {
            storedSlot = originalParent.GetComponent<Slot>();
        }
        
        
    if (dropSlot != null)
    {
        GameObject draggedItem = storedSlot.currentItem;

        if (dropSlot.currentItem != null)
        {
            // Swap items
            dropSlot.currentItem.transform.SetParent(originalSlot.transform);
            originalSlot.currentItem = dropSlot.currentItem;
            dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
        else
        {
            originalSlot.currentItem = null;
            gameC.GetComponent<InventoryController>().EmptySlots.Add(originalParent.gameObject); 
            gameC.GetComponent<InventoryController>().FilledSlots.Remove(originalParent.gameObject);
        }
        gameC.GetComponent<InventoryController>().EmptySlots.Remove(Dobject); 
        gameC.GetComponent<InventoryController>().FilledSlots.Add(Dobject);
        // Move dragged item into new slot
        transform.SetParent(dropSlot.transform);
        dropSlot.currentItem = draggedItem;
    }
        else
        {
            //no slot under drop point 
            transform.SetParent(originalParent);
        }

        GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //center
    }

}
