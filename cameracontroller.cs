using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void movecamera(){
		iTween.RotateTo (gameObject, new Vector3 (0f, 180f, 0f), 3.0f);
		//iTween.MoveTo (gameObject, new Vector3 (gameObject.transform.position.x , gameObject.transform.position.y , 43f), 3.0f);
	}

    public void movecamera2()
    {
        iTween.RotateTo(gameObject, new Vector3(0f, 0f, 0f), 3.0f);
        //iTween.MoveTo(gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -43f), 3.0f);
    }

}
