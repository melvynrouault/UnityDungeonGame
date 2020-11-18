using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Stats : MonoBehaviour
{
    Animator animators; 
    public int maxHealth;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animators = gameObject.GetComponent<Animator>();
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int domage){
        currentHealth -=domage;
        Debug.Log("TakeDamage");
        if(currentHealth <= 0){
            Die();
        }
    }
    void Die(){
        Debug.Log("Die");
 
        animators.Play("Die");
        Destroy(transform.gameObject, 5);
 
 
    }
}