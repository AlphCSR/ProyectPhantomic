using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float maxCooldown = 1000f;
    public float walk;
    public float run = 0.5f;
    public float cooldown = 0f;
    public bool active = false;
    private PlayerBase pb;
    private ChargePlayer3 ch;

    public void Start()
    {
        ch = FindObjectOfType<ChargePlayer3>();
        ch.text1.text = "Speed (E)";
    }

    public void Update()
    {
        pb = FindObjectOfType<PlayerBase>();
        

        if (cooldown == 0f)
        {
            active = true;
            
            {
                SpeedWalk();
            }
        }
        else
        {
            if (cooldown == 1f)
            {
                SpeedWalk();
            }
            cooldown -= 1f;
        }
    }

    public void SpeedWalk()
    {
        if ( (active) && (Input.GetKeyDown(KeyCode.E)) )
        {
            pb.walk = (pb.walk + run);
            active = false;
            cooldown = maxCooldown;
        }
        else if (!active)
        {
            pb.walk = (pb.walk - run);
        }
    }
}
