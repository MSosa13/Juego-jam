using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static System.Action<int> OnScoreChanged;
    [SerializeField] public int score;
    [SerializeField] BallsController balls;
    [SerializeField] TextMeshProUGUI tmp;

    public static PlayerManager instance;

    private void Awake()
    {
        if (instance == null) { instance = this; } else Destroy(gameObject);
        tmp.text = score.ToString();
    }

    public void AddPoint()
    {
        score++;
        tmp.text = score.ToString();
        OnScoreChanged?.Invoke(score);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) { balls.Shoot(); }
    }
    public void ResetGame()
    {
        // Reloads the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
