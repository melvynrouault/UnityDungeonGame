using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItem : MonoBehaviour
{
    // Start is called before the first frame update
        public Rigidbody drop;
        public Transform cible;
        public  GameObject dropt2;


    void Start()
    {
                Debug.Log("Vous avez finis le tuto");
                float r = Random.Range(0f, 1f);
                float g = Random.Range(0f, 1f);
                float b = Random.Range(0f, 1f);

                Color randomColor = new Color(r, g, b);
         gameObject.GetComponent<Renderer>().material.SetColor("_Color", randomColor);

        Instantiate (drop,transform.position, transform.rotation);
        // GameObject potion = Instantiate (drop,this.transform.position, this.transform.rotation)  as GameObject;
   //  GameObject potion = GameObject.Instantiate (dropt2, transform.position, drop.transform.rotation) as GameObject;
        
     //potion.transform.Rotate (0f, 180f, 0f);
     // GameObject.Instantiate (dropt2, transform.position, transform.rotation * Quaternion.Euler (0f, 180f, 0f));
    }

    // Update is called once per frame

}
