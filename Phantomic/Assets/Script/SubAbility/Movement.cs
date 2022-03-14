using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected Rigidbody playerMovementInput;

    [SerializeField] protected float walk = 1.5f;

    protected char lastKey;

    public void Awake()
    {
        playerMovementInput = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        MovementClone();
    }

    public void LateUpdate()
    {
    }

    public void MovementClone()
    {
        //Movimiento inverso del Clone 
        if (Input.GetKey(KeyCode.W))
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.back * walk * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.A))
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.right * walk * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.S))
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.forward * walk * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.D))
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.left * walk * Time.fixedDeltaTime);
    }
    
}
