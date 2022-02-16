using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    public GameObject TeleportSpawn;
    public Transform playerTransform;
    public float cooldown = 0f;
    public bool active = false;
    public float range = 2f;

    public void Start()
    {
        TeleportSpawn.SetActive(false);
    }

    public void Update()
    {
        if (cooldown > 0f)
        {
            cooldown -= 1f;
        }
        SetTeleport();
    }

    void SetTeleport() 
    {
        if (Input.GetKeyDown(KeyCode.E) && active == false)
        {
            TeleportSpawn.transform.position = new Vector3(Mathf.Lerp(TeleportSpawn.transform.position.x, playerTransform.position.x, Time.deltaTime * 1000),
                                                            Mathf.Lerp(TeleportSpawn.transform.position.y, 0.1f, Time.deltaTime * 1000),
                                                            Mathf.Lerp(TeleportSpawn.transform.position.z, playerTransform.position.z, Time.deltaTime * 1000));

            TeleportSpawn.SetActive(true);
            active = true;
    
        }
        else if (Input.GetKeyDown(KeyCode.E) && active == true)
        {
            playerTransform.position = new Vector3( Mathf.Lerp(playerTransform.position.x, TeleportSpawn.transform.position.x, Time.deltaTime * 1000),
                                                    Mathf.Lerp(playerTransform.position.y, playerTransform.position.y, Time.deltaTime * 1000),
                                                    Mathf.Lerp(playerTransform.position.z, TeleportSpawn.transform.position.z, Time.deltaTime * 1000)  );
            TeleportSpawn.SetActive(false);
            active = false;
            cooldown = 1000f;
        }
    }
}
