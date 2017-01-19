using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class chesscontroller : MonoBehaviour {

	int[,] chesspositions;
	Vector3[,] boardvectors;
	Vector3[,] upperranges;
	Vector3[,] lowerranges;
	Ray ray;
	public GameObject possibleposition;
	float perdiffallowed = 0.001f;
	GameObject selectedobject;
	// Use this for initialization
	void Start () {
		Vector3 topleft = new Vector3 (-20.9f, 0.3023f, 21.02f);

		boardvectors = new Vector3[8, 8];
		upperranges = new Vector3[8, 8];
		lowerranges = new Vector3[8, 8];
		for (int i = 0; i < 8; i++) {
			float z = i * 6;
			for (int j = 0; j < 8; j++) {
				float x = j * 6;
				boardvectors [i, j] = new Vector3 (topleft.x + x , topleft.y , topleft.z - z);
				upperranges [i, j] = new Vector3 (topleft.x + (x - 2.5f), topleft.y, topleft.z - (z + 2.5f));
				lowerranges [i, j] = new Vector3 (topleft.x + (x + 2.5f), topleft.y, topleft.z - (z - 2.5f));
				//print (upperranges [i, j] + " " + lowerranges [i, j]);
				//Instantiate (possibleposition , boardvectors[i,j] , Quaternion.Euler(0f,0f,0f));
			}
		}


		chesspositions = new int[8,8];
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				if (i == 0 || i == 1) {
					chesspositions [i,j] = 2;
				}else if(i == 6 || i == 7){
					chesspositions[i,j] = 1;
				}else {
					chesspositions [i,j] = 0; 
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;  
			if (Physics.Raycast (ray, out hit, 100.0f)) {
				if (hit.collider.tag == "possibleposition") {
					//move the selected gameobject to that position
					if (selectedobject.tag == "whitepawn") {
						for (int i = 0; i < 8; i++) {
							for (int j = 0; j < 8; j++) {
								//print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
								//print(selectedobject.transform.position);
								if (selectedobject.transform.position.x >= upperranges[i,j].x && selectedobject.transform.position.x <= lowerranges[i,j].x &&  selectedobject.transform.position.z >= upperranges[i,j].z && selectedobject.transform.position.z <= lowerranges[i,j].z ) {
									//print ("here");
									chesspositions [i, j] = 0;
									// printchesspositions ();
									break;
								} 
							}
						}
						iTween.MoveTo (selectedobject, hit.collider.gameObject.transform.position, 2.0f);
						selectedobject.GetComponent<pawncontroller> ().setfirstplay (false);
						selectedobject.GetComponent<pawncontroller> ().setcurrentposition (hit.collider.gameObject.transform.position);
						for (int i = 0; i < 8; i++) {
							for (int j = 0; j < 8; j++) {
								//print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
								if (hit.collider.gameObject.transform.position.x >= upperranges[i,j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i,j].x &&  hit.collider.gameObject.transform.position.z >= upperranges[i,j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i,j].z ) {
									//print ("here");
									chesspositions [i, j] = 1;
									selectedobject.GetComponent<pawncontroller> ().setxpos (i);
									selectedobject.GetComponent<pawncontroller> ().setypos (j);
									//printchesspositions ();
									break;
								}
							}
						}
						GameObject[] temps = GameObject.FindGameObjectsWithTag ("possibleposition");
						for (int i = 0; i < temps.Length; i++)
							Destroy (temps [i]);
					}else if(selectedobject.tag == "whiterook"){

						for (int i = 0; i < 8; i++) {
							for (int j = 0; j < 8; j++) {
								//print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
								//print(selectedobject.transform.position);
								if (selectedobject.transform.position.x >= upperranges[i,j].x && selectedobject.transform.position.x <= lowerranges[i,j].x &&  selectedobject.transform.position.z >= upperranges[i,j].z && selectedobject.transform.position.z <= lowerranges[i,j].z ) {
									//print ("here");
									chesspositions [i, j] = 0;
									// printchesspositions ();
									break;
								} 
							}
						}

						iTween.MoveTo (selectedobject, hit.collider.gameObject.transform.position, 2.0f);
						selectedobject.GetComponent<whiterookcontroller> ().setcurrentposition (hit.collider.gameObject.transform.position);
						GameObject[] temps = GameObject.FindGameObjectsWithTag ("possibleposition");
						for (int i = 0; i < 8; i++) {
							for (int j = 0; j < 8; j++) {
								//print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
								if (hit.collider.gameObject.transform.position.x >= upperranges[i,j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i,j].x &&  hit.collider.gameObject.transform.position.z >= upperranges[i,j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i,j].z ) {
									//print ("here");
									chesspositions [i, j] = 1;
									selectedobject.GetComponent<whiterookcontroller> ().setxpos (i);
									selectedobject.GetComponent<whiterookcontroller> ().setypos (j);
									//printchesspositions ();
									break;
								}
							}
						}
						for (int i = 0; i < temps.Length; i++)
							Destroy (temps [i]);
					}
				}
				if (hit.collider.tag == "whitepawn") {
					//display prefab of cube on possible locations
					//Debug.Log("here");
					pawncontroller pc = hit.collider.gameObject.GetComponent<pawncontroller>();
					if (pc.getfirstplay () == true) {
						GameObject[] temps = GameObject.FindGameObjectsWithTag ("possibleposition");
						for (int i = 0; i < temps.Length; i++)
							Destroy (temps [i]);
						GameObject temp;
						Vector3 currentposition = pc.getcurrentposition ();
						temp = (GameObject)Instantiate (possibleposition, new Vector3 (currentposition.x, currentposition.y, currentposition.z + 6f), Quaternion.Euler (0f, 0f, 0f));
						temp.tag = "possibleposition";
						temp = (GameObject)Instantiate (possibleposition, new Vector3 (currentposition.x, currentposition.y, currentposition.z + 12f), Quaternion.Euler (0f, 0f, 0f));
						temp.tag = "possibleposition";
						selectedobject = hit.collider.gameObject;
					} else if (pc.getfirstplay () == false) {
			 			if (pc.getcurrentposition ().z <= 23.02 && pc.getcurrentposition ().z >= 19.02) {
						}else{
							GameObject[] temps = GameObject.FindGameObjectsWithTag ("possibleposition");
							for (int i = 0; i < temps.Length; i++)
								Destroy (temps [i]);
							GameObject temp;
							Vector3 currentposition = pc.getcurrentposition ();
							temp = (GameObject)Instantiate (possibleposition, new Vector3 (currentposition.x, currentposition.y, currentposition.z + 6f), Quaternion.Euler (0f, 0f, 0f));
							temp.tag = "possibleposition";
							selectedobject = hit.collider.gameObject;
						}
					}
				}
				if (hit.collider.tag == "whiterook") {
					   //Debug.Log ("here");
					GameObject[] temps = GameObject.FindGameObjectsWithTag ("possibleposition");
					for (int i = 0; i < temps.Length; i++)
						Destroy (temps [i]);
					whiterookcontroller wrc = hit.collider.gameObject.GetComponent<whiterookcontroller>();
					Vector3 currentpos = wrc.getcurrentposition ();
					int count = 1;
					//top possiblepositions
					try{
						while(chesspositions[wrc.getxpos()-count , wrc.getypos()]!=1){
							GameObject temp;
							temp = Instantiate (possibleposition, new Vector3 (currentpos.x , currentpos.y , currentpos.z + (6*count)), Quaternion.Euler (0f, 0f, 0f));
							temp.tag = "possibleposition";
							count++;
						}
					}catch(Exception e){
						//handle the exception
					}
					try{
					count = 1;
					while(chesspositions[wrc.getxpos()+count , wrc.getypos()]!=1){
						GameObject temp;
						temp = Instantiate (possibleposition, new Vector3 (currentpos.x , currentpos.y , currentpos.z - (6*count)), Quaternion.Euler (0f, 0f, 0f));
						temp.tag = "possibleposition";
						count++;
						}
					}catch(Exception e){
						//print (e.Message);
					}
					try{
						count = 1;
						while(chesspositions[wrc.getxpos() , wrc.getypos()-count]!=1){
							GameObject temp;
							temp = Instantiate (possibleposition, new Vector3 (currentpos.x - (6*count), currentpos.y , currentpos.z ), Quaternion.Euler (0f, 0f, 0f));
							temp.tag = "possibleposition";
							count++;
						}
					}catch(Exception e){
						//print (e.Message);
					}
					try{
						count = 1;
						while(chesspositions[wrc.getxpos() , wrc.getypos()+count]!=1){
							GameObject temp;
							temp = Instantiate (possibleposition, new Vector3 (currentpos.x + (6*count), currentpos.y , currentpos.z ), Quaternion.Euler (0f, 0f, 0f));
							temp.tag = "possibleposition";
							count++;
						}
					}catch(Exception e){
						//print (e.Message);
					}
					selectedobject = hit.collider.gameObject;
				}
			}
		}
	}

	public void printchesspositions(){
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				Debug.Log (i+" "+j+" "+chesspositions [i, j]);
			}
		}
	}

}
