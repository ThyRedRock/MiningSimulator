using UnityEngine;
using UnityEngine.InputSystem;

public class InteracNPC : MonoBehaviour
{
    [Header("Configuración")]
    public GameObject UIInteract; // Icono o UI de "Presionar E para hablar"
    
    private bool isPlayerInRange;
    private PlayerInput playerInput;
    
    private void Awake()
    {
        // Encontrar al jugador en la escena (asegúrate de que tenga el tag "Player")
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerInput = player.GetComponent<PlayerInput>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // Usa OnTriggerEnter en 3D
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (UIInteract != null) UIInteract.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // Usa OnTriggerExit en 3D
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (UIInteract != null) UIInteract.SetActive(false);
        }
    }

    // Método que llamaremos desde el Input System
    public void OnInteract(InputAction.CallbackContext context)
    {
        // El botón se ha presionado y el jugador está lo suficientemente cerca
        if (context.performed && isPlayerInRange)
        {
            InteractWithNPC();
        }
    }

    private void InteractWithNPC()
    {
        Debug.Log("¡Intercambiando palabras con el NPC!");
        // Aquí puedes iniciar tu árbol de diálogo, abrir un menú o reproducir una animación
    }
}
