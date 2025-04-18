using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{
    [SerializeField] private GameObject image_unknown;
    public int objectID;

    public static int lastTappedID = -1;
    public static int attempt = 2;
    public static int hold = 0;
    public static int award = 0;
    public static int life = 0;
    public static int win = 0;

    private BoxCollider2D boxCollider;
    private static MainImageScript previousScript;

    public GameObject  hintNE;
    public GameObject  hintE;
    public GameObject  hintpanel;
    public AudioSource soundPlayer;

    private static int gold = 0;
    [SerializeField] private TextMesh goldText;

    public void awake()
    {
        gold = PlayerPrefs.GetInt("gold", 0);

        life = 0;
        award = 0;
        goldText.text = "" + gold;
    }

    public void OnMouseDown()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        attempt = attempt + 1;
        hold = attempt % 2;

        //Retry btn = returns.GetComponent<Retry>();
        //btn.onClick.AddListener(TaskOnClick);
        
        if(life >= 5){
            Debug.Log("You have no life, please retry");
            return;
        }

        if (!boxCollider.enabled || !image_unknown.activeSelf) // Check if the objects are clickable
        {
            Debug.Log("Enabled / not clickable");
            attempt--;
            return; // Exit the method and do not proceed further
        }

        if (objectID == lastTappedID && hold == 0)
        { soundPlayer.Play();
            image_unknown.SetActive(false);
            boxCollider.enabled = false;
            attempt = 2;
            lastTappedID = -1;
            award ++;
            Debug.Log("equal objectID");
            if (previousScript != null)
            {
                previousScript.SetImageUnknown(false);
            }
            if (award >= ChangeScene.awards1){
            Debug.Log("You have 50 Coins");
            gold = gold + 50;
            PlayerPrefs.SetInt("gold", gold);
            PlayerPrefs.Save();
            win++;
            goldText.text = "" + gold;
                if(ChangeScene.sceneIDs == 10 || ChangeScene.sceneIDs == 11 || ChangeScene.sceneIDs == 12){
                    ChangeScene.countrylevel ++;
                    ChangeScene.countryawards ++;  
                    ChangeScene.countrysetawards1();
                }
                if(ChangeScene.sceneIDs == 13 || ChangeScene.sceneIDs == 14 || ChangeScene.sceneIDs == 15){
                    ChangeScene.englishlevel ++;
                    ChangeScene.englishawards ++; 
                    ChangeScene.englishsetawards1();

                }
                if(ChangeScene.sceneIDs == 16 || ChangeScene.sceneIDs == 17 || ChangeScene.sceneIDs == 18){
                    ChangeScene.artslevel ++;
                    ChangeScene.artsawards ++;
                    ChangeScene.artssetawards1();
                }
                if(ChangeScene.sceneIDs == 19 || ChangeScene.sceneIDs == 20 || ChangeScene.sceneIDs == 21){
                    ChangeScene.musiclevel ++;
                    ChangeScene.musicawards ++;
                    ChangeScene.musicsetawards1();
                }
                if(ChangeScene.sceneIDs == 22 || ChangeScene.sceneIDs == 23 || ChangeScene.sceneIDs == 24){
                    ChangeScene.mathematicslevel ++;
                    ChangeScene.mathematicsawards ++;
                    ChangeScene.mathematicssetawards1();  
                }
                if(ChangeScene.sceneIDs == 25 || ChangeScene.sceneIDs == 26 || ChangeScene.sceneIDs == 27){
                    ChangeScene.sciencelevel ++;
                    ChangeScene.scienceawards ++;
                    ChangeScene.sciencesetawards1();
                }
            GameControlScript.disbaled = (true);
            }
            return;
        }
        else
        { soundPlayer.Play();
            if (hold == 0)
            {
                life ++;
                attempt = 2;
                lastTappedID = -1;
                GameControlScript.disbaled = (true);
                StartCoroutine(DelayedAction());
                return;
            }
            else
            {
                image_unknown.SetActive(false);
                lastTappedID = objectID;
                previousScript = this;
                Debug.Log("not modulus 0");
            }
        }
    }

    private IEnumerator DelayedAction()
    {
        image_unknown.SetActive(false);
        yield return new WaitForSeconds(0.5f); // Delay for 2 seconds
        image_unknown.SetActive(true);
        previousScript.SetImageUnknown(true);
        Debug.Log("modulus 0 not equal id");
        // Perform additional actions or logic here
    }

    public void SetImageUnknown(bool active)
    {
        image_unknown.SetActive(active);
    }
    
    public void TaskOnClick()
    {
        lastTappedID = -1;
        attempt = 2;
        hold = 0;
        award = 0;
        life = 0;
        previousScript = null;
        Debug.Log("RESTARTED");
    }

    public void hint()
    {
        if(gold >= 50)
        {
        gold = gold - 50;
        goldText.text = "" + gold;
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.Save();
        hintpanel.SetActive(true);
        hintE.SetActive(true);
        return;
        }
        else{
        hintNE.SetActive(true);
        hintE.SetActive(false);
        return;
        }
    }
}