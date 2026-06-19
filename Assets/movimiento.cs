using UnityEngine;

public class movimiento : MonoBehaviour
{
    public int Speed = 25;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       float horizontal = Input.GetAxisRaw("Horizontal");
       float vertical = Input.GetAxisRaw("Vertical");

       Vector2 movement = new Vector2(horizontal, vertical) * Speed * Time.deltaTime;
        rb.linearVelocity = movement;
    }
}
