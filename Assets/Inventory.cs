using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int slot;
    public string slotItem;

	public GameObject Props_PotionBig_Red;



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
        if (col.name == "Props_PotionBig_Red") {
            Debug.Log("enter in trigger Consumable");
            if (slot == 0) {
                slot++;
                slotItem = col.name;
                Debug.Log("ItemName : " + slotItem);
            }
        }
    }

}
