using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    public float cooldown = 0f;
    public bool active = false;
    public Material Inv;
    public Material Base;
    public Renderer playerRenderer;
    public Collider playerCollider;

    public void Awake()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        if (cooldown == 0f)
        {
            active = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Invisibility();
            }  
        }
        else 
        {
            if (cooldown <= 400f)
            {
                Invisibility();
            }
            cooldown -= 1f;
        }
    }
    private void Invisibility()
    {
        if (active)
        {
            playerRenderer.material = Inv;
            cooldown = 1000f;
            active = false;
        }
        else
        {
            playerRenderer.material = Base;
        }
    }
}
