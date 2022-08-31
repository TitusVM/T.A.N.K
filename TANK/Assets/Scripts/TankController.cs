/*
 * Title : TankController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source :
 */

using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TankController : MonoBehaviour
{

    private PhotonView photonView;
    public static GameObject localPlayerInstance;

    void Start()
    {
        canon = this.GetComponent<Canon>();
        photonView = this.GetComponent<PhotonView>();
    }

    private void Awake()
    {
        if(photonView.IsMine)
        {
            TankController.localPlayerInstance = this.gameObject;
        }

        DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {
        if (lockedIn && ready)
        {
            if (isShootableMunition) // dans le cas d'un missile ou d'une grenade
            {
                //GameObject munition = TankDisplay.GetMunition();
                //canon.Shoot(munition);
            }
            else // Shield, jump...
            {
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ismissile"))
        {
            hitPoints -= missileDamage;
            Destroy(collision.gameObject);
        }
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private int hitPoints = 30;
    private int perk3MunitionCount;
    private int perk4MunitionCount;
    private bool lockedIn;
    private bool ready;
    private bool isShootableMunition;
    private Canon canon;

    [SerializeField] private int missileDamage = 1;
    [SerializeField] private int grenadeDamage;

    // Components


}
