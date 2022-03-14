using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    //Cooldown
    public float cooldown = 0f;
    public float maxCooldown = 1000f;
    public bool active = false;

    //Materials
    public Material Inv;
    public Material Base;
    private Renderer playerRenderer;

    private ChargePlayer1 ch;

    //Asignar render del objeto base
    public void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    public void Start()
    {
        ch = FindObjectOfType<ChargePlayer1>();
        ch.text1.text = "Invisible (E)";
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
        //Si es activable y el jugador la invoca se coloca la invivisibilidad
        if ( (active) && (Input.GetKeyDown(KeyCode.E)) )
        {
            playerRenderer.material = Inv;
            cooldown = maxCooldown;
            active = false;
        }
        //Si no es activable se quita
        else if (!active)
        {
            playerRenderer.material = Base;
        }
    }

}
