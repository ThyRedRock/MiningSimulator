using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab; 
    public int slotCount;

    public List<GameObject> EmptySlots;
    public GameObject[] itemPrefabs;

    void Start()
    {
        for(int  i = 0; i < slotCount; i++)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel.transform);
            EmptySlots.Add(slot);
        }
    }
    public void AddItemtoInv(GameObject item)
    {
            if(EmptySlots.Count > 0)
            {
                EmptySlots[0].GetComponent<Slot>().currentItem = item;
                EmptySlots[0].GetComponent<Slot>().SpawnCurrentItem();
                EmptySlots.RemoveAt(0);
            }
    }
}
