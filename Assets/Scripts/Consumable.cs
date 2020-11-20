using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Consumable : MonoBehaviour
{
	public GameObject Props_PotionBig_Red;
	public Text PotionPicked;

	public bool GuiOn;

	public string Text = "Potion Picked";

	public Rect BoxSize = new Rect( 0, 0, 200, 100);

	public GUISkin customSkin;


    // Start is called before the first frame update
    void Start()
    {
        PotionPicked = PotionPicked.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider col) {
        if (col.name == "Props_PotionBig_Red") {
            Debug.Log("enter in trigger Consumable");
            Debug.Log(PotionPicked);
		    GuiOn = true;

        }
    }
    
    private void OnTriggerExit() 
	{
		GuiOn = false;
	}


    void OnGUI()
	{

		if (customSkin != null)
		{
			GUI.skin = customSkin;
		}

		if (GuiOn == true)
		{
			// Make a group on the center of the screen
			GUI.BeginGroup (new Rect ((Screen.width - BoxSize.width) / 2, (Screen.height - BoxSize.height), BoxSize.width, BoxSize.height));
			// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

			GUI.Label(BoxSize, Text);

			// End the group we started above. This is very important to remember!
			GUI.EndGroup ();

		}


	}
}
