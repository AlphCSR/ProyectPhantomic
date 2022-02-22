using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindness : MonoBehaviour
{
    public GameObject cloth;
    public char lastKey;
    public Transform playerTransform;
    public float cooldown = 0f;
    public bool active = false;
    public float range = 2.5f;

    public void Start()
    {
        cloth.SetActive(true);
    }
    public void Update()
    {
        if (cooldown > 0f)
        {
            cooldown -= 1f;
        }          
        SetCloth();
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

    public void SetCloth()
    {

        if (Input.GetKeyDown(KeyCode.R) && active == false)
        {
            if (Collision())
            {
                cloth.SetActive(true);
                if ((Input.GetKey(KeyCode.W)) || (lastKey == 'W'))
                {
                    cloth.transform.position = new Vector3(Mathf.Lerp(cloth.transform.position.x, playerTransform.position.x, Time.deltaTime * 1000),
                                                                Mathf.Lerp(cloth.transform.position.y, 0.1f, Time.deltaTime * 1000),
                                                                Mathf.Lerp(cloth.transform.position.z, playerTransform.position.z + 3f, Time.deltaTime * 1000));
                }
                else if ((Input.GetKey(KeyCode.A)) || (lastKey == 'A'))
                {
                    cloth.transform.position = new Vector3(Mathf.Lerp(cloth.transform.position.x, playerTransform.position.x - 3f, Time.deltaTime * 1000),
                                                                Mathf.Lerp(cloth.transform.position.y, 0.1f, Time.deltaTime * 1000),
                                                                Mathf.Lerp(cloth.transform.position.z, playerTransform.position.z, Time.deltaTime * 1000));
                }
                else if ((Input.GetKey(KeyCode.S)) || (lastKey == 'S'))
                {
                    cloth.transform.position = new Vector3(Mathf.Lerp(cloth.transform.position.x, playerTransform.position.x, Time.deltaTime * 1000),
                                                                Mathf.Lerp(cloth.transform.position.y, 0.1f, Time.deltaTime * 1000),
                                                                Mathf.Lerp(cloth.transform.position.z, playerTransform.position.z - 3f, Time.deltaTime * 1000));
                }
                else if ((Input.GetKey(KeyCode.D)) || (lastKey == 'D'))
                {
                    cloth.transform.position = new Vector3(Mathf.Lerp(cloth.transform.position.x, playerTransform.position.x + 3f, Time.deltaTime * 1000),
                                                                Mathf.Lerp(cloth.transform.position.y, 0.1f, Time.deltaTime * 1000),
                                                                Mathf.Lerp(cloth.transform.position.z, playerTransform.position.z, Time.deltaTime * 1000));
                }

                
                active = true;

            }

        }
        else
        { 
            
            active = false;
            cooldown = 1000f;
        }

        
    }
}
