using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    [SerializeField] AudioClip firePickupSFX;
    [SerializeField] AudioClip fireUseSFX;
    [SerializeField] AudioClip icePickupSFX;
    [SerializeField] AudioClip iceUseSFX;
    [SerializeField] AudioClip keyPickupSFX;
    [SerializeField] AudioClip keyUseSFX;
    [SerializeField] AudioClip deadSFX;
    [SerializeField] AudioClip jumpSFX;

    public bool hasFire;
    public bool hasIce;
    public bool hasKey;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (gameObject.layer == 11) //11 is Fire I think
        {

            AudioSource.PlayClipAtPoint(firePickupSFX, Camera.main.transform.position);
            hasFire = true;

            Destroy(gameObject);

        }
        else if(gameObject.layer == 12) //12 is Ice
        {

            AudioSource.PlayClipAtPoint(icePickupSFX, Camera.main.transform.position);
            hasIce = true;

            Destroy(gameObject);

        }
        else if(gameObject.layer == 13) //13 is Key
        {

            AudioSource.PlayClipAtPoint(keyPickupSFX, Camera.main.transform.position);
            hasKey = true;

            Destroy(gameObject);

        }

        

    }

    // Start is called before the first frame update
    void Start()
    {

        


    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
