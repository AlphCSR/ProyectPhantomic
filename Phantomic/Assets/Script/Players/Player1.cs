using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : PlayerBase
{
    private Collider playerCollider;
    private Material playerMaterial;
    private Renderer playerRenderer;

    [SerializeField]private Invisible invisible;
    [SerializeField]private Clone clone;

    public void Start()
    {
        //Player
        playerCollider = GetComponent<Collider>();
        playerRenderer = GetComponent<Renderer>();
        playerMaterial = playerRenderer.material;

        //Movement
        base.playerMovementInput = GetComponent<Rigidbody>();

        //Clone
        clone.walk = base.walk;
        clone.playerTransform = transform;
        clone.Start();

        //Invisible
        invisible.Base = playerMaterial;
        invisible.playerRenderer = playerRenderer;
    }

    public void Update()
    {
        //Invisible
        invisible.Update();

        //Clone
        clone.Update();
        clone.lastKey = base.lastKey;
    }
}
