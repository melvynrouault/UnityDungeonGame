using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    //Animation du perso 
    Animator animators; 

    //vitesse de déplacement
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

    //Inputs 
    public string inputFront; 
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public string inputAttack;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider; 

    // Variables concernant l'attaque
    public float attackCooldown; 
    private bool isAttacking; 
    private float currentCooldown;

    // Le personnage est-il mort ? 

    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        animators = gameObject.GetComponent<Animator>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    bool IsGrounded() 
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.08f);
    }

    // Update is called once per frame
    void Update()
    {

        // si on avance
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);

            if (!isAttacking)
            {
                animators.Play("WalkForwardBattle");
            }

            if (Input.GetKey(inputAttack)) 
            {
                Attack();
            }
        }

        //Si on sprint
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            animators.Play("RunForwardBattle");
        }

        if (Input.GetKey(inputBack)) {
            transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);

            if (!isAttacking)
            {
                animators.Play("WalkForwardBattle");
            } 

            if (Input.GetKey(inputAttack)) 
            {
                Attack();
            }
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

        // si on avance pas et que l'on ne recule pas
        if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack)) 
        {
            if (!isAttacking)
            {
                animators.Play("Idle_Battle");
            } 
            
            if (Input.GetKey(inputAttack)) 
            {
                Attack();
            }
        }

        //si on saute

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            //Préparation du saut
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumpSpeed.y; 

            //Saut
            gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
        }

        

        //Attaque 

        if (isAttacking)
        {
            currentCooldown -= Time.deltaTime; 
        }

        if (currentCooldown <= 0) 
        {
            currentCooldown = attackCooldown; 
            isAttacking = false;
        }
    }

    public void Attack() 
    {
        isAttacking = true; 
        animators.Play("Attack01");
    }
}
