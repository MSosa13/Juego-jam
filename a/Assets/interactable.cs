using Unity.VisualScripting;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public int contadorInicio = 60;
    float contador;
    bool countdown = false;

    private void Start()
    {
        contador = contadorInicio;
    }
    void Update()
    {

        if (countdown)
        {
            contador -= Time.deltaTime;
            Debug.Log("Tiempo restante: " + contador.ToString("F1"));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            {
                countdown = true;
            }
        }

    }
}

