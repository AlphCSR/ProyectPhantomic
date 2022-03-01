using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float walk;
    public float run = 0.5f;
    public float cooldown = 0f;
    public bool active = false;
    private PlayerBase pb;

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
            cooldown = 1000f;
        }
        else if (!active)
        {
            pb.walk = (pb.walk - run);
        }
    }
}
