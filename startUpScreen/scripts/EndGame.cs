using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;

    public void SetUp()
    {
        gameObject.SetActive(true);
    }
     public void gameOver()
    {
        if (gameHasEnded == true)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    } 

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");//SceneManager.GetActiveScene().name);
    }
}
