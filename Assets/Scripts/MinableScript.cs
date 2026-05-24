using System;
using UnityEngine;

public class MinableScript : MonoBehaviour
{
    //All of the item this object can drop
    public GameObject[] objectsToSpawn;

    //Min and max amount of item it should spawn
    [SerializeField] int minAmount = 2;
    [SerializeField] int maxAmount = 7;

    //Objects health
    [SerializeField] int Health;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (Health <= 0)
        {
            Destroy(gameObject); 
            //Spawns a random amount of drops based on min and max
            SpawnDrops(UnityEngine.Random.Range(minAmount, maxAmount + 1));
        }
	
    }

    //Detects when the mouse clicks on this object's collider
    private void OnMouseDown()                
    {
        SpriteRenderer Sprite = gameObject.GetComponent<SpriteRenderer>();
        Health -= 10;
    }

    
    //Spawns drops when object is deleted
    void SpawnDrops(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 MoveAmount = new Vector3 (UnityEngine.Random.Range(-1.5f, 1.5f), 0f,0f);
            Vector3 SlightMove = MoveAmount + gameObject.transform.position;
            
            GameObject prefab = objectsToSpawn[UnityEngine.Random.Range(0, objectsToSpawn.Length)];
            Instantiate(prefab, SlightMove, gameObject.transform.rotation);
        }
    }
}
