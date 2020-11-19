using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stats : MonoBehaviour
{
    Animator animators; 
    
    public float health;
    public float damage;
    public float animationTime;
    
    public GameObject HealthLoot;
    public GameObject DefenseLoot;
    public GameObject PowerLoot;

    private bool _takeDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        health *= WorldSettings.getMultiplicator();
        animators = gameObject.GetComponent<Animator>();
    }

    public void takeDamage(int domage){
        health -=domage;

        if(health <= 0)
            Die();
    }
    
    void Die(){
        animators.Play("Die");

        System.Random rdm = new System.Random();
        var hasDrop = rdm.Next(1, 3);

        if (hasDrop == 1)
        {
            var loot = rdm.Next(1, 4);
            GameObject lootObject;

            switch (loot)
            {
                case 1:
                    lootObject = Instantiate(HealthLoot, transform.position, transform.rotation);
                    lootObject.name = HealthLoot.name;
                    break;
                case 2:
                    lootObject = Instantiate(PowerLoot, transform.position, transform.rotation);
                    lootObject.name = PowerLoot.name;
                    break;
                case 3:
                    lootObject = Instantiate(DefenseLoot, transform.position, transform.rotation);
                    lootObject.name = DefenseLoot.name;
                    break;
            }
        }
        
        Destroy(transform.gameObject, animationTime);
    }
}