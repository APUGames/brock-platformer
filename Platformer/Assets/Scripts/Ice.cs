using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            
            ice.SetActive(true);

            Lv5();

        }

    }

    private void Lv5()
    {

        GameObject faker = new GameObject();
        faker = this.gameObject;
        
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "Level 5")
        {

            faker.SetActive(false);

        }

    }

}
