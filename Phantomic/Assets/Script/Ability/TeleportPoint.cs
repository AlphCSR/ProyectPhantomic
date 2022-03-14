using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    public float maxCooldown = 1000f;
    private float cooldown = 0f;
    public bool active = false;
    private float range = 2f;
    private GameObject cloneTeleport;
    public GameObject Teleport;
    private PlayerBase pb;
    private ChargePlayer2 ch;

    public void Start()
    {
        ch = FindObjectOfType<ChargePlayer2>();
        ch.text1.text = "Teleport (E)";
    }

    public void Update()
    {
        pb = FindObjectOfType<PlayerBase>();

        if (cooldown > 0f)
        {
            cooldown -= 1f;
        }
        SetTeleport();
    }

    void SetTeleport()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (!active))
        {
            cloneTeleport = Instantiate(Teleport, new Vector3(pb.playerTransform.position.x, 0.1f, pb.playerTransform.position.z), pb.playerTransform.rotation);
            cloneTeleport.SetActive(true);
            active = true;

        }
        else if ((Input.GetKeyDown(KeyCode.E)) && (active))
        {
            pb.playerTransform.position = new Vector3(cloneTeleport.transform.position.x, pb.playerTransform.position.y, cloneTeleport.transform.position.z);
            cloneTeleport.SetActive(false);
            Destroy(cloneTeleport);
            active = false;
            cooldown = maxCooldown;
        }
    }
}
