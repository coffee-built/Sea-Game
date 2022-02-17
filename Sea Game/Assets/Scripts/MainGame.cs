using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Exit Button hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
