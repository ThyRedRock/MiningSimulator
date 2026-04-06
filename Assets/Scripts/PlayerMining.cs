using UnityEngine;

public class PlayerMining : MonoBehaviour
{
    public float miningRange = 2f;
    public LayerMask oreLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Press E to mine
        {
            TryMine();
        }
    }

    void TryMine()
    {
        // Detect ore in front of player
        Collider2D ore = Physics2D.OverlapCircle(transform.position, miningRange, oreLayer);
        if (ore != null)
        {
            OreNode node = ore.GetComponent<OreNode>();
            if (node != null)
            {
                node.TakeDamage(1); // Deal 1 damage
            }
        }
    }
}
