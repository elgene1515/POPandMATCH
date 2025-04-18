using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    public GameObject  objectToDisable;
    public GameObject  objectToDisable1;
    public GameObject  objectToDisable2;
    public GameObject  objectToDisable3;
    public GameObject  objectToDisable4;
    public GameObject  losepanel;
    public GameObject  balloonpanel;
    public GameObject  toolspanel;
    public GameObject  winpanel;
    public static bool disbaled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MainImageScript.win==1){
            winpanel.SetActive(true);
            balloonpanel.SetActive(false);
            toolspanel.SetActive(false);
            MainImageScript.lastTappedID = -1;
            MainImageScript.attempt = 2;
            MainImageScript.hold = 0;
            MainImageScript.award = 0;
            MainImageScript.life = 0;
            MainImageScript.win = 0;
        }
        if (MainImageScript.life==1){
            objectToDisable.SetActive(false);
        }
        if (MainImageScript.life==2){
            objectToDisable1.SetActive(false);
        }
        if (MainImageScript.life==3){
            objectToDisable2.SetActive(false);
        }
        if (MainImageScript.life==4){
            objectToDisable3.SetActive(false);
        }
        if (MainImageScript.life==5){
            objectToDisable4.SetActive(false);
            losepanel.SetActive(true);
            balloonpanel.SetActive(false);
            toolspanel.SetActive(false);
            MainImageScript.lastTappedID = -1;
            MainImageScript.attempt = 2;
            MainImageScript.hold = 0;
            MainImageScript.award = 0;
            MainImageScript.life = 0;

            Debug.Log("You have no life, please retry");
        }
    }
}
