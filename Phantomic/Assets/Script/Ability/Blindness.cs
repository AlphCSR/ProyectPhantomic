using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindness : MonoBehaviour
{
    public GameObject cloth;
    public char lastKey;
    public Transform playerTransform;

    void Start()
    {
        cloth.SetActive(false);
    }
    void Update()
    {
        //Sistema Coldown
    }

    public void SetCloth()
    {
        if ((Input.GetKey(KeyCode.W)) || (lastKey == 'W'))
        {
            cloth.transform.position = new Vector3(Mathf.Lerp(cloth.transform.position.x, playerTransform.position.x, Time.deltaTime* 1000),
                                                        Mathf.Lerp(cloth.transform.position.y, playerTransform.position.y, Time.deltaTime* 1000),
                                                        Mathf.Lerp(cloth.transform.position.z, playerTransform.position.z + 3f, Time.deltaTime* 1000));
        }
        else if ((Input.GetKey(KeyCode.A)) || (lastKey == 'A'))
        {
            cloth.transform.position = new Vector3(Mathf.Lerp(cloth.transform.position.x, playerTransform.position.x - 3f, Time.deltaTime * 1000),
                                                        Mathf.Lerp(cloth.transform.position.y, playerTransform.position.y, Time.deltaTime * 1000),
                                                        Mathf.Lerp(cloth.transform.position.z, playerTransform.position.z, Time.deltaTime * 1000));
        }
        else if ((Input.GetKey(KeyCode.S)) || (lastKey == 'S'))
        {
            cloth.transform.position = new Vector3(Mathf.Lerp(cloth.transform.position.x, playerTransform.position.x, Time.deltaTime * 1000),
                                                        Mathf.Lerp(cloth.transform.position.y, playerTransform.position.y, Time.deltaTime * 1000),
                                                        Mathf.Lerp(cloth.transform.position.z, playerTransform.position.z - 3f, Time.deltaTime * 1000));
        }
        else if ((Input.GetKey(KeyCode.D)) || (lastKey == 'D'))
        {
            cloth.transform.position = new Vector3(Mathf.Lerp(cloth.transform.position.x, playerTransform.position.x + 3f, Time.deltaTime * 1000),
                                                        Mathf.Lerp(cloth.transform.position.y, playerTransform.position.y, Time.deltaTime * 1000),
                                                        Mathf.Lerp(cloth.transform.position.z, playerTransform.position.z, Time.deltaTime * 1000));
        }
    }

}
