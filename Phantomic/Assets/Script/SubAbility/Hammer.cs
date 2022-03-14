using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Vector3 init;
    public Vector3 dest;
    public Vector3 final;
    public float speed;
    private bool active = true;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            if (init.y < dest.y)
            {
                init = transform.position;
                final = init + Vector3.up * Time.deltaTime * (speed/2);
                transform.position = final;
            }
            else 
                active = false;
        }       
        else
        {
            if (init.y > Vector3.up.y)
            {
                init = transform.position;
                final = init - Vector3.up * Time.deltaTime * speed;
                transform.position = final;
            }
            else
                active = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
