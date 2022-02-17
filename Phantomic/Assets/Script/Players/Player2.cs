using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : PlayerBase
{
    [SerializeField] private TeleportPoint teleportPoint;
    [SerializeField] private FireBall fireBall;

    public void Start()
    {
        //Movement
        base.playerMovementInput = GetComponent<Rigidbody>();

        //FireBall
        fireBall.playerPosition = transform;

        //TeleportPoint
        teleportPoint.Start();
    }

    public void Update()
    {
        //TeleportPoint
        teleportPoint.Update();
        transform.position = teleportPoint.playerTransform.position;

        //FireBall
        fireBall.playerPosition = transform;
        fireBall.Update();
        fireBall.lastKey = base.lastKey;
    }
}
