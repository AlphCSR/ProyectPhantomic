using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clone : MonoBehaviour
{
    public float cooldown = 0f;
    public float maxCooldown = 1000f;
    public bool active = false;
    public float range = 2f;
    public float distance = 1.5f;
    public GameObject clone;
    private GameObject cloneClone;

    private PlayerBase pb;
    private ChargePlayer1 ch;

    public void Start()
    {
        ch = FindObjectOfType<ChargePlayer1>();
        ch.text2.text = "Clone (R)";
    }

    public void Update()
    {
        pb = FindObjectOfType<PlayerBase>();

        //Si la abilidad es activable 
        if (cooldown == 0f)
        {
            active = true;
            Clonation();
        }
        //Si esta activa
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
        //Si es activable
        if ( (active) && (Input.GetKeyDown(KeyCode.R)) )
        {
            //Si no hay colisicion
            if (pb.Collision())
            {
                //Invoca el clone en la ultima posicion del jugador 
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
                cooldown = maxCooldown;
                cloneClone.SetActive(true);
            }
            else
            {
                //Pared
            }       
        }
        //Si no es activable se quita
        else if (!active)
        {
            cloneClone.SetActive(false);
            Destroy(cloneClone);
        }
    }
}
