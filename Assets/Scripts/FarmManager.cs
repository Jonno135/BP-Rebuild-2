using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour {

	[SerializeField]
	private Crop cropA1;
	[SerializeField]
	private Crop cropA2;
	[SerializeField]
	private Crop cropA3;
	[SerializeField]
	private Crop cropA4;
	[SerializeField]
	private Crop cropB1;
	[SerializeField]
	private Crop cropB2;
	[SerializeField]
	private Crop cropB3;
	[SerializeField]
	private Crop cropB4;


	private Crop[] cropList;
	private int numCrops = 8;

	// Use this for initialization
	void Start () {
		initCropList ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		displayCropStatus ();
	}

	public void plant(Crop crop){
		crop.status = 1;
	}

	public void grow(Crop crop){
		crop.status = 2;
	}

	public void harvest(Crop crop){
		crop.status = 0;
	}

	public Crop[] getEmptyCrops(){
		Crop[] openCrops = new Crop[numCrops];
		int counter = 0;
		foreach (Crop a in cropList){
			if (a.status == 0) {
				openCrops [counter] = a;
				counter++;
			}
		}
		return openCrops;
	}

	public Crop[] getHarvestableCrops(){
		Crop[] harvestableCrops = new Crop[numCrops];
		int counter = 0;
		foreach (Crop a in cropList){
			if (a.status == 2) {
				harvestableCrops [counter] = a;
				counter++;
			}
		}
		return harvestableCrops;
	}

	public Crop[] getCropList(){
		return cropList;
	}

	private void displayCropStatus(){
		//print (cropList);
		foreach (Crop c in cropList) {
			c.cropTxt.text = "Status: " + c.status;
		}
	}

	private void initCropList(){
		cropList = new Crop[numCrops];
		cropList [0] = cropA1;
		cropList [1] = cropA2;
		cropList [2] = cropA3;
		cropList [3] = cropA4;
		cropList [4] = cropB1;
		cropList [5] = cropB2;
		cropList [6] = cropB3;
		cropList [7] = cropB4;
	}
}
