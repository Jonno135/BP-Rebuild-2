using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class farmWorker : MonoBehaviour {

	/*
	 * WORKER STATS 
	 * LEVEL
	 * MOVE SPEED
	 * CAPACITY
	 */

	[SerializeField]
	private int level;
	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private int capacity;
	[SerializeField]
	private int holding;

	public Vector2 aPosition0 = new Vector2 (0,0);
	public Vector2 aPosition1 = new Vector2 (-400,600);
	private Rigidbody2D farmerJon;

	public bool isWalking;
	public float walkTime;
	public float waitTime;
	private float waitCounter;
	private float walkCounter;

	private int WalkDirectionX;
	private int WalkDirectionY;
	private int currentTask; // 0 = idle, 1 = walking left, 2 = walking down, 3 = walking left, 4 = walking up;
	private Vector2 topLeftCorner = new Vector2(-45,60);
	private Vector2 topRightCorner = new Vector2(45,60);
	private Vector2 bottomLeftCorner = new Vector2(-45,-60);
	private Vector2 bottomRightCorner = new Vector2(45,-60);
	private Vector2 currentPosition;



	[SerializeField]
	private Vector2 direction;
//	[SerializeField]
//	private int potatoCount;
//	[SerializeField]
//	private int tomatoCount;
//	[SerializeField]
//	private int carrotCount;

//	private bool runUpAndDown;
//	private bool goingUp;
//	private bool droppingOffLoad;
//	private bool harvesting;
//	private bool walking;
//	private bool hasTask;


	// Use this for initialization
	void Start () {
//		runUpAndDown = true;
//		goingUp = false;
//		walking = false;
//		droppingOffLoad = false;
//		harvesting = false;
		farmerJon = GetComponent<Rigidbody2D>();
		waitCounter = waitTime;
		walkCounter = walkTime;
		currentTask = 1;
		farmerJon.transform.position = topRightCorner;
		//currentPosition = new Vector2 (farmerJon.transform.position.x, farmerJon.transform.position.y);

	}

	void FixedUpdate(){

		//some stuff

		switch(currentTask){
		case 1: //walking to top left corner
			farmerJon.transform.position = Vector2.MoveTowards (new Vector2 (farmerJon.transform.position.x, farmerJon.transform.position.y), topLeftCorner, moveSpeed);
			print ("in case" + currentTask);
			if(farmerJon.transform.position.x <= -45){
				currentTask = 2;
			}
			break;
		case 2: //walking to bottom left corner
			farmerJon.transform.position = Vector2.MoveTowards (new Vector2 (farmerJon.transform.position.x, farmerJon.transform.position.y), bottomLeftCorner, moveSpeed);
			print ("in case" + currentTask);
			if(farmerJon.transform.position.y <= -60){
				currentTask = 3;
			}
			break;
		case 3: //walking to bottom right corner
			farmerJon.transform.position = Vector2.MoveTowards (new Vector2 (farmerJon.transform.position.x, farmerJon.transform.position.y), bottomRightCorner, moveSpeed);
			print ("in case" + currentTask);
			if(farmerJon.transform.position.x >= 45){
				currentTask = 4;
			}
			break;
		case 4: //walking to top right corner
			farmerJon.transform.position = Vector2.MoveTowards (new Vector2 (farmerJon.transform.position.x, farmerJon.transform.position.y), topRightCorner, moveSpeed);
			print ("in case" + currentTask);
			if(farmerJon.transform.position.y >= 60){
				currentTask = 1;
			}
			break;
		}
	}
	
//	// Update is called once per frame
//	void Update () {
//		//farmerJon.velocity = new Vector2 (moveSpeed, moveSpeed);
////		if (!hasTask) {
////			getTask ();
////		}
//
////		if(isWalking){
////			walkCounter -= Time.deltaTime;
////
////			switch (WalkDirectionX) {
////			case 0:
////				farmerJon.transform.position = Vector2.MoveTowards (new Vector2 (farmerJon.transform.position.x, farmerJon.transform.position.y), aPosition1, 3 * Time.deltaTime);
////				print ("STFU");
////				break;
////
////			}
////				if (walkCounter < 0) {
////					isWalking = false;
////					waitCounter = waitTime;
////
////			}
////		} else {
////			waitCounter -= Time.deltaTime;
////			farmerJon.velocity = Vector2.zero;
////
////			if(waitCounter > 0){
////				chooseDestination ();
////			}
////
////		}
////	}
//	}
//	void FixedUpdate() {
//		//float moveSpeedAndTime = moveSpeed * Time.deltaTime;
//		//farmerJon.transform.position = Vector2.MoveTowards (new Vector2 (farmerJon.transform.position.x, 62), aPosition1, (moveSpeed) * Time.deltaTime);'
//		if(farmerJon.transform.position.x > -20){
//			farmerJon.transform.position = Vector2.MoveTowards(new Vector2(farmerJon.transform.position.x, 62),aPosition1, moveSpeed);
//		}
//		farmerJon.transform.position = Vector2.MoveTowards(new Vector2(-45, farmerJon.transform.position.y),new Vector2(-45, -60), moveSpeed);
//	}

	void Awake (){
		//farmerJon = GetComponent<Rigidbody2D> ();
	}

	public void chooseDestination () {
		WalkDirectionX = 0;
		WalkDirectionY = Random.Range(0,2);
	
	}

//	private void getTask(){
//		if(droppingOffLoad){
//			droppingOffLoad = false;
//			harvesting = true;
//			walking = true;
//		} else if(harvesting) {
//			harvesting = false;
//			walking = true;
//			droppingOffLoad = true;
//		} else if(){
//
//		}
//	}

//	public void Move(){
//		transform.Translate (getDirection()*getMoveSpeed());
//	}
//
//	private float getMoveSpeed(){
//		return moveSpeed*Time.deltaTime;
//	}
//
//	private Vector2 getDirection(){
//		Vector2 newDirection = Vector2.down;
//		if(runUpAndDown){
//			print (transform.position.y);
//			if (transform.position.y > 85) {
//				print("goingDown");
//				newDirection = Vector2.down;
//				if (goingUp) {
//					goingUp = !goingUp;
//				}
//			} else if (transform.position.y < -85) {
//				print("goingUp");
//				newDirection = Vector2.up;
//				if (!goingUp) {
//					goingUp = !goingUp;
//				}
//
//			}
//
//		}
//		return newDirection;
//
//		//void 
//	}

//	private void harvest(){
//		/*
//		 * pre: is near a workable planting area, isn't at maximum capacity
//		 * 
//		 * WORKER IS IDLE WHILE "FARMING"
//		 * AFTER TIME TO HARVEST PLANT IS COMPLETE +1 THAT TYPE OF PLANT and +1 HOLDING
//		 * while (capacity isnt maximum && area still workable)
//		 * 		harvest again
//		 * 
//		 * // 
//		 * post: capacity = maximum OR planting area is no longer workable
//		 * 		 if(capacity is maximum)
//		 * 			harvesting = false;
//		 * 			dropping off = true;
//		 * 			walking = true;
//		 * 		 else if(capacity is NOT maximum)
//		 * 			if(there exists a workable planting area)
//		 * 				harvesting = true;
//		 * 				walking = true;
//		 * 			else // there DOES NOT exist a workable planting area
//		 * 				dropping off = true;
//		 * 				walking = true;
//		 * 				harvesting = false;
//		 */ 
//	}

//	private void droppingOff(){
//		/*
//		 * pre: (worker's capacity is full OR no workable areas)
//		 * 
//		 * dropOffStuff()
//		 * 
//		 * post: Worker's holding = 0
//		 * 		workerCheckForTask()
//		 */ 
//	}

//	private void walking(){
//		/*
//		 * pre: figure out a task
//		 * 
//		 * go to that task's destination
//		 * 
//		 * post: worker position is at a workable area or drop off zone
//		 * 
//		 */ 
//	}

}
