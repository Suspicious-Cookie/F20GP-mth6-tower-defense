using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    private TurretStats selection;

    //making the sinbgle buidMenu available to all points
    public static BuildMenu instance;

    public GameObject basicTurret;
    public GameObject advancedTurret;

    // Had to change this from start to awake or I was getting null pointer exceptions when selecting turrets
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TurretStats ReturnBuilding()
    {
        return selection;
    }

    public void ChooseBuilding(TurretStats turret)
    {
        selection = turret;
    }

    public void PlaceTurret(BuildPoint point)
    {
        if (GameStats.Cash < selection.price)
        {
            return;
        }
        GameStats.Cash -= selection.price;
        GameStats.PlayerScore -= selection.price / 2;
        GameObject turret = (GameObject)Instantiate(selection.model, point.transform.position, point.transform.rotation);
    }
}
