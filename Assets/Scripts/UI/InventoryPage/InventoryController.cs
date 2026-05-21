using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

        counts.Clear(); // Reset the count before starting
        
        foreach (GameObject obj in FilledSlots)
        {
            if (obj.GetComponent<Slot>().currentItem == null) continue; // Skip missing/empty slots

            if (counts.ContainsKey(obj.GetComponent<Slot>().currentItem))
            {
                counts[obj.GetComponent<Slot>().currentItem] += 1; // Add 1 to the existing count
            }
            else
            {
                counts[obj.GetComponent<Slot>().currentItem] = 1; // First time seeing this item
            }
        }

        // 4. Print the final counts to the Unity Console
        foreach (KeyValuePair<GameObject, int> pair in counts)
        {
            Debug.Log("Item: " + pair.Key.name + " | Total: " + pair.Value);
            Instantiate(MatInfo, SliderContent);
        }
    }
}
