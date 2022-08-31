/*
 * Title : Canon.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : https://www.youtube.com/watch?v=tNwLaGUJTK4
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Canon : MonoBehaviour
{

    private void Start()
    {
        lockedIn = false;
        photonView = this.GetComponent<PhotonView>();
        trajectoryLineNeeded = true;
    }

    private void OnEnable()
    {
        trajectory = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectory[i] = Instantiate(circleObject, firePoint.position, Quaternion.identity, trajectoryLine.transform);
        }
        Debug.Log("Canon enabled");
    }

    private void Update()
    {   
        if (trajectoryLineNeeded)
        {
            ActivateTrajectoryLine();
        }
    }
    private void OnDisable()
    {
        Debug.Log("Canon disabled");
        DeleteTrajectoryLine();
    }


    /***************************************************************\
     *                      Methodes public                        *
    \***************************************************************/

    public void LockIn()
    {
        lockedIn = true;
    }

    public void Shoot(GameObject objectToShoot) // TODO faire passer la bonne munition
    {
        if (photonView.IsMine)
        {
            GameObject newMunition = Instantiate(objectToShoot, firePoint.position, firePoint.rotation);
            newMunition.GetComponent<Rigidbody2D>().velocity = transform.GetChild(0).right * launchForce;
        }
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/
    private void ActivateTrajectoryLine()
    {
        if (photonView.IsMine)
        {
            Vector2 canonPos = transform.GetChild(0).position;
            Vector2 mousePOs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            launchForce = magicForceScale * Mathf.Sqrt(Vector2.SqrMagnitude(canonPos - mousePOs));
            if (launchForce > maxLaunchForce)
            {
                launchForce = maxLaunchForce;
            }
            direction = mousePOs - canonPos;
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
        Vector2 position = (Vector2)firePoint.position + (direction.normalized * launchForce * t ) + 0.5f * Physics2D.gravity * (t * t); // formule physique ( => maqique)
        return position;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private bool ifCanonSelected = false;
    private GameObject[] trajectory;
    private Vector2 direction; // Vecteur direction du entre canon et souris
    private bool trajectoryLineNeeded;
    private bool lockedIn;
    [SerializeField] private Transform trajectoryLine; // Container pour les cercles de la trajectoire (QoL)

    // Force
    [SerializeField] private float launchForce = 1f; // Force de tir choisie
    [SerializeField] private float maxLaunchForce = 15f; // Force maximale de tir
    [SerializeField] private float magicForceScale = 4f; // QoL pour ne pas devoir sortir de l'�cran avec la souris
    [SerializeField] private float spaceBetweenPoints = 0.04f; // Espace entre les billes de projection

    // Components
    [SerializeField] private GameObject circleObject;
    [SerializeField] private Transform firePoint;

    [SerializeField] private int numberOfPoints = 50; // Nombres de billes affich�s � la projection de trajectoire

    // PhotonView
    private PhotonView photonView;
}
