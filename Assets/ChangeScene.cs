using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public static int countrylevel = 0;
    public static int englishlevel = 0;
    public static int artslevel = 0;
    public static int musiclevel = 0;
    public static int mathematicslevel = 0;
    public static int sciencelevel = 0;
    public static int sceneIDs = 0;
    
    public static int awards1 = 0;

    public static int countryawards = 2;
    public static int englishawards = 2;
    public static int artsawards = 2;
    public static int musicawards = 2;
    public static int mathematicsawards = 2;
    public static int scienceawards = 2;

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        sceneIDs = sceneID;
    }

    public void wincountry(int sceneID)
    {
        sceneIDs = sceneID + countrylevel;
        awards1 = countryawards;
        SceneManager.LoadScene(sceneIDs);
    }

    public void winenglish(int sceneID)
    {
        sceneIDs = sceneID + englishlevel;
       awards1 = englishawards;
        SceneManager.LoadScene(sceneIDs);
    }

    public void winarts(int sceneID)
    {
        sceneIDs = sceneID + artslevel;
        awards1 = artsawards;
        SceneManager.LoadScene(sceneIDs);
    }

    public void winmusic(int sceneID)
    {
        sceneIDs = sceneID + musiclevel;
        awards1 = musicawards;
        SceneManager.LoadScene(sceneIDs);
    }

    public void winmathematics(int sceneID)
    {
        sceneIDs = sceneID + mathematicslevel;
        awards1 = mathematicsawards;
        SceneManager.LoadScene(sceneIDs);
    }

    public void winscience(int sceneID)
    {
        sceneIDs = sceneID + sciencelevel;
        awards1 = scienceawards;
        SceneManager.LoadScene(sceneIDs);
    }

    public static void countrysetawards1(){
         awards1 = countryawards;
         return;
    }

    public static void englishsetawards1(){
         awards1 = englishawards;
         return;
    }
    
    public static void artssetawards1(){
         awards1 = artsawards;
         return;
    }

    public static void musicsetawards1(){
         awards1 = musicawards;
         return;
    }

    public static void mathematicssetawards1(){
         awards1 = mathematicsawards;
         return;
    }

    public static void sciencesetawards1(){
         awards1 = scienceawards;
         return;
    }



    public void QuitGame ()
    {
        Debug.Log ("Quit!");
        Application.Quit();
    }

}
