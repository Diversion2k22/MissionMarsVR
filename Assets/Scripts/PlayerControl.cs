using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    float Speed = 3.5f;
    [SerializeField]
    float Gravity = 10f;
    [SerializeField]
    //we use character controller as it allows us to move our player constrained by collision but without having to deal with rigidbody
    CharacterController PlayerController;
    private void Update()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        //to move player in x axis
        float horizontal = Input.GetAxis("Horizontal");
        // to move player in z axis
        float vertical = Input.GetAxis("Vertical");
        //calculate direction using transform values of player gameobject
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        //calculate velocity then move our camera accordingly
        Vector3 velocity = direction * Speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
       
        //velocity.y will be use for jump but in our project we are not using jumps
        velocity.y -= Gravity;
        PlayerController.Move(velocity * Time.deltaTime);
    }
}
