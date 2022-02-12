using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform[] PlayerView;
    public float transitionSpeed = 1000f;
    public Transform currentView;
    public void Start()
    {
        currentView = transform;
    }

    public void Update()
    {
        SwapCamera();
    }

    public void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        Vector3 currentAngle = new Vector3( Mathf.Lerp(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
                                            Mathf.Lerp(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
                                            Mathf.Lerp(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed)
                                           );
        transform.eulerAngles = currentAngle;
    }

    void SwapCamera()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentView = PlayerView[2];
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            currentView = PlayerView[0];
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            currentView = PlayerView[3];
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentView = PlayerView[1];
        }
    }
}
