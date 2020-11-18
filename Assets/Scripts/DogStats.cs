using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogStats : MonoBehaviour
{

    public int health;
    public float power;
    public float defense;
    public bool isAttackPowerUp;

    public GameObject useConsummable;


    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        power = 10.00f;
        defense = 10.00f;
        isAttackPowerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getHealth() {
        return health;
    }

    public void setHealth(int health) {
        this.health = health;
    }

    public float getPower() {
        return power;
    }

    public void setPower(float power) {
        this.power = power;
    }

    public float getDefense() {
        return defense;
    }

    public void setDefense(float defense) {
        this.defense = defense;
    }
}
