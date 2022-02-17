using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float range = 4f;
    public Transform playerPosition;
    public GameObject fireBall;
    public char lastKey;

    public void Update()
    {
        FireRocket();
    }

    void FireRocket()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject rocketClone = Instantiate(fireBall, playerPosition.position, playerPosition.rotation);

            if (lastKey == 'W')
            {
                rocketClone.GetComponent<Rigidbody>().velocity = transform.forward * 2f;
            }
            else if (lastKey == 'A')
            {
                rocketClone.GetComponent<Rigidbody>().velocity = transform.right * -2f;
            }
            else if (lastKey == 'D')
            {
                rocketClone.GetComponent<Rigidbody>().velocity = transform.right * 2f;
            }
            else if (lastKey == 'S')
            {
                rocketClone.GetComponent<Rigidbody>().velocity = transform.forward * -2f;
            }
        }
    }
}
