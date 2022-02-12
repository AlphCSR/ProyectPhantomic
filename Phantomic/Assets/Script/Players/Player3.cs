using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    public GameObject player2;
    public GameObject player1;

    private float walk = 1.5f;

    private Rigidbody playerMovementInput;

    public Speed speed;
    public Blindness blindness;

    public PlayerCamera playerCamera;

    public void Awake()
    {
        Destroy(player2);
        Destroy(player1);
    }

    public void Start()
    {
        playerMovementInput = GetComponent<Rigidbody>();

        //Speed
        speed.walk = walk;
    }

    public void Update()
    {
        //Speed
        walk = speed.walk;
        speed.Update();
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
