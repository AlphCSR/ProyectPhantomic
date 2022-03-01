using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //FireBall
        if(other.gameObject.tag == "Proyectil")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        //Blindness
        if(other.gameObject.tag == "Cloth" )
        {
            Debug.Log("Enemigo Cegado");
            other.gameObject.SetActive(false);
        }

    }

}
