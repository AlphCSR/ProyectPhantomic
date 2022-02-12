using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float walk;
    public float run = 3f;
    public float cooldown = 0f;
    public bool active = false;

    public void Update()
    {
        if (cooldown == 0f)
        {
            active = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                SpeedWalk();
            }
        }
        else
        {
            if (cooldown == 700f)
            {
                SpeedWalk();
            }
            cooldown -= 1f;
        }
    }

    public void SpeedWalk()
    {
        if (active)
        {
            walk = (walk + run);
            active = false;
            cooldown = 1000f;
        }
        else
        {
           walk = (walk - run);
        }
    }
}
