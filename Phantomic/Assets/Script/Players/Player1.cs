using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public GameObject player2;
    public GameObject player3;

    private float walk = 1.5f;

    private Rigidbody playerMovementInput;
    private Collider playerCollider;
    private Material playerMaterial;
    private Renderer playerRenderer;

    public Invisible invisible;
    public Clone clone;

    public PlayerCamera playerCamera;

    public void Awake()
    {
        invisible.Awake();
        Destroy(player2);
        Destroy(player3);
    }

    // Start is called before the first frame update
    public void Start()
    {
        playerMovementInput = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        playerRenderer = GetComponent<Renderer>();
        playerMaterial = playerRenderer.material;

        //Clone
        clone.walk = walk;
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
    }

    public void FixedUpdate()
    {
        Movement();
    }

    public void LateUpdate()
    {
        playerCamera.LateUpdate();
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.forward * walk * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.left * walk * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.back * walk * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.right * walk * Time.deltaTime);
        }
    }



}
