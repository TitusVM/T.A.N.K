/*
 * Title : Happening
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
 * Source :
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happening : MonoBehaviour
{
    private void Start()
    {
        StartHappening();
    }

    /***************************************************************\
     *                      Methodes publics                       *
    \***************************************************************/

    public void StartHappening()
    {
        //debut de la phase de happening
        if(happening == null)
        {
            //Choose Happening
        }
        //calculer le tour de happening
        currentTurn++;
        //Tour d'un happening
        if(currentTurn%happeningTurn ==  0)
        {
            //resoudre le happening
            ResolveHappening();
        } //tour avant le happening
        else if(currentTurn % happeningTurn == 1)
        {
            //annoncer le happening
            AnnonceHappening();
        }

        //maximum d'objets de soutien pas atteint
        if(currentNumberItems<=MaximumItems)
        {
            //PlaceHP();
        }

        //retour � la phase d'Analyse
        Debug.Log("Fin des Happenings");
        isOver = true;
    }

    public bool IsOver()
    {
        return isOver;
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private void ResolveHappening()
    {
        //resolve happening

        //set happening to null
        happening = null;
    }
    
    private void AnnonceHappening()
    {
        //annonce happening
    }

    private void PlaceHP()
    {
        GameObject go = Instantiate(healthpack, new Vector2(200, 200), Quaternion.identity);
        currentNumberItems++;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools

    private int currentTurn = 0;
    private int happeningTurn = 4;
    private int MaximumItems = 5;
    private int currentNumberItems = 0;
    private GameObject happening = null;
    private bool isOver;

    // Components
    [SerializeField] private GameObject healthpack;


}
