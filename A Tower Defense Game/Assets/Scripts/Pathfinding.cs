using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    //making a transform array of the waypoints that is accessible to all functions
    public static Transform[] wayPoints;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = new Transform[transform.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
