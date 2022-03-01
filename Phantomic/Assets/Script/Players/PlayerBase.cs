using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public Rigidbody playerMovementInput;
    public float walk = 3f;
    public char lastKey;
    public Transform playerTransform;
    public float range = 2.5f;

    public void Awake()
    {
        playerMovementInput = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
    }

    public void FixedUpdate()
    {
        Movement();
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

    public bool Collision()
    {
        RaycastHit hit;

        if (lastKey == 'W')
        {
            if (Physics.Raycast(playerTransform.position, Vector3.forward, out hit, range))
            {
                if (hit.collider.tag == "Block")
                {
                    Debug.Log("Pared");
                    return false;
                }
            }
        }
        else if (lastKey == 'A')
        {
            if (Physics.Raycast(playerTransform.position, Vector3.left, out hit, range))
            {
                if (hit.collider.tag == "Block")
                {
                    Debug.Log("Pared");
                    return false;
                }
            }
        }
        else if (lastKey == 'S')
        {
            if (Physics.Raycast(playerTransform.position, Vector3.back, out hit, range))
            {
                if (hit.collider.tag == "Block")
                {
                    Debug.Log("Pared");
                    return false;
                }
            }
        }
        else if (lastKey == 'D')
        {
            if (Physics.Raycast(playerTransform.position, Vector3.right, out hit, range))
            {
                if (hit.collider.tag == "Block")
                {
                    Debug.Log("Pared");
                    return false;
                }
            }
        }
        return true;
    }
}
