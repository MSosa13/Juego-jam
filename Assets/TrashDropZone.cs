using UnityEngine;

public class Tacho : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Basura basura = collision.GetComponent<Basura>();

        if (basura != null && basura.GetIsHeld())
        {
            // Si presiona Q estando en el tacho con basura agarrada
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Basura entregada y eliminada");
                basura.Eliminar();
            }
        }
    }
}