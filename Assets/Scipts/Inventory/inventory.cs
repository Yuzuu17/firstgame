using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class inventory : MonoBehaviour
{
    public Image One;
    public UnityEvent<inventory> OnBearscollected;

    public AudioSource two;

    public int NumberOfBears { get; private set; }                 //singleton yung get

    void Start()
    {
        if (One != null)
        {
            One.gameObject.SetActive(false);                        //para di lumabas sa una
        }
    }

    public void Bearscollected()
    {
        NumberOfBears++;
        Debug.LogError("Bearscollected ; " + NumberOfBears);       // check number of bears

        if (NumberOfBears == 8)
        {
            two.gameObject.SetActive(true);
            One.gameObject.SetActive(true);
            

            Invoke("end", 2f);                                  // para mag run yung method na end
        }
    }
        public void end()
    {
        One.gameObject.SetActive(false);
        two.gameObject.SetActive(true);
    }
    
}

