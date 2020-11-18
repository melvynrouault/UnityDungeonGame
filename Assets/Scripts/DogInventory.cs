using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInventory : MonoBehaviour
{
    public string inputConsumable;

    public int slot;
    public string slotItem;

    public int localHealth;
    public float localPower;
    public float localDefense;

	public GameObject Props_PotionBig_Red;
	public GameObject Props_PotionBig_Purple;
	public GameObject Props_PotionBig_Blue;
    public GameObject resetItem;


    public GameObject appleItem;
    public GameObject meatItem;
    public GameObject mpItem;

    



    // Start is called before the first frame update
    void Start()
    {

        slot = 0;
        slotItem="";
        appleItem.SetActive(false);
        meatItem.SetActive(false);
        mpItem.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(inputConsumable)) {
            if (slot == 1) {
                
                slot = 0;
                slotItem="";

                if(appleItem.activeSelf) {
                    Debug.Log("Add health");
                    appleItem.SetActive(false);
                    localHealth = gameObject.GetComponent<DogStats>().getHealth();
                    localHealth += 10;
                    gameObject.GetComponent<DogStats>().setHealth(localHealth);
                }

                if(meatItem.activeSelf) {
                    Debug.Log("Add power");
                    meatItem.SetActive(false);
                    localPower = gameObject.GetComponent<DogStats>().getPower();
                    localPower += 5.00f;
                    gameObject.GetComponent<DogStats>().setPower(localPower);

                }

                if(mpItem.activeSelf) {
                    Debug.Log("Add Defense");
                    mpItem.SetActive(false);
                    localDefense = gameObject.GetComponent<DogStats>().getDefense();
                    localDefense += 5.00f;
                    gameObject.GetComponent<DogStats>().setDefense(localDefense);

                }
                Debug.Log("Item reset");
            }
        }
    }

    private void OnTriggerEnter(Collider col) {
        if (col.name == "Props_PotionBig_Red" || col.name == "Props_PotionBig_Purple" || col.name == "Props_PotionBig_Blue") {
            if (slot == 0) {
                slot++;
                slotItem = col.name;
                
                Debug.Log("ItemName : " + slotItem);

                if (col.name == "Props_PotionBig_Red") {

                    appleItem.SetActive(true);

                    Debug.Log("Apple Appears");

                }

                if (col.name == "Props_PotionBig_Purple") {

                    meatItem.SetActive(true);

                    Debug.Log("Meat Appears");

                }

                if (col.name == "Props_PotionBig_Blue") {

                    mpItem.SetActive(true);

                    Debug.Log("mp Appears");

                }
            }
        }        
    }

}
