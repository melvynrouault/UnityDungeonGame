using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DogInventory : MonoBehaviour
{
    public string inputConsumable;

    public bool hasItemInSlot;

    public GameObject appleItem;
    public GameObject meatItem;
    public GameObject mpItem;
    
    // Start is called before the first frame update
    void Start()
    {
        hasItemInSlot = false;
        appleItem.SetActive(false);
        meatItem.SetActive(false);
        mpItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(inputConsumable)) {
            var dogStats = gameObject.GetComponent<DogStats>();
            
            if (hasItemInSlot) {
                hasItemInSlot = false;
                
                if(appleItem.activeSelf) {
                    appleItem.SetActive(false);
                    var health = dogStats.health + 20;
                    
                    dogStats.health = health > 100 ? 100 : health;
                }

                if(meatItem.activeSelf) {
                    meatItem.SetActive(false);
                    dogStats.power += 5;
                }

                if(mpItem.activeSelf) {
                    mpItem.SetActive(false);
                    dogStats.defense += 5;
                }
            }
            
            dogStats.updateStats();
        }
    }

    private void OnTriggerEnter(Collider col) {
        if (col.name == "Props_PotionBig_Red" || col.name == "Props_PotionBig_Purple" || col.name == "Props_PotionBig_Blue") {
            if (!hasItemInSlot) {
                hasItemInSlot = true;
                
                switch (col.name)
                {
                    case "Props_PotionBig_Red":
                        appleItem.SetActive(true);
                        break;
                    case "Props_PotionBig_Purple":
                        meatItem.SetActive(true);
                        break;
                    case "Props_PotionBig_Blue":
                        mpItem.SetActive(true);
                        break;
                }
                
                Destroy(col.gameObject);
            }
        }        
    }

}
