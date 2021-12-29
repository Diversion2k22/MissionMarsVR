using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject exp;
    public float expforce, radius;

    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        GameObject _exp=Instantiate(exp, transform.position, transform.rotation);
        Destroy(_exp, 3);
    }
}
