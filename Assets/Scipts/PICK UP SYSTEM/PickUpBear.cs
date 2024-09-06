using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBear : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject BearOnPlayer;

    void Start()
    {
        BearOnPlayer.SetActive(false);                              //not showing in first scene
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)                      // per frame cinocall trigger collider hanggat nasa "loob ng tigger collider"
    {                                                               // pag pasok yung player sa collider

        if (other.gameObject.tag == "Player")                       // pag pasok yung player sa collider
        {

            PickUpText.SetActive(true);

            inventory inventory = other.GetComponent<inventory>();
           
        
                if (Input.GetKey(KeyCode.E))
                {
                    inventory.Bearscollected();
                    this.gameObject.SetActive(false);                   // false nya yung gameObject ( bear)
                    BearOnPlayer.SetActive(false);

                    PickUpText.SetActive(false);                       // mawawala Text
                }
            }
        }


    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);                               //"ma eexcute pag umalis ka sa collider" 
                                                                  // "OnTriggerEnter - isang beses lang execute pag pasok lang (one time only)"
    }
}
