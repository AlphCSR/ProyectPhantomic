using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    protected Rigidbody playerMovementInput;

    [SerializeField] protected float walk = 1.5f;
    [SerializeField] private PlayerCamera playerCamera;

    protected char lastKey; 

    // Start is called before the first frame update

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
            lastKey = 'W';
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.left * walk * Time.deltaTime);
            lastKey = 'A';
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.back * walk * Time.deltaTime);
            lastKey = 'S';
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.right * walk * Time.deltaTime);
            lastKey = 'D';
        }
    }

}
