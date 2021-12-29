using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTrigger : MonoBehaviour {

    [SerializeField]
    int number;

    int[] index =  new int [4];
    void Start() {
        int k=0;
        
        for(int i=0;i<5;i++)
        {
            if(number!=i)
            {
                index[k]=i;
                k++;
            }
        }
        
        

    }

    public void CreateLand () {
        //Debug.Log (Vector3.right);
        //Debug.Log (Physics.CheckSphere (this.gameObject.transform.position + Vector3.forward * 30, 4));
        int random1=0, random2=0;
        random1=(int)Random.Range(0f,3f);
        while(random1==random2)
        {
        random2=(int)Random.Range(0f,3f);
        }
        
        Debug.Log(random1+"  "+ random2);
        int temp=index[random1];
        index[random1]=index[random2];
        index[random2]=temp;
        if (!Physics.CheckSphere (this.gameObject.transform.position + Vector3.forward * 30, 4)) {
            GameObject clone = Instantiate (GenerateLand.prefabs[index[0]], this.gameObject.transform.position + Vector3.forward * 25, Quaternion.identity);
            Debug.Log (clone);
        }
        if (!Physics.CheckSphere (this.gameObject.transform.position + Vector3.right * 30, 4)) {
            GameObject clone = Instantiate (GenerateLand.prefabs[index[1]], this.gameObject.transform.position + Vector3.right * 25, Quaternion.identity);
            Debug.Log (clone);
        }
        if (!Physics.CheckSphere (this.gameObject.transform.position - Vector3.forward * 30, 4)) {
            GameObject clone = Instantiate (GenerateLand.prefabs[index[2]], this.gameObject.transform.position - Vector3.forward * 25, Quaternion.identity);
            Debug.Log (clone);
        }
        if (!Physics.CheckSphere (this.gameObject.transform.position - Vector3.right * 30, 4)) {
            GameObject clone = Instantiate (GenerateLand.prefabs[index[3]], this.gameObject.transform.position - Vector3.right * 25, Quaternion.identity);
            Debug.Log (clone);
        }
    }
    void OnTriggerEnter (Collider other) {
        
        if (other.tag == "Player") {
            CreateLand ();
            Debug.Log (other);
            //created = true;
        }
    }
    void FixedUpdate () {

        if (Vector3.Distance (GenerateLand.Player.transform.position, this.gameObject.transform.parent.position) > 80) {
            Destroy (this.gameObject.transform.parent.gameObject);
        }
    }

}