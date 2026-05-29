
using UnityEngine;

public class ShopUIScript : MonoBehaviour
{
    public GameObject InvC;
    public GameObject Content;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void OnEnable()
    {
        InvC.GetComponent<InventoryController>().Sortinv();
        InvC.GetComponent<InventoryController>().SpawnMatInfo();
    }

    void OnDisable()
    {
        Content.GetComponent<ContentScript>().DeleteChildren();
    }
}
