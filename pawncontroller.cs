using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawncontroller : MonoBehaviour {
	public Vector3 currentposition;
	public int xpos;
	public int ypos;
	bool firstplay = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public bool getfirstplay(){
		return firstplay;
	}

	public void setfirstplay(bool fp){
		firstplay = fp;
	}

	public Vector3 getcurrentposition (){
		return currentposition;
	}

	public void setcurrentposition(Vector3 cp){
		currentposition = cp;
	}

	public int getxpos(){
		return xpos;
	}

	public int getypos(){
		return ypos;
	}

	public void setxpos(int x){
		this.xpos = x;
	}

	public void setypos(int y){
		this.ypos = y;
	}
}