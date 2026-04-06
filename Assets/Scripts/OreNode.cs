using UnityEngine;

public class OreNode : MonoBehaviour
{
    public string oreName = "Iron";
    public int oreValue = 10; // Value for selling/score
    public int health = 3;    // Hits required
    public SpriteRenderer spriteRenderer;

    // Called when player hits the rock
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Mine();
        }
    }

    void Mine()
    {
        // Add to player inventory
        PlayerInventory.instance.AddOre(oreName, oreValue);
        // Remove or replace with broken rock sprite
        Destroy(gameObject);
    }
}
