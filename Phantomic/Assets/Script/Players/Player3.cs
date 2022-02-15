using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : PlayerBase
{
    public Speed speed;
    public Blindness blindness;

    public void Start()
    {
        //Speed
        speed.walk = walk;
    }

    public void Update()
    {
        //Speed
        walk = speed.walk;
        speed.Update();
    }

}
