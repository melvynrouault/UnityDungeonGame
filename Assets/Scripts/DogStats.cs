using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogStats : MonoBehaviour
{
    public float health { get => dogHealth; set => dogHealth = value; }
    public float dogHealth;

    public int power { get => dogPower; set => dogPower = value; }
    public int dogPower;
    
    public float defense { get => dogDefense; set => dogDefense = value; }
    public float dogDefense;
    
    public GameObject healthCounter;
    public GameObject powerCounter;
    public GameObject armorCounter;
    public GameObject playMode;

    private int maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        playMode.GetComponent<Text>().text = "Mode " + WorldSettings.Instance.Level;
        updateStats();
    }
    
    public void updateStats()
    {
        healthCounter.GetComponent<Text>().text = health + " / " + maxHealth;
        powerCounter.GetComponent<Text>().text = power.ToString();
        armorCounter.GetComponent<Text>().text = defense.ToString();
    }

    public void takeDamage(float damage)
    {
        if (defense > 0)
        {
            if (defense > damage)
            {
                defense -= damage;
                damage = 0;
            }
            else
            {
                damage -= defense;
                defense = 0;
            }
        }
        
        health -= damage;
        
        updateStats();
    }    
}
