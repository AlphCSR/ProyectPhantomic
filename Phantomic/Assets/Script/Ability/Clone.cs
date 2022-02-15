using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{

    // private Rigidbody playerMovementInput;

    public Rigidbody cloneMovementInput;
    public Transform playerTransform;
    public GameObject clonePlayer;
    public float cooldown = 0f;
    public bool active = false;
    public float walk;
    public char lastKey;


    public void Start()
    {
        cloneMovementInput = clonePlayer.GetComponent<Rigidbody>();
        clonePlayer.SetActive(false);
    }

    public void Update()
    {
        if (cooldown == 0f)
        {
            clonePlayer.SetActive(false);
            active = true;
            if (Input.GetKeyDown(KeyCode.R))
            {
                clonePlayer.SetActive(true);
                Clonation();
            }
        }
        else
        {
            cooldown -= 1f;
        }
    }

    public void FixedUpdate()
    {
        MovementClone();
    }

    public void MovementClone()
    {
        // Movement Clone WASD
        if (Input.GetKey(KeyCode.W))
            cloneMovementInput.MovePosition(cloneMovementInput.position + Vector3.back * walk * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.A))
            cloneMovementInput.MovePosition(cloneMovementInput.position + Vector3.right * walk * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.S))
            cloneMovementInput.MovePosition(cloneMovementInput.position + Vector3.forward * walk * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.D))
            cloneMovementInput.MovePosition(cloneMovementInput.position + Vector3.left * walk * Time.fixedDeltaTime);
    }

    /*
    public bool GolpePared()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerTransform.position, Vector3.forward, out hit, 2.5f))
        {
            if (hit.transform.tag == "Block") return true;
            else return false;
        }
        else if (Physics.Raycast(playerTransform.position, Vector3.left, out hit, 2.5f))
        {
            if (hit.transform.tag == "Block") return true;
            else return false;
        }
        else if (Physics.Raycast(playerTransform.position, Vector3.right, out hit, 2.5f))
        {
            if (hit.transform.tag == "Block") return true;
            else return false;
        }
        else if (Physics.Raycast(playerTransform.position, Vector3.back, out hit, 2.5f))
        {
            if (hit.transform.tag == "Block") return true;
            else return false;
        }
        else
            return true;
    }
    */
    public void Clonation()
    {

        if (active)
        {
            if ((Input.GetKey(KeyCode.W)) || (lastKey == 'W'))
            {
                    clonePlayer.transform.position = new Vector3(Mathf.Lerp(clonePlayer.transform.position.x, playerTransform.position.x, Time.deltaTime * 1000),
                                                              Mathf.Lerp(clonePlayer.transform.position.y, playerTransform.position.y, Time.deltaTime * 1000),
                                                              Mathf.Lerp(clonePlayer.transform.position.z, playerTransform.position.z + 1.5f, Time.deltaTime * 1000));
            }
            else if ((Input.GetKey(KeyCode.A)) || (lastKey == 'A'))
            {
                    clonePlayer.transform.position = new Vector3(Mathf.Lerp(clonePlayer.transform.position.x, playerTransform.position.x - 1.5f, Time.deltaTime * 1000),
                                                          Mathf.Lerp(clonePlayer.transform.position.y, playerTransform.position.y, Time.deltaTime * 1000),
                                                          Mathf.Lerp(clonePlayer.transform.position.z, playerTransform.position.z, Time.deltaTime * 1000));
            }
            else if ((Input.GetKey(KeyCode.S)) || (lastKey == 'S'))
            {
                    clonePlayer.transform.position = new Vector3(Mathf.Lerp(clonePlayer.transform.position.x, playerTransform.position.x, Time.deltaTime * 1000),
                                                          Mathf.Lerp(clonePlayer.transform.position.y, playerTransform.position.y, Time.deltaTime * 1000),
                                                          Mathf.Lerp(clonePlayer.transform.position.z, playerTransform.position.z - 1.5f, Time.deltaTime * 1000));
            }
            else if ((Input.GetKey(KeyCode.D)) || (lastKey == 'D'))
            {
                clonePlayer.transform.position = new Vector3(Mathf.Lerp(clonePlayer.transform.position.x, playerTransform.position.x + 1.5f, Time.deltaTime * 1000),
                                                            Mathf.Lerp(clonePlayer.transform.position.y, playerTransform.position.y, Time.deltaTime * 1000),
                                                            Mathf.Lerp(clonePlayer.transform.position.z, playerTransform.position.z, Time.deltaTime * 1000));
               
            }

            active = false;
            cooldown = 1000f;   
        }
    }
}
