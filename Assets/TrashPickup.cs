using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    private GameObject heldObject = null;
    private Transform player;
    private Vector3 offsetFromPlayer = new Vector3(0.5f, 0, 0); // Offset para que no quede en el mismo lugar

    private void Start()
    {
        player = FindObjectOfType<movimiento>().transform;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && heldObject == null)
        {
            // Agarrar el objeto si no tiene uno ya
            if (collision.CompareTag("Trash"))
            {
                heldObject = collision.gameObject;
                heldObject.GetComponent<Rigidbody2D>().isKinematic = true;
                Debug.Log("¡Agarraste la basura!");
            }
        }
    }

    private void Update()
    {
        // Si está sosteniendo algo, seguir al jugador
        if (heldObject != null)
        {
            heldObject.transform.position = player.position + offsetFromPlayer;
        }

        // Soltar con Q
        if (Input.GetKeyDown(KeyCode.Q) && heldObject != null)
        {
            DropTrash();
        }
    }

    private void DropTrash()
    {
        heldObject.GetComponent<Rigidbody2D>().isKinematic = false;
        heldObject = null;
        Debug.Log("Soltaste la basura");
    }

    public bool IsHoldingTrash()
    {
        return heldObject != null;
    }
}