using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketBehaviour : MonoBehaviour
{
    public Animator anim;
    public AudioSource source;
    public AudioClip audio;
    public GameObject smoke;
    [SerializeField]
    LevelIndicatorAnimation IndicatorAnimation;
    private bool hasPlayed = false;
    // public string SceneName;
    // public GameObject cameraObject;
    //Camera myCamera;
    void Start()
    {
        //StartCoroutine(Change());
        anim.enabled = false;
        source.enabled = false;
        smoke.SetActive(false);
       // Camera myCamera = cameraObject.GetComponent<Camera>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Camera.main.nearClipPlane = 2.0f;
            source.enabled=true;
            if (!hasPlayed)
            {
                source.PlayOneShot(audio);
                hasPlayed = true;
            }
               
            Debug.Log("Sound");
            IndicatorAnimation.ShowLevel();
            Debug.Log("Text");
            StartCoroutine(Change());
        }
           
    }
    IEnumerator Change()
    {
        yield return new WaitForSeconds(20f);
        anim.enabled = true;
        smoke.SetActive(true);
        Debug.Log("Wait");
    }
}