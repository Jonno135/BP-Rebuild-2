using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManagerScript : MonoBehaviour {

	[SerializeField]
	private Button a1Btn;
	[SerializeField]
	private Button a2Btn;
	[SerializeField]
	private Button a3Btn;
	[SerializeField]
	private Button a4Btn;
	[SerializeField]
	private Button b1Btn;
	[SerializeField]
	private Button b2Btn;
	[SerializeField]
	private Button b3Btn;
	[SerializeField]
	private Button b4Btn;


	private int[,] cropTiles;

	private int a1;  //STATES: 1 = OPEN PLOT, 2 = GROWING PLANT, 3 = HARVESTABLE PLANT 0 = 404
	private int a2;
	private int a3;
	private int a4;
	private int b1;
	private int b2;
	private int b3;
	private int b4;





	// Use this for initialization
	void Start () {
		a1 = 1;
		a2 = 1;
		a3 = 1;
		a4 = 1;
		b1 = 1;
		b2 = 1;
		b3 = 1;
		b4 = 1;

		cropTiles = new int[2,4] {{a1,a2,a3,a4},{b1,b2,b3,b4}};
		harvest (a1Btn);
		harvest (a2Btn);
		harvest (a3Btn);
		harvest (a4Btn);
		harvest (b1Btn);
		harvest (b2Btn);
		harvest (b3Btn);
		harvest (b4Btn);
		plant (a2Btn);
		plant (b4Btn);
		grow (b3Btn);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){

	}

	private void plant(Button crop){
		ColorBlock newColorBlock = crop.colors;
		newColorBlock.normalColor = Color.green;
		crop.colors = newColorBlock;
	}

	private void harvest(Button crop){
		ColorBlock newColorBlock = crop.colors;
		newColorBlock.normalColor = Color.magenta;
		crop.colors = newColorBlock;
	}

	private void grow(Button crop){
		ColorBlock newColorBlock = crop.colors;
		newColorBlock.normalColor = Color.blue;
		crop.colors = newColorBlock;
	}

	//public int getWorkerTask(){
		/*
		 * 1) if (there are NO open plots to plant AND NO harvestable crops) AND crate is maximum capacity
		 * 		return NO TASK;
		 * 
		 * 2) if there are harvestable crops AND crate is NOT at maximum capacity
		 * 		return OLDEST (FIRST TO COMPLETE) HARVESTABLE PATCH;
		 * 
		 * 3) if there are NO harvestable crops AND there are open plots
		 * 		return OLDEST (FIRST TO BECOME OPEN) CROP PLOT;
		 * 
		 * 4) else error
		 * 
		 */
//	}

	//private 



}
