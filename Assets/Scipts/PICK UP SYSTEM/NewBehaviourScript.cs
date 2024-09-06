using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, Itemcontainer, cam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;            // para di makapulot


    private void Start()
    {
        //set up
        if (!equipped)
        { 
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

    }
 


    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //set parent
        transform.SetParent(Itemcontainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;


        // make RB kinematic and Boxcollider a trigger

        rb.isKinematic = true;      // kalutang sabe ni baby
        coll.isTrigger = true;
        
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //set parent to null
        transform.SetParent(null);


        // make RB not kinematic and Boxcollider normal

        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //addforce
        rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);

        //add random rotation sa bear
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random)*10);
    }
    }

