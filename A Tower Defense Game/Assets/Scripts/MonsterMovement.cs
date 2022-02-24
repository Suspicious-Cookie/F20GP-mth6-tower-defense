using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    public float moveSpeed = 10;
    private Transform destination;
    private int progress = 0;

    // Start is called before the first frame update
    void Start()
    {
        //I originally had this here instead of in Update() but it didn't work for some reason
        //destination = Pathfinding.wayPoints[progress];
    }

    // Update is called once per frame
    void Update()
    {
        //calculates a vector to the next waypoint and moves the monster towards it
        destination = Pathfinding.wayPoints[progress];
        Vector3 direction = destination.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, destination.position) <= 0.25)
        {
            makeProgress();
        }
    }

    //when a waypoint is reached, moves onto the next or damages the player if at the end point
    void makeProgress()
    {
        if (progress >= Pathfinding.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            GameStats.PlayerHealth--;
            GameStats.PlayerScore -= 100;
            if (GameStats.PlayerHealth <= 0)
            {
                GameStats.GameLose = true;
                //GameStats.GameOver();
            }
            return;
        }

        progress++;
        destination = Pathfinding.wayPoints[progress];
    }
}
