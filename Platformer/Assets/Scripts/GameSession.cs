using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;

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

    public void ProcessPlayerDeath()
    {

        if (playerLives >= 1)
        {

            SubtractLife();

        }
        else
        {

            ResetGameSession();

        }

    }

    private void SubtractLife()
    {

        playerLives--;

        Debug.Log("Player lives: " + playerLives);

        StartCoroutine(WaitForSeconds());

    }

    private void ResetGameSession()
    {

        Destroy(gameObject);

        StartCoroutine(WaitForSeconds());

    }

    IEnumerator WaitForSeconds()
    {

        yield return new WaitForSeconds(1.35f);

        if(playerLives >= 1)
        {

            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(currentSceneIndex);

        }
        else
        {

            SceneManager.LoadScene(0);

        }

    }

}
