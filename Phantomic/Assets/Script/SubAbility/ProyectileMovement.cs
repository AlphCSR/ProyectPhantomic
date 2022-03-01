using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileMovement : MonoBehaviour
{
    protected Rigidbody playerMovementInput;

    [SerializeField] protected float speed = 1f;

    protected char lastKey;

    public void Awake()
    {
        playerMovementInput = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        MovementProyectile();
    }

    public void Start()
    {
        Key();
    }

    public void Update()
    {
        Key();
        MovementProyectile();
    }

    public void Key()
    {
        if (Input.GetKey(KeyCode.W))
        {
            lastKey = 'W';
        }
        else if (Input.GetKey(KeyCode.A))
        {
            lastKey = 'A';
        }
        else if (Input.GetKey(KeyCode.S))
        {
            lastKey = 'S';
        }
        else if (Input.GetKey(KeyCode.D))
        {
            lastKey = 'D';
        }
    }

    public void MovementProyectile()
    {
        // Movement Clone WASD
        if (Input.GetKey(KeyCode.W))
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.forward * speed * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.A))
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.left * speed * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.S))
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.back * speed * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.D))
            playerMovementInput.MovePosition(playerMovementInput.position + Vector3.right * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //FireBall
        if (other.gameObject.tag == "Block")
        {
            Destroy(this.gameObject);
        }

    }

}
