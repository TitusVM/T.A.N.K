/*
 * Title : Jump.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 26.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private void Start()
    {
        trajectoryLineEnabled = true;
        lockedIn = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        trajectory = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectory[i] = Instantiate(circleObject, this.transform.position, Quaternion.identity, trajectoryLine.transform);
        }
        Debug.Log("Jump enabled");
    }

    private void Update()
    {
        if (!lockedIn)
        {
            ActivateTrajectoryLine();
        }
    }

    private void OnDisable()
    {
        DeleteTrajectoryLine();
        Debug.Log("Jump disabled");
    }

    /***************************************************************\
     *                      Methodes publiques                     *
    \***************************************************************/

    public void LockIn()
    {
        lockInTransform = transform.GetChild(0);
        lockInLaunchforce = launchForce;
        lockedIn = true;
        trajectoryLineEnabled = false;
        DeleteTrajectoryLine();
    }

    public void Execute()
    {
        rb.velocity = lockInTransform.right * lockInLaunchforce;
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private void ActivateTrajectoryLine()
    {
        if (trajectoryLineEnabled)
        {
            Vector2 canonPos = transform.GetChild(0).position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            launchForce = Mathf.Sqrt(Vector2.SqrMagnitude(canonPos - mousePos)) * magicForceScale;

            if (launchForce > maxLaunchForce)
            {
                launchForce = maxLaunchForce;
            }
            direction = mousePos - canonPos;
            transform.GetChild(0).right = direction;
            for (int i = 0; i < numberOfPoints; i++)
            {
                trajectory[i].transform.position = PointPosition(i * spaceBetweenPoints);
            }
        }
    }
    private void DeleteTrajectoryLine()
    {
        for (int i = 0; i < trajectory.Length; i++)
        {
            Destroy(trajectory[i]);
        }
        // Ne pas d�truire trajectoryLine parce que c'est le container - on en aura besoin pour recr�er une nouvelle ligne
    }

    private Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)this.transform.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t); // formule physique ( => maqique)
        return position;
    }



    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private bool jumpSelected = false;
    private Vector2 direction;
    private bool lockedIn;
    private bool execute;
    private GameObject[] trajectory;
    private bool trajectoryLineEnabled;
    [SerializeField] private Transform trajectoryLine; // Container pour les cercles de la trajectoire (QoL)
    [SerializeField] private int numberOfPoints = 25; // Nombres de billes affich�s � la projection de trajectoire
    private Transform lockInTransform;
    private float lockInLaunchforce;

    // Force
    [SerializeField] private float launchForce = 1f; // Force de tir choisie
    [SerializeField] private float maxLaunchForce = 15f; // Force maximale de tir
    [SerializeField] private float magicForceScale = 2f; // QoL pour ne pas devoir sortir de l'�cran avec la souris
    [SerializeField] private float spaceBetweenPoints = 0.04f; // Espace entre les billes de projection


    // Components
    private Rigidbody2D rb;
    [SerializeField] private GameObject circleObject;
}
