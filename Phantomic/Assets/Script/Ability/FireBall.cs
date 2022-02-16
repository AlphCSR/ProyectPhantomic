using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float range = 4f;
    public Transform playerPosition;


    public void Start()
    {
    
    } 

    public void Update()
    {
        ProyectilDirection();
    }

    public void ProyectilDirection()
    {
        RaycastHit hit;


        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (Physics.Raycast(playerPosition.position, Vector3.forward, out hit, range))
                {

                    if (hit.collider.tag == "Enemy")
                    {
                        Destroy(GameObject.FindGameObjectWithTag(hit.collider.tag), 2f);
                    }

                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (Physics.Raycast(playerPosition.position, Vector3.left, out hit, range))
                {

                    if (hit.collider.tag == "Enemy")
                    {
                        Destroy(GameObject.FindGameObjectWithTag(hit.collider.tag), 2f);
                    }

                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (Physics.Raycast(playerPosition.position, Vector3.back, out hit, range))
                {

                    if (hit.collider.tag == "Enemy")
                    {
                        Destroy(GameObject.FindGameObjectWithTag(hit.collider.tag), 2f);
                    }

                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (Physics.Raycast(playerPosition.position, Vector3.right, out hit, range))
                {

                    if (hit.collider.tag == "Enemy")
                    {
                        Destroy(GameObject.FindGameObjectWithTag(hit.collider.tag), 2f);
                    }
                }
            }

        }
    }

}
