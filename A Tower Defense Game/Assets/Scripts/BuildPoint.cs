using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPoint : MonoBehaviour
{

    public Color hoverHighlight;
    private Renderer hoverRender;
    private Color baseColour;

    public GameObject turret;

    BuildMenu buildMenu;


    // Start is called before the first frame update
    void Start()
    {
        hoverRender = GetComponent<Renderer>();
        baseColour = hoverRender.material.color;
        buildMenu = BuildMenu.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if (buildMenu.ReturnBuilding() == null)
        {
            return;
        }
        hoverRender.material.color = hoverHighlight;
    }

    void OnMouseExit()
    {
        hoverRender.material.color = baseColour;
    }

    void OnMouseDown()
    {
        if (buildMenu.ReturnBuilding() == null)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Turret Present");
            return;
        }

        buildMenu.PlaceTurret(this);
    }
}
