using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindness : MonoBehaviour
{
    public float maxCooldown = 1000f;
    public GameObject clothProyectile;
    public GameObject clothProyectileClone;
    public float cooldown = 0f;
    public float distance = 0.6f;
    public bool active = false;
    public PlayerBase pb;
    public ChargePlayer3 ch;

    public void Start()
    {
        ch = FindObjectOfType<ChargePlayer3>();
        ch.text2.text = "Blindess (R)";

    }
    public void Update()
    {
        pb = FindObjectOfType<PlayerBase>();

        if (cooldown > 0f)
        {
            cooldown -= 1f;
        }          
        SetCloth();
    }

    public void SetCloth()
    {
        if (Input.GetKeyDown(KeyCode.R) && active == false)
        {
            if (pb.Collision())
            {
                if ((Input.GetKey(KeyCode.W)) || (pb.lastKey == 'W'))
                {
                    clothProyectileClone = Instantiate(clothProyectile, new Vector3(pb.playerTransform.position.x, pb.playerTransform.position.y, pb.playerTransform.position.z + distance), pb.playerTransform.rotation);                   
                }
                else if ((Input.GetKey(KeyCode.A)) || (pb.lastKey == 'A'))
                {
                    clothProyectileClone = Instantiate(clothProyectile, new Vector3(pb.playerTransform.position.x - distance, pb.playerTransform.position.y, pb.playerTransform.position.z), pb.playerTransform.rotation);
                }
                else if ((Input.GetKey(KeyCode.S)) || (pb.lastKey == 'S'))
                {
                    clothProyectileClone = Instantiate(clothProyectile, new Vector3(pb.playerTransform.position.x, pb.playerTransform.position.y, pb.playerTransform.position.z - distance), pb.playerTransform.rotation);
                }
                else if ((Input.GetKey(KeyCode.D)) || (pb.lastKey == 'D'))
                {
                    clothProyectileClone = Instantiate(clothProyectile, new Vector3(pb.playerTransform.position.x + distance, pb.playerTransform.position.y, pb.playerTransform.position.z), pb.playerTransform.rotation);
                }
                clothProyectileClone.SetActive(true);
                active = true;
                cooldown = maxCooldown;

            }

        }
        else
        { 
            active = false;
        }
    }
}
