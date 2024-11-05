using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;

public class DoorMission : MonoBehaviour
{
    // Este script está en las puertas
    /* string doorTag; */
    int mission;
    GameObject panelMessage;
    bool sw=true;
    
    [SerializeField] 
    TextMeshProUGUI message;
    void Start()
    {
        /* doorTag = gameObject.tag; */
        panelMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag.Equals("Player") && sw==true)
        {
            switch(gameObject.tag)
            {
                case "Door1": //Recolectar 5 gemas
                    if(mission==5)
                    {
                        panelMessage.SetActive(true);
                        Destroy(gameObject,2);
                        sw=false;
                    }
                    else{
                        panelMessage.SetActive(true);
                        message.text = "Recolecta 5 gemas";
                    }
                    break;
                default:
                    break;
            }
        }   
    }
      void OnTriggerExit(Collider other){
        if(other.gameObject.tag.Equals("Player"))
        {
            message.text = "";
            panelMessage.SetActive(false);
        }
      }
    IEnumerator TimeToDestroy()
    {
        message.text = "Lo lograste!";
        yield return new WaitForSeconds(2);
        message.text = "";
        panelMessage.SetActive(false);
        Destroy(gameObject, 1);
    }
}
