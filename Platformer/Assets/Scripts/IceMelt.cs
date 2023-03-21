using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelt : MonoBehaviour
{
    [SerializeField] GameObject ice;
    bool iceFalse;
    [SerializeField] Pickup pickupScript;

    // Start is called before the first frame update
    void Start()
    {

        ice.SetActive(true);

        //pickupScript = GetComponent<Pickup>();

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        iceFalse = pickupScript.hasFire;

        if (iceFalse)
        {

            ice.SetActive(false);

        }

    }

}
