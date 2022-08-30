/*
 * Title : Missile.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : https://www.youtube.com/watch?v=tNwLaGUJTK4
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ismissile : MonoBehaviour
{
    private void OnEnable()
    {
        canon = this.GetComponent<Canon>();
        canon.enabled = true;
        Debug.Log("Ismissile enabled");
    }

    void Update()
    {
        /*** DEBUGGING ***/
        if (Input.GetMouseButtonDown(1))
        {
            canon.Shoot(ismissileObject);
        }
        /*** DEBUGGING ***/
    }

    private void OnDisable()
    {
        canon.enabled = false;
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private void OnDestroy() // appel� au Destroy()
    {
        Explode();
    }

    private void Explode()
    {
        Debug.Log("BOOM CHAKALAKA");
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Components
    [SerializeField] private GameObject ismissileObject;
    private Canon canon;
}
