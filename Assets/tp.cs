using UnityEngine;

public class tp : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] GameObject puntoTP;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = puntoTP.transform.position;
    }
}
