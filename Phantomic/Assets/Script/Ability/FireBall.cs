using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float maxCooldown = 1000f;
    public bool active;
    private float distance = 1f;
    private float cooldown;
    public float range = 4f;
    public GameObject fireBall;
    public char lastKey;
    public GameObject rocketClone;
    private PlayerBase pb;

    private ChargePlayer2 ch;

    public void Start()
    {
        ch = FindObjectOfType<ChargePlayer2>();
        ch.text2.text = "FireBall (R)";
    }

    public void Update()
    {
        pb = FindObjectOfType<PlayerBase>();

        if (cooldown == 0f)
        {
            active = true;
            FireRocket();
        }
        else
        {
            if (cooldown == 1f)
            {
                FireRocket();
            }
            cooldown -= 1f;
        }
        
    }

    void FireRocket()
    {
        if ( (Input.GetKeyDown(KeyCode.R)) && (active) )
        {
            if ((Input.GetKey(KeyCode.W)) || (pb.lastKey == 'W'))
            {
                rocketClone = Instantiate(fireBall, new Vector3(pb.playerTransform.position.x, pb.playerTransform.position.y, pb.playerTransform.position.z + distance), pb.playerTransform.rotation);
            }
            else if ((Input.GetKey(KeyCode.A)) || (pb.lastKey == 'A'))
            {
                rocketClone = Instantiate(fireBall, new Vector3(pb.playerTransform.position.x - distance, pb.playerTransform.position.y, pb.playerTransform.position.z), pb.playerTransform.rotation);
            }
            else if ((Input.GetKey(KeyCode.S)) || (pb.lastKey == 'S'))
            {
                rocketClone = Instantiate(fireBall, new Vector3(pb.playerTransform.position.x, pb.playerTransform.position.y, pb.playerTransform.position.z - distance), pb.playerTransform.rotation);
            }
            else if ((Input.GetKey(KeyCode.D)) || (pb.lastKey == 'D'))
            {
                rocketClone = Instantiate(fireBall, new Vector3(pb.playerTransform.position.x + distance, pb.playerTransform.position.y, pb.playerTransform.position.z), pb.playerTransform.rotation);
            }
            active = false;
            cooldown = maxCooldown;
            pb.playerMovementInput.constraints = RigidbodyConstraints.FreezePosition;

        }
        else if (!active)
        {
            active = true;
            Destroy(rocketClone);
            pb.playerMovementInput.constraints = RigidbodyConstraints.None;
            pb.playerMovementInput.constraints = RigidbodyConstraints.FreezeRotationY;
        }
    }
}
