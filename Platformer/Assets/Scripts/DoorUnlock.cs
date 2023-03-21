using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool unlocked;
    [SerializeField] Pickup pickupScript;

    // Start is called before the first frame update
    void Start()
    {

        door.SetActive(true);

        //pickupScript = GetComponent<Pickup>();

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        unlocked = pickupScript.hasKey;

        if(gameObject == Camera.main)
        {

            Debug.Log("Camera");

        }

        if (unlocked)
        {

            door.SetActive(false);

        }

    }
}
