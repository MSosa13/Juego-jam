using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class BallsController : MonoBehaviour
{
    [SerializeField] Transform ballSpawnpoint;
    [SerializeField] GameObject[] ballsPrefab;
    private List<GameObject> allBalls = new List<GameObject>();

    [SerializeField] float fireRate;
    float nextFireTime = 0f;


    GameObject ballToShoot;

    private void Awake()
    {
        foreach (var ball in ballsPrefab)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject b = Instantiate(ball);
                b.SetActive(false);
                allBalls.Add(b);
                Debug.Log("Ball added");
            }
        }


        PrepareNextBall();
    }

    public void Shoot()
    {
        if (Time.time < nextFireTime) return;

        if (ballToShoot != null && !ballToShoot.GetComponent<Ball>().isFlying)
        {
           ballToShoot.GetComponent<Ball>().Launch();
        }

        Debug.Log("Shot");

        nextFireTime = Time.time + fireRate;

        PrepareNextBall();
    }

    void PrepareNextBall()
    {
        List<GameObject> available = allBalls.FindAll(b => !b.activeSelf);
        if (available.Count > 0)
        {
            GameObject readyBall = available[Random.Range(0, available.Count)];

            readyBall.transform.position = ballSpawnpoint.position;
            readyBall.SetActive(true);
            ballToShoot = readyBall;

            ballToShoot.GetComponent<Ball>().isFlying = false;
        }
    }

    private void Update()
    {
        if (!ballToShoot.GetComponent<Ball>().isFlying) ballToShoot.transform.position = ballSpawnpoint.position;
    }
}
