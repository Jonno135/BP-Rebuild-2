using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TalkingScript : MonoBehaviour {


	public GameObject reply1;
	public GameObject reply2;
	public GameObject reply3;
	public GameObject reply4;

	public Text managerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onTap(){
		GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

		if (clickedButton == reply1) {
			managerText.text = "Sure! What would you like to do?";
		} else if(clickedButton == reply2) {
			managerText.text = "Exciting!  What kind of upgrades did you have in mind?";
		} else if(clickedButton == reply3) {
			managerText.text = "George Bush did 9/11 I was there.";
		} else if(clickedButton == reply4) {
			managerText.text = "See you later!  Don't forget to come back and collect the goods!";
		} else{
			//error;
		}
	}
}
