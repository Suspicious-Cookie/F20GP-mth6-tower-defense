using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float bulletVelocity = 100;
    public GameObject bleedEffect;


    public void Homing(Transform bulletTarget)
    {
        target = bulletTarget;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 trajectory = target.position - transform.position;
        
        //check if target is going to be hit this frame
        float frameSpeed = bulletVelocity * Time.deltaTime;
        if (trajectory.magnitude <= frameSpeed)
        {
            Hit();
            return;
        }

        transform.Translate(trajectory.normalized * bulletVelocity * Time.deltaTime, Space.World);

    }

    void Hit()
    {
        Instantiate(bleedEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(target.gameObject);
        GameStats.Cash += 15;
        GameStats.PlayerScore += 15;
    }
}
