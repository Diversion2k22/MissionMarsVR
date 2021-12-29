using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSpawner : MonoBehaviour
{
    [Header("Belt Settings")]
    [SerializeField]
    GameObject asteroidPrefab;
    [SerializeField]
    int density = 2000;
    [SerializeField]
    int interval = 5;
    
    
    [SerializeField]
    int seed = 1;
    
    [Header("Belt Ellipse Settings")]
    [SerializeField]
    float a = 5;
    [SerializeField]
    float b = 10;
    [SerializeField]
    float width = 10;
    [SerializeField]
    float height = 10;


    [Header("Asteroid Settings")]
    [SerializeField]
    float minOrbitSpeed = 2;
    [SerializeField]
    float maxOrbitSpeed = 5;
    [SerializeField]
    float minRotationSpeed = 1;
    [SerializeField]
    float maxRotationSpeed = 1;
    [SerializeField]
    int minScale = 1;
    [SerializeField]
    int maxScale = 1;


    Vector3[] rotationDirection;
    float randomRadian, x, y, z, useA, useB;
    float[] eachA , eachB, alpha, orbitSpeed, rotationSpeed;
    int i;
    GameObject[] asteroidObjects;
    const float tau = Mathf.PI * 2f;


    //get any point on circle with just angle
    //x = cx + r*cos(a)
    //y = cy + r*sin(a)

    //ellipse
    //


    void Awake() {
        eachA = new float[density];
        eachB = new float[density];
        alpha= new float[density];
        orbitSpeed= new float[density];
        rotationSpeed= new float[density];
        asteroidObjects= new GameObject[density];
        rotationDirection= new Vector3[density];
    }
    void Start() {
        Random.InitState(seed);
        for (i = 0; i < density; i++)
        {
            do{
                //randomRadius = Random.Range(innerRadius, outerRadius);
                randomRadian = Random.Range(0, 2*Mathf.PI);
                useA=Random.Range(a, a+width);
                useB=Random.Range(b, b+width);
                

            
                
                x = useA*Mathf.Cos(randomRadian);
                z = useB*Mathf.Sin(randomRadian);
                

            } while(float.IsNaN(z) && float.IsNaN(x));
            y = Random.Range(-height/2, height/2);
            eachA[i]=useA;
            eachB[i]=useB;
            alpha[i]=randomRadian;


            GameObject asteroid = Instantiate(asteroidPrefab, transform.position+transform.rotation*(new Vector3(x,y,z)), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
            rotationDirection[i] = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            orbitSpeed[i]=(Random.Range(minOrbitSpeed, maxOrbitSpeed))*tau;
            rotationSpeed[i]=(Random.Range(minRotationSpeed, maxRotationSpeed));




            
            asteroid.transform.localScale*=Random.Range(minScale, maxScale);
            asteroid.transform.SetParent(transform);
            asteroidObjects[i]=asteroid;
        }
    }



    private void FixedUpdate()
    {
        
            for (i = 0; i < density; i++)
            {
            
                if(alpha[i]>tau)
                {
                    alpha[i]=0;
                }

                
                asteroidObjects[i].transform.position =  new Vector3 (  Mathf.Sin(alpha[i]) * eachA[i] ,y= asteroidObjects[i].transform.position.y, Mathf.Cos(alpha[i]) * eachB[i] );

                alpha[i]+=orbitSpeed[i];
                

                asteroidObjects[i].transform.Rotate(rotationDirection[i], rotationSpeed[i] * Time.deltaTime);
            }
        
    }

}
