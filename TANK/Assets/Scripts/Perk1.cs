/*
 * Title : Perk1.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Perk1 : MonoBehaviour
{
    void Start()
    {
        switch (togglePerk1.tag)
        {
            case "BounceGrenade":
                BounceGrenade();
                break;
        }
    }
    private void OnEnable()
    {
        canon = this.GetComponent<Canon>();
        canon.enabled = true;
        Debug.Log("Perk1 enabled");
    }

    private void Update()
    {
        /*** TESTING ***/
        /*if (Input.GetMouseButtonDown(1))
        {
            switch (togglePerk1.tag)
            {
                case "BounceGrenade":
                    BounceGrenade();
                    break;
            }
        }*/
        /*** TESTING ***/

    }

    private void OnDisable()
    {
        Debug.Log("Perk1 disabled");
        canon.enabled = false;
    }

    /***************************************************************\
     *                       M�thodes private                      *
    \***************************************************************/

    private void Actions1()
    {
    }
    private void BounceGrenade()
    {
        gObject = bounceGrenadeObject;
        canonNeeded = true;
        Debug.Log("BounceGrenade() in Perk1.cs");
    }

    public void LockIn()
    {
        if(canonNeeded)
        {
            canon.LockIn();
        }    
        else
        {
            // else...
        }
    }

    public void Execute()
    {
        if (canonNeeded)
        {
            canon.Shoot(gObject);
        }
        else
        {
            // else...
        }
    }


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools

    // Components
    private Canon canon;
    private GameObject gObject;
    [SerializeField] private GameObject bounceGrenadeObject;

    [SerializeField] private Toggle togglePerk1;
    private bool canonNeeded;
}