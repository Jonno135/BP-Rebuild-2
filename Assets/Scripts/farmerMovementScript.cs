using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class farmerMovementScript : MonoBehaviour {


		public GameObject[] targets;
		public NavMeshAgent navigation;
		private int i = 0;


		void  Start (){
		navigation = GetComponent<NavMeshAgent>();
		targets = GameObject.FindGameObjectsWithTag("Ready to be farmed!");

			//set first target
			navigation.destination = targets[i].transform.position;  
		print (targets.Length);

		}

		void  Update (){
			float dist= Vector3.Distance(targets[i].transform.position,transform.position);
			//currentTarget = targets[i].transform;
			//if npc reaches its destination (or gets close)...
			if (dist < 2)
			{                
				i++; //change next target      
				if (i < targets.Length )
				{ 
					navigation.destination = targets[i].transform.position; //go to next target by setting it as the new destination
				}

				//check if at end of cycle, then reset to beginning of cycle
				if (i == targets.Length )
				{
					Debug.Log("NAVIGATION FINISHED. RESET.");
					i = 0;
					navigation.destination = targets[i].transform.position;
				}
			}
		}
	}

