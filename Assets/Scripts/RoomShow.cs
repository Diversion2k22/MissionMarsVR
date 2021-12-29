using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomShow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject build;
    public GameObject room;
    public GameObject hall;
    void Start()
    {
        build.SetActive(false);
        room.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            room.SetActive(false);
            hall.SetActive(false);
            build.SetActive(true);
        }
            
    }
}
