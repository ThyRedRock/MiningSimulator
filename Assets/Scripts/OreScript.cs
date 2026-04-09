using UnityEngine;
using System.Collections;

public class OreScript : MonoBehaviour
{
    [SerializeField] private float respawnTime = 120f; // 2 minutes (120 seconds)
    private SpriteRenderer spriteRenderer;
    private Collider2D oreCollider;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        oreCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player touched the ore
        if (other.CompareTag("Player"))
        {
            MineOre();
        }
    }

    private void MineOre()
    {
        // Disable renderer and collider to make it look broken
        spriteRenderer.enabled = false;
        oreCollider.enabled = false;

        // Start the respawn timer
        StartCoroutine(RespawnTimer());
    }

    private IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(respawnTime);

        // Re-enable the ore
        spriteRenderer.enabled = true;
        oreCollider.enabled = true;
    }
}
