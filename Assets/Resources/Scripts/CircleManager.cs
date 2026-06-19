using UnityEngine;

public class CircleManager : MonoBehaviour
{

    [SerializeField] float baseSpeed = 50f;
    [SerializeField] float currentSpeed;
    [SerializeField] int multi;
    void OnEnable() => PlayerManager.OnScoreChanged += UpdateSpeed;
    void OnDisable() => PlayerManager.OnScoreChanged -= UpdateSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, currentSpeed *  Time.deltaTime);
    }

    void UpdateSpeed(int newScore)
    {
        currentSpeed = baseSpeed + (newScore * multi);
    }
}
