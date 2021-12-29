using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLand : MonoBehaviour {

    //public static GenerateLand GenerateLandInstance;

    public GameObject[] prefabsDrop;
    public GameObject PlayerDrop;
    public static GameObject[] prefabs;
    public static GameObject Player;
    GameObject[] clones;
    void Awake () {
        prefabs = prefabsDrop;
        Player = PlayerDrop;
    }

}