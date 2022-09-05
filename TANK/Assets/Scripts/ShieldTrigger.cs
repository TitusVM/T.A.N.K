/*
 * Title : ShieldTrigger.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("here");
        Rigidbody2D collidingObject = collision.gameObject.GetComponent<Rigidbody2D>();
        collidingObject.velocity = -collidingObject.velocity; // Inverser le vecteur mouvement pour contre-uno le joueur
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/


    /***************************************************************\
     *                      Methodes publiques                     *
    \***************************************************************/

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/
}
