using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiterookcontroller : MonoBehaviour {
	public Vector3 currentposition;
	public int xpos;
	public int ypos;
    public int status;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 getcurrentposition(){
		return currentposition;
	}

	public void setcurrentposition(Vector3 cp){
		this.currentposition = cp;
	}

	public int getxpos(){
		return xpos;
	}

	public int getypos(){
		return ypos;
	}

	public void setxpos(int x){
		xpos = x;
	}

	public void setypos(int y){
		ypos = y;
	}

    public int getstatus()
    {
        return this.status;
    }

}
