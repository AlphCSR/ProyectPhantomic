using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player3;

    private float walk = 1.5f;

    private Rigidbody playerMovementInput;

    public TeleportPoint teleportPoint;
    public FireBall fireBall;

    public PlayerCamera playerCamera;

    public void Awake()
    {
        Destroy(player1);
        Destroy(player3);
    }

    public void Start()
    {
        playerMovementInput = GetComponent<Rigidbody>();

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
