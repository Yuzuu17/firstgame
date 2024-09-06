using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Stairs : MonoBehaviour
{

    public GameObject Sounds;

    void Start()
    {
        Sounds.SetActive(false);
    }

    private void OnTriggerEnter(Collider jumpscare)
    {
        if (jumpscare.gameObject.tag == "Player")
        {
            Sounds.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider jumpscare)
    {
        Destroy(Sounds);                   
                                                                  
    }
}

