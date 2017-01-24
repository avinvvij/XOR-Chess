using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateusingkeys : MonoBehaviour {

    public float speed=2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(new Vector3(gameObject.transform.rotation.x , gameObject.transform.rotation.y + speed , gameObject.transform.rotation.z));
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y - speed, gameObject.transform.rotation.z));
        }
    }
}
