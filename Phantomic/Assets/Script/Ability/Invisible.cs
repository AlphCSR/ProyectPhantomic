using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    //Cooldown
    private float cooldown = 0f;
    private bool active = false;

    //Materials
    public Material Inv;
    public Material Base;
    private Renderer playerRenderer;

    //Asignar render del objeto base
    public void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    public void Update()
    {
        //Si la abilidad es activable 
        if (cooldown == 0f)
        {
            active = true;
            Invisibility(); 
        }

        //Si esta activa
        else 
        {
            //Desactivar invisibilidad
            if (cooldown == 1f)
            {
                Invisibility();
            }
            cooldown -= 1f;
        }
    }
    private void Invisibility()
    {
        //Si es activable y el jugador la invoca
        if ( (active) && (Input.GetKeyDown(KeyCode.E)) )
        {
            playerRenderer.material = Inv;
            cooldown = 1000f;
            active = false;
        }
        //Si no es activable
        else if (!active)
        {
            playerRenderer.material = Base;
        }
    }
}
