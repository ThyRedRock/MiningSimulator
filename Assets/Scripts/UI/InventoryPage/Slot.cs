using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Slot : MonoBehaviour
{
    public GameObject currentItem; // the item currently held in this slot

    public void SpawnCurrentItem()
    {
        GameObject item = Instantiate(currentItem, gameObject.transform);
        item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}
