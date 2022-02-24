using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform currentTarget;

    public string enemyTag = "Monster";
    public Transform turretArm;
    public GameObject projectile;
    public Transform barrel;


    [Header("Turret Traits")]
    public float turretRange = 15;
    public float ROF = 1;
    private float fireDelay = 0;
    public int cost = 100;


    // Start is called before the first frame update
    void Start()
    {
        //FindTarget() invoked twice a second as opposed to every frame
        InvokeRepeating("FindTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == null)
        {
            return;
        }

        //find the aim angle, convert to euler, and rotate turret arm
        Vector3 targetDirection = currentTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
        Vector3 aimAngle = lookRotation.eulerAngles;
        turretArm.rotation = Quaternion.Euler(-90, aimAngle.y + 180, 0);

        if(fireDelay <= 0)
        {
            Shoot();
            fireDelay = 1 / ROF;
        }

        fireDelay -= Time.deltaTime;

    }

    void FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestRange = Mathf.Infinity;
        GameObject nearestTarget = null;

        //set target as closest monster
        foreach(GameObject Monster in targets)
        {
            float targetRange = Vector3.Distance(transform.position, Monster.transform.position);
            if(targetRange <= shortestRange)
            {
                shortestRange = targetRange;
                nearestTarget = Monster;
            }
        }

        //check if target is within range, set null if not
        if(nearestTarget != null && shortestRange <= turretRange)
        {
            currentTarget = nearestTarget.transform;
        }
        else
        {
            currentTarget = null;
        }
    }

    //shoot one bullet
    void Shoot()
    {
        GameObject shot = (GameObject)Instantiate(projectile, barrel.position, barrel.rotation);
        Bullet bullet = shot.GetComponent<Bullet>();
        //Debug.Log("AAAAAAAAA");
        if (bullet != null)
        {
            bullet.Homing(currentTarget);
        }
    }

    public int GetPrice()
    {
        return cost;
    }

    //making turret range visible in editor for debug
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
