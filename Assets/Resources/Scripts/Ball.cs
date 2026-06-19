using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] float speed;
    public bool isFlying;
    Rigidbody2D rb;

    public enum BallColor {Red, Green, Blue, Yellow, None };
    public BallColor myColor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        string n = gameObject.name;

        myColor = n switch
        {
            var s when s.Contains("Red") => BallColor.Red,
            var s when s.Contains("Blue") => BallColor.Blue,
            var s when s.Contains("Green") => BallColor.Green,
            var s when s.Contains("Yellow") => BallColor.Yellow,
            _ => BallColor.None
        };

    }
    public void Launch()
    {
        isFlying = true;
        rb.linearVelocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColliderLogic segment = collision.GetComponentInParent<ColliderLogic>();
        if (segment != null)
        {
            Debug.Log($"BALL: {this.myColor} ({gameObject.name}) | TARGET: {segment.myColor} ({collision.gameObject.name})");

            if ((int)this.myColor == (int)segment.myColor)
            {
                PlayerManager.instance.AddPoint();
            }
            else
            {
                Debug.LogError("MATCH FAILED! Resetting...");
                PlayerManager.instance.ResetGame();
            }
        }
        else Debug.LogError("Segment Null!!!");

            ResetBall();
    }

    private void OnBecameInvisible()
    {
        ResetBall();
    }

    void ResetBall()
    {
        isFlying = false;
        rb.linearVelocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}
