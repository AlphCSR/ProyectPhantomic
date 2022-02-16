using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : PlayerBase
{
    public Speed speed;
    public Blindness blindness;

    public void Start()
    {
        //Movement
        base.playerMovementInput = GetComponent<Rigidbody>();

        //Speed
        speed.walk = walk;

        //Blindness
        blindness.Start();
    }

    public void Update()
    {
        //Speed
        walk = speed.walk;
        speed.Update();

        //Blindness
        blindness.transform.position = transform.position;
        blindness.Update();
    }
}
