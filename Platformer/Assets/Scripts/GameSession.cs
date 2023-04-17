using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    [SerializeField] Text lives;

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

            //lives.text = playerLives.ToString();

        }
        else
        {

            SceneManager.LoadScene(0);

        }

    }

    private void Start()
    {

        //lives.text = playerLives.ToString(); //will convert number to text

    }

}
