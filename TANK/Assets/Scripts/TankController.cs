/*
 * Title : TankController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source :
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    void Start()
    {
        healthBar.SetHealth(hitPoints, maxHealth);
    }

    void Update()
    {
        
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
    private int hitPoints = 100;
    private int perk3MunitionCount;
    private int perk4MunitionCount;
    private int maxHealth = 100;

    [SerializeField] private int missileDamage = 1;
    [SerializeField] private int grenadeDamage;

    [SerializeField] private HealthBar healthBar;

    // Components


}
