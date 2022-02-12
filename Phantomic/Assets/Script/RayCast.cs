using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float range = 4f;


    void Start()
    {
    }
    void Update()
    { 
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (Input.GetKey(KeyCode.W))
        {
            Gizmos.DrawRay(transform.position, Vector3.forward * range);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Gizmos.DrawRay(transform.position, Vector3.left * range);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Gizmos.DrawRay(transform.position, Vector3.back * range);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Gizmos.DrawRay(transform.position, Vector3.right * range);
        }
    }

}
