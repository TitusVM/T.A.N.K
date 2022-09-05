/*
 * Title : Perk1.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Perk1 : MonoBehaviourPunCallbacks, IOnEventCallback
{
    void Start()
    {
    }
    private void OnEnable()
    {
        canon = this.GetComponent<Canon>();
        canon.enabled = true;
        Debug.Log("Perk1 enabled");
        switch (togglePerk1.tag)
        {
            case "BounceGrenade":
                BounceGrenade();
                break;
        }
        PhotonNetwork.AddCallbackTarget(this);
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

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == CombatFinishedCode && lockedIn)
        {
            canon.enabled = false;
            lockedIn = false;
        }
    }

    private void OnDisable()
    {
        Debug.Log("Perk1 disabled");
        PhotonNetwork.RemoveCallbackTarget(this);
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
            lockedIn = true;
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
            canon.Shoot(bounceGrenadeObject);
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
    private bool lockedIn = false;

    // Codes

    private const int CombatFinishedCode = 34;
}