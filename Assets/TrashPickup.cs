using UnityEngine;

public class Basura : MonoBehaviour
{
    private Transform player;
    private bool isHeld = false;
    private Rigidbody2D rb;
    private Vector3 holdOffset = new Vector3(0.5f, 0, 0);
    private bool inTrashZone = false;

    private void Start()
    {
        player = FindObjectOfType<movimiento>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isHeld && player != null)
        {
            transform.position = player.position + holdOffset;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Agarrar con E (solo si no estás en el tacho)
            if (Input.GetKeyDown(KeyCode.E) && !isHeld && !inTrashZone)
            {
                isHeld = true;
                rb.isKinematic = true;
                Debug.Log("Agarraste la basura");
            }

            // Soltar con Q (solo si NO estás en el tacho)
            if (Input.GetKeyDown(KeyCode.Q) && isHeld && !inTrashZone)
            {
                isHeld = false;
                rb.isKinematic = false;
                Debug.Log("Soltaste la basura");
            }
        }

        // Detectar si está en el tacho
        if (collision.CompareTag("Tacho"))
        {
            inTrashZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tacho"))
        {
            inTrashZone = false;
        }
    }

    public bool GetIsHeld()
    {
        return isHeld;
    }

    public void Eliminar()
    {
        Destroy(gameObject);
    }
}