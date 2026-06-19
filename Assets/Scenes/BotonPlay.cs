using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonPlay : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Juego cerrado");
    }
}