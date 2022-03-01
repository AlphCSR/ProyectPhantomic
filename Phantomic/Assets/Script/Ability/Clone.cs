using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{

    // private Rigidbody playerMovementInput;

    
    private float cooldown = 0f;
    private bool active = false;
    public float range = 2f;
    public float distance = 1.5f;
    public GameObject clone;
    private GameObject cloneClone;

    private PlayerBase pb;

    public void Update()
    {
        pb = FindObjectOfType<PlayerBase>();
        if (cooldown == 0f)
        {
            active = true;
            Clonation();
        }
        else
        {
            if (cooldown == 1f)
            {
                Clonation();
            }
            cooldown -= 1f;
        }
    }


    public void Clonation()
    {
        
        if ( (active) && (Input.GetKeyDown(KeyCode.R)) )
        {
            if (pb.Collision())
            {
                if ((Input.GetKey(KeyCode.W)) || (pb.lastKey == 'W'))
                {
                    cloneClone = Instantiate(clone, new Vector3(pb.playerTransform.position.x, pb.playerTransform.position.y, pb.playerTransform.position.z + distance), pb.playerTransform.rotation);
                }
                else if ((Input.GetKey(KeyCode.A)) || (pb.lastKey == 'A'))
                {
                    cloneClone = Instantiate(clone, new Vector3(pb.playerTransform.position.x - distance, pb.playerTransform.position.y, pb.playerTransform.position.z), pb.playerTransform.rotation);
                }
                else if ((Input.GetKey(KeyCode.S)) || (pb.lastKey == 'S'))
                {
                    cloneClone = Instantiate(clone, new Vector3(pb.playerTransform.position.x, pb.playerTransform.position.y, pb.playerTransform.position.z - distance), pb.playerTransform.rotation);
                }
                else if ((Input.GetKey(KeyCode.D)) || (pb.lastKey == 'D'))
                {
                    cloneClone = Instantiate(clone, new Vector3(pb.playerTransform.position.x + distance, pb.playerTransform.position.y, pb.playerTransform.position.z), pb.playerTransform.rotation);
                }                
                active = false;
                cooldown = 1000f;
                cloneClone.SetActive(true);
            }
            else
            {
                //Pared
            }       
        }
        else if (!active)
        {
            cloneClone.SetActive(false);
            Destroy(cloneClone);
        }
    }
}
