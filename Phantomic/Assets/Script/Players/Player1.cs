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


    public void Awake()
    {
        invisible.Awake();
    }

    public void Start()
    {
        base.playerMovementInput = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        playerRenderer = GetComponent<Renderer>();
        playerMaterial = playerRenderer.material;

        //Clone
        clone.walk = base.walk;
        clone.playerTransform = transform;
        clone.Start();

        //Invisible
        invisible.Base = playerMaterial;
        invisible.playerCollider = playerCollider;
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
