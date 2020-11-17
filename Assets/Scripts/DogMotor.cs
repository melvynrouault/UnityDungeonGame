using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMotor : MonoBehaviour
{
    
    // Animations du perso
    private Animator animator;



    // Vitesse de déplacement
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

 


    // Inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
    public string space;

 


    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;

 


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();

 

    }

 

    bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.08f);
    }

 

    void Update()
    {
            // si on avance
            if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, walkSpeed * Time.deltaTime);
                    animator.Play("WalkForwardBattle");
            }

 

            // Si on sprint
            if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, runSpeed * Time.deltaTime);
                animator.Play("RunForwardBattle");
            }

 

            // si on recule
            if (Input.GetKey(inputBack))
            {
                transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
                    animator.Play("WalkForwardBattle");
    
            }

 

            // rotation à gauche 
            if (Input.GetKey(inputLeft))
            {
                transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            }

 

            // rotation à droite 
            if (Input.GetKey(inputRight))
            {
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            }

 

            // Si on avance pas et que on recule pas non plus
            if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack))
            {
                        animator.Play("Idle_Battle");   
            }

 

            // Si on saute
            if (Input.GetKey(space) && IsGrounded())
            {
                // Préparation du saut (Nécessaire en C#)
                Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
                v.y = jumpSpeed.y;

 

                // Saut
                gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
            }
        }
}
