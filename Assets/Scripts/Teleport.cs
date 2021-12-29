using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField]

    public GameObject player;
  
    public GameObject teleportTarget;
    public string SceneName;
   
    public void TeleportPlayer()
    {
        //object1 a child of object 2
        player.transform.SetParent(teleportTarget.transform.parent);
        //player.transform.position = teleportTarget.transform.position+ new Vector3(1f,2f,1f);
        player.transform.position= teleportTarget.transform.position + new Vector3(1f, 2f, 1f);
        
        
    }
    public void Test()
    {
        StartCoroutine(Change());
    }
    IEnumerator Change()
    {
     
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneName);
        Debug.Log("Wait");
    }

}
