using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{

    Animation animations;

    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;


    public float attackCooldown;
    public bool isAttacking;
    public float currentCooldown;
    public float attackRange;
    public GameObject rayHit;

    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public string inputAttack;


    public Vector3 jumSpeeed;
    CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        // si on avance
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift)){
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
                animations.Play("walk");
        }

        // si on sprint
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift)){
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
                animations.Play("run");
        }

        // si on recule
        if (Input.GetKey(inputBack)){
            transform.Translate(0, 0, -((walkSpeed/2) * Time.deltaTime));
                animations.Play("walk");
        }

        // rotation à gauche
        if (Input.GetKey(inputLeft)){
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        
        // rotation à droite
        if (Input.GetKey(inputRight)){
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }

        
        // Si on avance pas et que on recule pas non plus
        if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack)){
            animations.Play("idle");
        }

        // Si on saute
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) {
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumSpeeed.y;

            gameObject.GetComponent<Rigidbody>().velocity = jumSpeeed;
        }

         // si on avance
        if (Input.GetKey(inputAttack)){
            animations.Play("charge");
        }
    }

    bool isGrounded() {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.08f);
    }
}
