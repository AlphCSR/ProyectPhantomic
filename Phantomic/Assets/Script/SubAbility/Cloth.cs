using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : MonoBehaviour
{
    private Camera camera;
    private PlayerBase pb;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        camera = FindObjectOfType<Camera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        pb = FindObjectOfType<PlayerBase>();
        if (other.tag == "Player")
        {
            Invoke("Blur",0f);
            Invoke("Blur",3f);
            Invoke("Delete",3.5f);
        }
        
    }

    public void Blur()
    {
        if (camera.GetComponent<Blur>().enabled)
        {
            camera.GetComponent<Blur>().enabled = false;
            pb.walk = pb.walk + 1f;
        }
        else
        {
            camera.GetComponent<Blur>().enabled = true;
            pb.walk = pb.walk - 1f;
        }
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }

}
