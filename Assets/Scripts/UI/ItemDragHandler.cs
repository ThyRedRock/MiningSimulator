using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //This is the object that is first clicked during the drag
    private Transform originalParent;

    private CanvasGroup canvasGroup;
    private Canvas canvas;

    //this is the GameController Object
    private GameObject gameC;

    void Start()
    {
        //Gets or create CanvasGroup
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // Find main canvas
        canvas = FindFirstObjectByType<Canvas>();

        // Find inventory controller object
        gameC = GameObject.Find("GameController");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Saves original slot
        originalParent = transform.parent;

        // checks if canvas isnt nothing
        if (canvas != null)
        {
            //Move item being dragged to top canvas 
            transform.SetParent(canvas.transform, true);
        }

        //Allow raycasts to pass through item
        canvasGroup.blocksRaycasts = false;

        //Makes the item being dragged slightly transparent 
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Gets the mouses position
        transform.position = eventData.position;
    }

    //this is after the drag is over
    public void OnEndDrag(PointerEventData eventData)
    {
        //changes the transparency back and makes it block raycast
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        //creates the drop slot script (This is the script of the slot that the item is being dropped on)
        Slot dropSlot = null;

        //Detects slot under mouse
        if (eventData.pointerEnter != null)
        {   
            //gets if script and sets it to dropslot
            dropSlot = eventData.pointerEnter.GetComponent<Slot>();

            //If mouse is over child object
            if (dropSlot == null)
            {
                dropSlot = eventData.pointerEnter.GetComponentInParent<Slot>();
            }
        }

        // Gets the Original slots script
        Slot originalSlot = originalParent.GetComponent<Slot>();

        //ensures the item being dropped isnt nothing
        if (dropSlot != null)
        {
            //stores the Item being dropped
            GameObject draggedItem = gameObject;

            //Checkes if Slot already occupied -> swap
            if (dropSlot.currentItem != null)
            {
                GameObject targetItem = dropSlot.currentItem;

                //Moves target item back
                targetItem.transform.SetParent(originalParent, false);

                //Centers item
                RectTransform targetRect = targetItem.GetComponent<RectTransform>();
                if (targetRect != null)
                {
                    targetRect.anchoredPosition = Vector2.zero;
                }

                //Changes orignal slot to the slot being dropped
                originalSlot.currentItem = targetItem;
            }
            else
            {
                //Original slot becomes empty
                originalSlot.currentItem = null;

                InventoryController inv = gameC.GetComponent<InventoryController>();

                //Update inventory lists
                inv.EmptySlots.Add(originalParent.gameObject);
                inv.FilledSlots.Remove(originalParent.gameObject);
            }

            InventoryController inventory = gameC.GetComponent<InventoryController>();

            //Update inventory lists
            inventory.EmptySlots.Remove(dropSlot.gameObject);
            if (!inventory.FilledSlots.Contains(dropSlot.gameObject))
            {
                inventory.FilledSlots.Add(dropSlot.gameObject);
            }

            //Moves dragged item into new slot
            transform.SetParent(dropSlot.transform, false);

            //Centers dragged item
            RectTransform rect = GetComponent<RectTransform>();
            if (rect != null)
            {
                rect.anchoredPosition = Vector2.zero;
            }

            //Updates slot reference
            dropSlot.currentItem = draggedItem;
        }
        else
        {
            //Invalid drop -> return to original slot
            transform.SetParent(originalParent, false);
            
            //Centers dragged item
            RectTransform rect = GetComponent<RectTransform>();
            if (rect != null)
            {
                rect.anchoredPosition = Vector2.zero;
            }
        }
    }
}