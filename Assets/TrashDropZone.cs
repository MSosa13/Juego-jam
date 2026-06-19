using UnityEngine;

public class TrashDropZone : MonoBehaviour
{
    private TrashPickup trashPickup;
    private int trashDelivered = 0;
    [SerializeField] private int trashRequired = 1; // Cuántos objetos se necesitan

    private void Start()
    {
        trashPickup = FindObjectOfType<TrashPickup>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (trashPickup.IsHoldingTrash())
            {
                trashDelivered++;
                Debug.Log($"Basura entregada: {trashDelivered}/{trashRequired}");

                if (trashDelivered >= trashRequired)
                {
                    Debug.Log("¡Tarea de basura completada!");
                    // Aquí conectas con tu sistema de tareas
                }
            }
            else
            {
                Debug.Log("No estás sosteniendo nada");
            }
        }
    }
}