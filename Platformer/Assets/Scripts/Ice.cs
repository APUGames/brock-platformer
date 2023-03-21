using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField] GameObject ice;
    bool iceTrue;
    [SerializeField] Pickup pickupScript;

    // Start is called before the first frame update
    void Start()
    {
        
        ice.SetActive(false);

        //pickupScript = GetComponent<Pickup>();

    }

    // Update is called once per frame
    void Update()
    {
       
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        iceTrue = pickupScript.hasIce;

        if (iceTrue)
        {

            Debug.Log(this.gameObject);
            
            ice.SetActive(true);

        }

    }

}
