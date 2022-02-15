using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : MonoBehaviour
{
    public float range = 1f;
    GameObject cloth;
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        RaycastHit hit;

        if (Physics.Raycast(cloth.transform.position, Vector3.forward, out hit, range))
        {
            if (hit.collider.tag == "Enemy")
            {
                Destroy(GameObject.FindGameObjectWithTag(hit.collider.tag));
            }

        }
        else if (Physics.Raycast(cloth.transform.position, Vector3.left, out hit, range))
        {
            if (hit.collider.tag == "Enemy")
            {
            Destroy(GameObject.FindGameObjectWithTag(hit.collider.tag));
            }
        }

        else if (Physics.Raycast(cloth.transform.position, Vector3.back, out hit, range))
        {
            if (hit.collider.tag == "Enemy")
            {
                Destroy(GameObject.FindGameObjectWithTag(hit.collider.tag));
            }
        }
        else if (Physics.Raycast(cloth.transform.position, Vector3.right, out hit, range))
        {
            if (hit.collider.tag == "Enemy")
            {
                Destroy(GameObject.FindGameObjectWithTag(hit.collider.tag));
            }
        }
    }
}
