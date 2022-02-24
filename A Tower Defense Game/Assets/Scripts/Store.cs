using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    BuildMenu buildMenu;

    public TurretStats basicTurret;
    public TurretStats advancedTurret;

    // Start is called before the first frame update
    void Start()
    {
        buildMenu = BuildMenu.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void BuildBasicTurret()
    {
        //Debug.Log("Turreet");
        buildMenu.ChooseBuilding(basicTurret);
    }

    public void BuildAdvancedTurret()
    {
        //Debug.Log("Turroot");
        buildMenu.ChooseBuilding(advancedTurret);
    }


}
