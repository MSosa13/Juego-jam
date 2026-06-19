using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class interactable : MonoBehaviour
{
    public int contadorInicio = 60;
    float contador;
    bool countdown = false;
    [SerializeField] GameObject flechita;

    private void Start()
    {
        contador = contadorInicio;
        flechita.SetActive(false);
    }

    void Update()
    {
        if (countdown)
        {
            contador -= Time.deltaTime;
            Debug.Log("Tiempo restante: " + contador.ToString("F1"));

            if (contador <= 0)
            {
                countdown = false;
                CompletarInteraccion();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && !countdown)
        {
            countdown = true;
            StartCoroutine(ParpadearFlechita());
        }
    }


    IEnumerator ParpadearFlechita()
    {
        float tiempo = 0f;

        while (countdown)
        {
            flechita.SetActive (true);
            tiempo += Time.deltaTime;
            float escala = 1f + Mathf.Sin(tiempo * 3f) * 0.3f; // Oscila entre 0.7 y 1.3
            flechita.transform.localScale = new Vector3(escala, escala, escala);
            yield return null;
        }
    }

    void CompletarInteraccion()
    {
        Debug.Log("¡Interacción completada!");
        flechita.SetActive(false);
        // Aquí puedes cargar escena, abrir puerta, etc.
        // SceneManager.LoadScene("NombreEscena");
    }
}