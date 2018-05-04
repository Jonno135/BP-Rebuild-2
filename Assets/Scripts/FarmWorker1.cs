using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmWorker1 : MonoBehaviour {

	[SerializeField]
	private FarmManager farm;
	private Rigidbody2D farmWorker;
	public Transform[] target;

	private Vector2 dropOffPos = new Vector2(25,25);

	//Stats
	private float speed;
	private int maxCapacity;
	private int numPotatos;

	// Use this for initialization
	void Start () {
		farm.getCropList ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		act (determineStatus ());
	}

	private void plant(Crop crop){
		farm.plant(findNearestEmptyCrop());
	}

	private void harvest(Crop crop){
		//findNearestHarvestableCrop
		//farm.harvest(crop)
		//potatoCount++;
	}

	private void idle(){
		//moveToIdleSpot
		//wait?
	}

	private void dropOff(){
		moveTo (dropOffPos);
		//while not there ^ ?
		//then
		//farm.dropOff(potatoCount);
		//potatoCount = 0;
	}

	private int determineStatus(){
		/*
		 * if (theres a crop with status 2 AND worker !atCapacity)
		 * status = 1; //pick crop
		 * else if (theres a crop with status 0 AND worker !atCapacity)
		 * status = 2; //plant crop
		 * else if (!atCapacity)
		 * status = 0; //idle
		 * else if (atCapacity)
		 * status = 3; //drop off
		 */
		int sts = -1;
		if(!atCapacity() && farm.getHarvestableCrops().Length != 0){
			sts = 1; //pickCrop
		} else if (!atCapacity() && (farm.getEmptyCrops().Length != 0)) {
			sts = 2; //plantCrop
		} else if (!atCapacity()) {
			sts = 0; //idle
		} else if (atCapacity()) {
			sts = 3; //drop off
		}
		return sts;
	}

	private void act(int status){
		switch(status){
		case 1:
			//harvest (crop);
			break;
		case 2:
			//plant(crop);
			break;
		case 0:
			//idle()
			break;
		case 3:
			//dropOff()
			break;
		}
	}

	private Crop findNearestEmptyCrop(){
		Crop[] emptyCrops = farm.getEmptyCrops ();
		float shortestDistance = Mathf.Infinity;
		Crop nearestCrop;
		if(emptyCrops != null){
			foreach (Crop c in emptyCrops) {
				float dist = getDistanceTo (c.transform.position);
				if( dist < shortestDistance) {
					nearestCrop = c;
				}
			}
		}
		return nearestCrop;
	}

	private void findNearestHarvestableCrop(){
		//for each empty crop
		//calculate the minimum distance
		//return that crop
	}

	private void moveTo(Vector2 destination){
		if ((Vector2)farmWorker.transform.position != destination) {
			Vector2 pos = Vector2.MoveTowards (destination, destination, speed * Time.deltaTime);
			farmWorker.transform.position = pos;
		}
	}

	private float getDistanceTo(Vector2 destination){
		return Vector2.Distance (farmWorker.transform.position, destination);
	}

	private bool atCapacity(){
		if (numPotatos < maxCapacity) {
			return false;
		}
		return true;
	}

}
