using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    CapsuleCollider playerCollider; 

    // Variables concernant l'attaque
    public float attackCooldown; 
    private bool isAttacking; 
    private float currentCooldown;
    public float attackRange; 

    // Le personnage est-il mort ? 
    public bool isDead = false;

    private bool takeDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        animators = gameObject.GetComponent<Animator>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
        if (isDead) return;

        Hit();
        if (takeDamage) return;

        // si on avance
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);

            if (!isAttacking && !takeDamage)
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

            if (!isAttacking && !takeDamage)
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
            if (!isAttacking && !takeDamage)
            {
                animators.Play("Idle_Battle");
            } 
            
            if (Input.GetKey(inputAttack)) 
            {
                Attack();
            }
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
        
        if (takeDamage)
        {
            animators.Play("GetHit");
            StartCoroutine(hitAnimation());
            takeDamage = false;
        }
    }

    public void Attack() 
    {
        if (!isAttacking) 
        {
            animators.Play("Attack01");
 
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * 0.25f, transform.TransformDirection(Vector3.forward), out hit, attackRange)) 
            {
                Debug.DrawLine(transform.position + Vector3.up * 0.25f, hit.point, Color.red); 
 
                if (hit.transform.CompareTag("test")) {
                    hit.transform.GetComponent<Stats>().takeDamage(transform.GetComponent<DogStats>().power);        
                }
            }
            isAttacking = true;
        }   
    }
    
    public void Hit()
    {
        if (transform.GetComponent<DogStats>().health <= 0) return;
        
        if (takeDamage)
        {
            animators.Play("GetHit");

            StartCoroutine(hitAnimation());
        }
    }
    
    public void Dead()
    {
        if (transform.GetComponent<DogStats>().health > 0) return;
        
        isDead = true;
        animators.Play("Die");
        
        StartCoroutine(dieAnimation());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;
        
        var objet = collision.gameObject;

        if (!objet.CompareTag("test")) return;
        if (objet.GetComponent<Stats>().health <= 0) return;
        
        transform.GetComponent<DogStats>().takeDamage(objet.GetComponent<Stats>().damage * WorldSettings.getMultiplicator());
        takeDamage = true;
    }
    
    IEnumerator dieAnimation()
    {
        yield return new WaitForSeconds(2);
        
        SceneManager.LoadScene("LaunchScene");
    }

    IEnumerator hitAnimation()
    {
        yield return new WaitForSeconds(0.8f);

        takeDamage = false;
    }
}
