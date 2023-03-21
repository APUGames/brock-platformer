using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{

    int startSceneIndex;

    private void Awake()
    {

        //Find number of similar objects in the scene
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {

            Destroy(gameObject);

        }
        else
        {

            //If scene reloads, Singleton won't be destroyed
            DontDestroyOnLoad(gameObject);

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        startSceneIndex = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex != startSceneIndex)
        {

            Destroy(gameObject);

        }
    }

}
