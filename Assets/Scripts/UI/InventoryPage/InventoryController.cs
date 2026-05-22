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
    public List<GameObject> MatinfoList;
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
            Debug.Log("Sort");

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
                GameObject Material = Instantiate(MatInfo, SliderContent);
                Material.GetComponent<MaterialInfoScript>().Amount =+ pair.Value;
                Material.GetComponent<MaterialInfoScript>().Name = pair.Key.name;
                MatinfoList.Add(Material);
                Material.transform.Find("MatIcon").gameObject.GetComponent<Image>().sprite = pair.Key.transform.Find("ItemC").gameObject.GetComponent<Image>().sprite;
            }
        }
    }
    public void RemoveAllFilledSlots()
    {

        if (FilledSlots.Count > 0)
        {
            foreach (GameObject filled in FilledSlots)
            {
                if (filled != null)
                {
                    // Clear the item inside the slot
                    filled.GetComponent<Slot>().currentItem = null;
                    
                    for (int i = filled.transform.childCount - 1; i >= 0; i--)
                    {
                        Destroy(filled.transform.GetChild(i).gameObject);
                    }
                }
            }

            // Move all the slots over to the EmptySlots list at once
            EmptySlots.AddRange(FilledSlots);

            // wipe the FilledSlots list after the loop is finished
            FilledSlots.Clear(); 
        }
    }
    public void RemoveSpeficFilledSlots(string Objecttoremove)
    {
        
        for (int i = FilledSlots.Count - 1; i >= 0; i--)
        {
            GameObject filled = FilledSlots[i];

            if (filled != null)
            {
                // Make sure your Slot component actually has a 'myName' variable holding the item name
                if (filled.GetComponent<Slot>().currentItem != null && filled.GetComponent<Slot>().currentItem.name == Objecttoremove)
                {
                    // Clear the data inside the slot
                    filled.GetComponent<Slot>().currentItem = null;

                    // Destroy visual icon child objects if they exist
                    if (filled.transform.childCount > 0)
                    {
                        Destroy(filled.transform.GetChild(0).gameObject);
                    }

                    //  Move ONLY this specific slot from filled to empty
                    EmptySlots.Add(filled);
                    FilledSlots.RemoveAt(i); 
                }
            }
        }
    }
}
