using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public Rigidbody playerMovementInput;
    public float walk = 3f;
    public char lastKey;
    public Transform playerTransform;
    public float rangeCollision = 2.5f;
    public float rangeScare = 1f;

    public void Awake()
    {
        playerMovementInput = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
    }

    public void Update()
    {
        //Scare();
    }

    public void FixedUpdate()
    {
        Movement();
    }

    //Movimiento del personaje y guardado de la ultima posicion 
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

    //Detectar colisiones del personaje basada en la posicion actual
    public bool Collision()
    {
        RaycastHit hit;

        if (lastKey == 'W')
        {
            if (Physics.Raycast(playerTransform.position, Vector3.forward, out hit, rangeCollision))
            {
                Debug.Log("Pared");
                return false;
            }
        }
        else if (lastKey == 'A')
        {
            if (Physics.Raycast(playerTransform.position, Vector3.left, out hit, rangeCollision))
            {
                Debug.Log("Pared");
                return false;
            }
        }
        else if (lastKey == 'S')
        {
            if (Physics.Raycast(playerTransform.position, Vector3.back, out hit, rangeCollision))
            {
                Debug.Log("Pared");
                return false;
            }
        }
        else if (lastKey == 'D')
        {
            if (Physics.Raycast(playerTransform.position, Vector3.right, out hit, rangeCollision))
            {
                Debug.Log("Pared");
                return false;
            }
        }
        return true;
    }
    /*
    public void Scare()
    {
        RaycastHit hit;

        if ( Input.GetKeyDown(KeyCode.Q) )
        {
            if (lastKey == 'W') 
            {
                if (Physics.Raycast(playerTransform.position, Vector3.forward, out hit, rangeCollision, LayerMask.GetMask("Enemy")))
                {
                    hit.transform.GetComponent<Interactable>().Interact();
                }
            }
            else if (lastKey == 'A')
            {

                if (Physics.Raycast(playerTransform.position, Vector3.left, out hit, rangeCollision, LayerMask.GetMask("Enemy")))
                {
                    hit.transform.GetComponent<Interactable>().Interact();
                }
            }
            else if (lastKey == 'S')
            {
                if (Physics.Raycast(playerTransform.position, Vector3.back, out hit, rangeCollision, LayerMask.GetMask("Enemy")))
                {
                    hit.transform.GetComponent<Interactable>().Interact();
                }
            }
            else if (lastKey == 'D')
            {
                if (Physics.Raycast(playerTransform.position, Vector3.right, out hit, rangeCollision, LayerMask.GetMask("Enemy")))
                {
                    hit.transform.GetComponent<Interactable>().Interact();
                }
            }
        }  
    }
    */
}
