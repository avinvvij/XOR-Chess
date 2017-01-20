using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteknightcontroller : MonoBehaviour {

	public Vector3 currentposition;
	public int xpos;
	public int ypos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 getcurrentposition(){
		return this.currentposition;
	}

	public void setcurrentposition(Vector3 cp){
		this.currentposition = cp;
	}

	public int getxpos(){
		return this.xpos;
	}

	public void setxpos(int x){
		this.xpos = x;
	}

	public int getypos(){
		return this.ypos;
	}

	public void setypos(int y){
		this.ypos = y;
	}

}
