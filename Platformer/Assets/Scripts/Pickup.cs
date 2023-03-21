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
    [SerializeField] AudioClip doorJamSFX;
    [SerializeField] AudioClip doorUnlockSFX;
    [SerializeField] AudioClip meltIceSFX;
    [SerializeField] AudioClip freezeWaterSFX;

    public bool hasFire = false;
    public bool hasIce = false;
    public bool hasKey = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.tag == "FirePower") //11 is Fire I think
        {

            //AudioSource.PlayClipAtPoint(firePickupSFX, Camera.main.transform.position);
            hasFire = true;

            Destroy(gameObject);

        }
        
        if (gameObject.tag == "IcePower") //12 is Ice
        {

            //AudioSource.PlayClipAtPoint(icePickupSFX, Camera.main.transform.position);
            hasIce = true;
            Debug.Log(hasIce);

            Destroy(gameObject);

        }
        
        if (gameObject.tag == "Key") //13 is Key
        {

            //AudioSource.PlayClipAtPoint(keyPickupSFX, Camera.main.transform.position);
            hasKey = true;

            Destroy(gameObject);

        }

        //Collisions with objects after powerups collected
        if (hasFire && gameObject.layer == 16)
        {

            //AudioSource.PlayClipAtPoint(meltIceSFX, Camera.main.transform.position);
            hasFire = false;

            Destroy(gameObject);

        }

        if (hasIce && gameObject.layer == 4)
        {

            //AudioSource.PlayClipAtPoint(freezeWaterSFX, Camera.main.transform.position);
            hasIce = false;

            //make ice appear where it wasnt before


        }

        if (hasKey && gameObject.layer == 15)
        {

            //AudioSource.PlayClipAtPoint(doorUnlockSFX, Camera.main.transform.position);
            hasKey = false;

            Destroy(gameObject);

        }
        else if (!hasKey && gameObject.layer == 15)
        {

            //AudioSource.PlayClipAtPoint(doorJamSFX, Camera.main.transform.position);

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
