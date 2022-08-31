/*
 * Title : Game Setup 
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 26.08.2022
 * Source : https://www.youtube.com/watch?v=onDorc3Qfn0 
 */
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetup : MonoBehaviour
{

    void Start()
    {
        CreatePlayer();
    }

    public static void CreatePlayer()
    {
        Debug.Log("New Player created");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TankBasic"), GameController.instance.spawnPoints[0].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}