using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab; 
    public int slotCount;

    public List<GameObject> EmptySlots;
    public List<GameObject> FilledSlots;
    private Dictionary<GameObject, int> counts = new Dictionary<GameObject, int>();
    public GameObject MatInfo;
    public Transform SliderContent;
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
                FilledSlots.Add(EmptySlots[0]);
                EmptySlots[0].GetComponent<Slot>().SpawnCurrentItem();
                EmptySlots.RemoveAt(0);
            }
    }

    public void Sortinv()
    {
        //Function goes traverses Filled Slots list and find pairs each unique item with a Count value
        // Reset the count before starting
        if(FilledSlots.Count > 0)
        {
            counts.Clear();

            foreach (GameObject obj in FilledSlots)
            {
                if (obj.GetComponent<Slot>().currentItem == null) continue; // Skip missing/empty slots

                if (counts.ContainsKey(obj.GetComponent<Slot>().currentItem))
                {
                    counts[obj.GetComponent<Slot>().currentItem] += 1; // If item in invetory is already recorded does this
                }
                else
                {
                    counts[obj.GetComponent<Slot>().currentItem] = 1; // Recorded item 
                }
            }
        }

    }
    public void SpawnMatInfo()
    {
        if(FilledSlots.Count > 0)
        {
            foreach (KeyValuePair<GameObject, int> pair in counts)
            {
                Debug.Log("Item: " + pair.Key.name + " | Total: " + pair.Value);
                GameObject Material = Instantiate(MatInfo, SliderContent);
                Material.GetComponent<MaterialInfoScript>().Amount =  +pair.Value;
                Material.GetComponent<MaterialInfoScript>().Name = pair.Key.name;
                Material.transform.Find("MatIcon").gameObject.GetComponent<Image>().sprite = pair.Key.transform.Find("ItemC").gameObject.GetComponent<Image>().sprite;
            }
        }
 
    }
}
