using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Resume ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
