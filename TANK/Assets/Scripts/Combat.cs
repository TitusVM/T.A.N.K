
/*
 * Title : Combat
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
 * Source :
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Combat : MonoBehaviour
{   
    private void OnEnable()
    {
        Debug.Log("Start Combat");
        //tankController = tank.GetComponent<TankController>();
        //Faire toutes les actions des joueurs puis une fois fini fais les Happening
        ExecuteAction();

    }

    private void Update()
    {
        
    }

    /***************************************************************\
     *                      M�thodes private                       *
    \***************************************************************/

    private void ExecuteAction()
    {
        Debug.Log("Execute action");
        tankController.ExecuteAction();
    }


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/
    
    // Tools


    // Components
    [SerializeField] private TankController tankController;
    [SerializeField] private GameObject tank;
}
