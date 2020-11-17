using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogStats : MonoBehaviour
{

    public int heatlh;
    public float power;
    public float defense;
    public bool isAttackPowerUp;

    public GameObject useConsummable;


    // Start is called before the first frame update
    void Start()
    {
        heatlh = 100;
        power = 10.00f;
        defense = 10.00f;
        isAttackPowerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // to replace by onClick methods on interface when user use his potion
    private void OnTriggerEnter(Collider col) {
        // Red potion (health)
        if(col.name == "useConsummable") {
            heatlh += 10;
            Debug.Log("stats Changed");

        }
    }
}
