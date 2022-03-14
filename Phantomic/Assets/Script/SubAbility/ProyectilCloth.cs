using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilCloth : MonoBehaviour
{
    private PlayerBase pb;
    public GameObject cloth;
    public GameObject clothClone;
    public Rigidbody proyectileRB;

    // Start is called before the first frame update
    void Start()
    {
        proyectileRB = GetComponent<Rigidbody>();
        pb = FindObjectOfType<PlayerBase>();

        if (pb.lastKey == 'W')
        {
            proyectileRB.velocity = transform.forward * 1f;
        }
        else if (pb.lastKey == 'A')
        {
            proyectileRB.velocity = transform.right * -1f;
        }
        else if (pb.lastKey == 'S')
        {
            proyectileRB.velocity = transform.forward * -1f;
        }
        else if (pb.lastKey == 'D')
        {
            proyectileRB.velocity = transform.right * 1f;
        }

        Invoke("Cloth", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cloth()
    {
        clothClone = Instantiate(cloth, new Vector3(transform.position.x, 0.1f, transform.position.z), transform.rotation);
        Destroy(this.gameObject);
    }
}
