using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [Tooltip ("Game Units per second")]
    [SerializeField] float scrollSpeed = 0.2f;
    [SerializeField] GameObject water;

    bool danger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (danger)
        {

            water.transform.Translate(new Vector2(0.0f, scrollSpeed * Time.deltaTime));

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            danger = true;

        }

    }

}
