using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int slot;
    public string slotItem;

	public GameObject Props_PotionBig_Red;
	public GameObject Props_PotionBig_Purple;
	public GameObject Props_PotionBig_Blue;
    public GameObject resetItem;



    // Start is called before the first frame update
    void Start()
    {
        slot = 0;
        slotItem="";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col) {
        if (col.name == "Props_PotionBig_Red" || col.name == "Props_PotionBig_Purple" || col.name == "Props_PotionBig_Blue") {
            Debug.Log("enter in trigger Consumable");
            if (slot == 0) {
                slot++;
                slotItem = col.name;
                Debug.Log("ItemName : " + slotItem);
            }
        }

        // to replace by onClick methods on interface when user use his potion
        if (col.name == "resetItem") {
            if (slot == 1) {
                slot = 0;
                Debug.Log("Item reset");
            }
        }
    }

}
