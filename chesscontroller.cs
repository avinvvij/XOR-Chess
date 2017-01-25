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
		public GameObject possibleposition , cameraholder , selectedsurround;
		float perdiffallowed = 0.001f;
		GameObject selectedobject;
		Hashtable ht;
		bool whiteplay = true;
        public float timeoftransition=1.0f; 
        

		// Use this for initialization
		void Start () {
			ht = new Hashtable ();
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
                if (i == 0)
                {
                    switch (j)
                    {
                        case 0:
                        case 7:
                            chesspositions[i, j] = 7;
                            break;
                        case 1:
                        case 6:
                            chesspositions[i, j] = 10;
                            break;
                        case 2:
                        case 5:
                            chesspositions[i, j] = 9;
                            break;
                        case 3:
                            chesspositions[i, j] = 8;
                            break;
                        case 4:
                            break;

                    }
                }else if (i == 1) {
						chesspositions [i,j] = 6;
					}else if(i == 6){
						chesspositions[i,j] = 1;
					}else if(i==7){
                    switch (j)
                    {
                        case 0:
                        case 7:
                            chesspositions[i, j] = 2;
                            break;
                        case 1:
                        case 6:
                            chesspositions[i, j] = 5;
                            break;
                        case 2:
                        case 5:
                            chesspositions[i, j] = 4;
                            break;
                        case 3:
                            chesspositions[i, j] = 3;
                            break;
                        case 4:
                            break;

                    }
                }
                else
                {
                    chesspositions[i, j] = 0;
                }
				}
			}

            printchesspositions();
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetMouseButtonDown (0)) {
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;  
				if (Physics.Raycast (ray, out hit, 100.0f)) {

                GameObject[] tempsa = GameObject.FindGameObjectsWithTag("possibleposition");
                for (int i = 0; i < tempsa.Length; i++)
                    Destroy(tempsa[i]);

                GameObject[] selecteds = GameObject.FindGameObjectsWithTag("surroundbox");
                for(int i = 0;i<selecteds.Length; i++)
                {
                    Destroy(selecteds[i]);
                }

					if (hit.collider.tag == "possibleposition") {
                        //move the selected gameobject to that position
                        if (selectedobject.tag == "whitepawn") {
                            for (int i = 0; i < 8; i++) {
                                for (int j = 0; j < 8; j++) {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    //print(selectedobject.transform.position);
                                    if (selectedobject.transform.position.x >= upperranges[i, j].x && selectedobject.transform.position.x <= lowerranges[i, j].x && selectedobject.transform.position.z >= upperranges[i, j].z && selectedobject.transform.position.z <= lowerranges[i, j].z) {
                                        //print ("here");
                                        chesspositions[i, j] = 0;
                                        // printchesspositions ();
                                        break;
                                    }
                                }
                            }
                            //iTween.MoveTo (selectedobject, hit.collider.gameObject.transform.position, 2.0f);
                            iTween.MoveTo(selectedobject, iTween.Hash("x", hit.collider.gameObject.transform.position.x, "y", hit.collider.gameObject.transform.position.y, "z", hit.collider.gameObject.transform.position.z, "time", timeoftransition, "oncomplete", "movecam", "oncompletetarget", gameObject,"trnsition","linear"));
                            selectedobject.GetComponent<pawncontroller>().setfirstplay(false);
                            selectedobject.GetComponent<pawncontroller>().setcurrentposition(hit.collider.gameObject.transform.position);
                            for (int i = 0; i < 8; i++) {
                                for (int j = 0; j < 8; j++) {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    if (hit.collider.gameObject.transform.position.x >= upperranges[i, j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i, j].x && hit.collider.gameObject.transform.position.z >= upperranges[i, j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i, j].z) {
                                        //print ("here");
                                        chesspositions[i, j] = selectedobject.GetComponent<pawncontroller>().getstatus();
                                        selectedobject.GetComponent<pawncontroller>().setxpos(i);
                                        selectedobject.GetComponent<pawncontroller>().setypos(j);
                                        //printchesspositions ();
                                        break;
                                    }
                                }
                            }
                            GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
                            for (int i = 0; i < temps.Length; i++)
                                Destroy(temps[i]);
                            whiteplay = false;
                        } else if (selectedobject.tag == "blackpawn")
                            {
                                for (int i = 0; i < 8; i++)
                                {
                                    for (int j = 0; j < 8; j++)
                                    {
                                        //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                        //print(selectedobject.transform.position);
                                        if (selectedobject.transform.position.x >= upperranges[i, j].x && selectedobject.transform.position.x <= lowerranges[i, j].x && selectedobject.transform.position.z >= upperranges[i, j].z && selectedobject.transform.position.z <= lowerranges[i, j].z)
                                        {
                                            //print ("here");
                                            chesspositions[i, j] = 0;
                                            // printchesspositions ();
                                            break;
                                        }
                                    }
                                }
                                //iTween.MoveTo (selectedobject, hit.collider.gameObject.transform.position, 2.0f);
                                iTween.MoveTo(selectedobject, iTween.Hash("x", hit.collider.gameObject.transform.position.x, "y", hit.collider.gameObject.transform.position.y, "z", hit.collider.gameObject.transform.position.z, "trnsition", "linear" , "time", timeoftransition, "oncomplete", "movecam2", "oncompletetarget", gameObject));
                                selectedobject.GetComponent<pawncontroller>().setfirstplay(false);
                                selectedobject.GetComponent<pawncontroller>().setcurrentposition(hit.collider.gameObject.transform.position);
                                for (int i = 0; i < 8; i++)
                                {
                                    for (int j = 0; j < 8; j++)
                                    {
                                        //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                        if (hit.collider.gameObject.transform.position.x >= upperranges[i, j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i, j].x && hit.collider.gameObject.transform.position.z >= upperranges[i, j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i, j].z)
                                        {
                                            //print ("here");
                                            chesspositions[i, j] = selectedobject.GetComponent<pawncontroller>().getstatus();
                                            selectedobject.GetComponent<pawncontroller>().setxpos(i);
                                            selectedobject.GetComponent<pawncontroller>().setypos(j);
                                            //printchesspositions ();
                                            break;
                                        }
                                    }
                                }
                                GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
                                for (int i = 0; i < temps.Length; i++)
                                    Destroy(temps[i]);
                                whiteplay = true;
                        }

                            else if (selectedobject.tag == "whiterook") {

                            for (int i = 0; i < 8; i++) {
                                for (int j = 0; j < 8; j++) {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    //print(selectedobject.transform.position);
                                    if (selectedobject.transform.position.x >= upperranges[i, j].x && selectedobject.transform.position.x <= lowerranges[i, j].x && selectedobject.transform.position.z >= upperranges[i, j].z && selectedobject.transform.position.z <= lowerranges[i, j].z) {
                                        //print ("here");
                                        chesspositions[i, j] = 0;
                                        // printchesspositions ();
                                        break;
                                    }
                                }
                            }

                            //iTween.MoveTo(selectedobject, hit.collider.gameObject.transform.position, 2.0f);
                            iTween.MoveTo(selectedobject, iTween.Hash("x", hit.collider.gameObject.transform.position.x, "y", hit.collider.gameObject.transform.position.y, "z", hit.collider.gameObject.transform.position.z, "trnsition", "linear", "time", timeoftransition, "oncomplete", "movecam", "oncompletetarget", gameObject));
                            selectedobject.GetComponent<whiterookcontroller>().setcurrentposition(hit.collider.gameObject.transform.position);
                            GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
                            for (int i = 0; i < 8; i++) {
                                for (int j = 0; j < 8; j++) {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    if (hit.collider.gameObject.transform.position.x >= upperranges[i, j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i, j].x && hit.collider.gameObject.transform.position.z >= upperranges[i, j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i, j].z) {
                                        //print ("here");
                                        chesspositions[i, j] = selectedobject.GetComponent<whiterookcontroller>().getstatus();
                                        selectedobject.GetComponent<whiterookcontroller>().setxpos(i);
                                        selectedobject.GetComponent<whiterookcontroller>().setypos(j);
                                        //printchesspositions ();
                                        break;
                                    }
                                }
                            }
                            for (int i = 0; i < temps.Length; i++)
                                Destroy(temps[i]);
                            whiteplay = false;
                        }
                        else if (selectedobject.tag == "blackrook")
                        {

                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    //print(selectedobject.transform.position);
                                    if (selectedobject.transform.position.x >= upperranges[i, j].x && selectedobject.transform.position.x <= lowerranges[i, j].x && selectedobject.transform.position.z >= upperranges[i, j].z && selectedobject.transform.position.z <= lowerranges[i, j].z)
                                    {
                                        //print ("here");
                                        chesspositions[i, j] = 0;
                                        // printchesspositions ();
                                        break;
                                    }
                                }
                            }

                            //iTween.MoveTo(selectedobject, hit.collider.gameObject.transform.position, 2.0f);
                            iTween.MoveTo(selectedobject, iTween.Hash("x", hit.collider.gameObject.transform.position.x, "y", hit.collider.gameObject.transform.position.y, "z", hit.collider.gameObject.transform.position.z, "trnsition", "linear", "time", timeoftransition, "oncomplete", "movecam2", "oncompletetarget", gameObject));
                            selectedobject.GetComponent<whiterookcontroller>().setcurrentposition(hit.collider.gameObject.transform.position);
                            GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    if (hit.collider.gameObject.transform.position.x >= upperranges[i, j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i, j].x && hit.collider.gameObject.transform.position.z >= upperranges[i, j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i, j].z)
                                    {
                                        //print ("here");
                                        chesspositions[i, j] = selectedobject.GetComponent<whiterookcontroller>().getstatus();
                                        selectedobject.GetComponent<whiterookcontroller>().setxpos(i);
                                        selectedobject.GetComponent<whiterookcontroller>().setypos(j);
                                        //printchesspositions ();
                                        break;
                                    }
                                }
                            }
                            for (int i = 0; i < temps.Length; i++)
                                Destroy(temps[i]);
                            whiteplay = true;
                        }

                        else if (selectedobject.tag == "whitebishop") {
                            //move the white bishop


                            for (int i = 0; i < 8; i++) {
                                for (int j = 0; j < 8; j++) {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    //print(selectedobject.transform.position);
                                    if (selectedobject.transform.position.x >= upperranges[i, j].x && selectedobject.transform.position.x <= lowerranges[i, j].x && selectedobject.transform.position.z >= upperranges[i, j].z && selectedobject.transform.position.z <= lowerranges[i, j].z) {
                                        //print ("here");
                                        chesspositions[i, j] = 0;
                                        // printchesspositions ();
                                        break;
                                    }
                                }
                            }

                            //iTween.MoveTo(selectedobject, hit.collider.gameObject.transform.position, 2.0f);
                            iTween.MoveTo(selectedobject, iTween.Hash("x", hit.collider.gameObject.transform.position.x, "y", hit.collider.gameObject.transform.position.y, "z", hit.collider.gameObject.transform.position.z, "trnsition", "linear", "time", timeoftransition, "oncomplete", "movecam", "oncompletetarget", gameObject));
                            selectedobject.GetComponent<whitebishopcontroller>().setcurrentpos(hit.collider.gameObject.transform.position);
                            GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
                            for (int i = 0; i < 8; i++) {
                                for (int j = 0; j < 8; j++) {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    if (hit.collider.gameObject.transform.position.x >= upperranges[i, j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i, j].x && hit.collider.gameObject.transform.position.z >= upperranges[i, j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i, j].z) {
                                        //print ("here");
                                        chesspositions[i, j] = selectedobject.GetComponent<whitebishopcontroller>().getstatus();
                                        selectedobject.GetComponent<whitebishopcontroller>().setxpos(i);
                                        selectedobject.GetComponent<whitebishopcontroller>().setypos(j);
                                        //printchesspositions ();
                                        break;
                                    }
                                }
                            }
                            for (int i = 0; i < temps.Length; i++)
                                Destroy(temps[i]);
                            whiteplay = false;
                        }
                        else if (selectedobject.tag == "blackbishop")
                        {

                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    //print(selectedobject.transform.position);
                                    if (selectedobject.transform.position.x >= upperranges[i, j].x && selectedobject.transform.position.x <= lowerranges[i, j].x && selectedobject.transform.position.z >= upperranges[i, j].z && selectedobject.transform.position.z <= lowerranges[i, j].z)
                                    {
                                        //print ("here");
                                        chesspositions[i, j] = 0;
                                        // printchesspositions ();
                                        break;
                                    }
                                }
                            }

                            //iTween.MoveTo(selectedobject, hit.collider.gameObject.transform.position, 2.0f);
                            iTween.MoveTo(selectedobject, iTween.Hash("x", hit.collider.gameObject.transform.position.x, "y", hit.collider.gameObject.transform.position.y, "z", hit.collider.gameObject.transform.position.z, "trnsition", "linear", "time", timeoftransition, "oncomplete", "movecam2", "oncompletetarget", gameObject));
                            selectedobject.GetComponent<whitebishopcontroller>().setcurrentpos(hit.collider.gameObject.transform.position);
                            GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    if (hit.collider.gameObject.transform.position.x >= upperranges[i, j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i, j].x && hit.collider.gameObject.transform.position.z >= upperranges[i, j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i, j].z)
                                    {
                                        //print ("here");
                                        chesspositions[i, j] = selectedobject.GetComponent<whitebishopcontroller>().getstatus();
                                        selectedobject.GetComponent<whitebishopcontroller>().setxpos(i);
                                        selectedobject.GetComponent<whitebishopcontroller>().setypos(j);
                                        //printchesspositions ();
                                        break;
                                    }
                                }
                            }
                            for (int i = 0; i < temps.Length; i++)
                                Destroy(temps[i]);
                            whiteplay = true;
                        }

                        else if (selectedobject.tag == "whitequeen") {
                            // move the white queen
                            for (int i = 0; i < 8; i++) {
                                for (int j = 0; j < 8; j++) {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    //print(selectedobject.transform.position);
                                    if (selectedobject.transform.position.x >= upperranges[i, j].x && selectedobject.transform.position.x <= lowerranges[i, j].x && selectedobject.transform.position.z >= upperranges[i, j].z && selectedobject.transform.position.z <= lowerranges[i, j].z) {
                                        //print ("here");
                                        chesspositions[i, j] = 0;
                                        // printchesspositions ();
                                        break;
                                    }
                                }
                            }

                            // iTween.MoveTo(selectedobject, hit.collider.gameObject.transform.position, 2.0f);
                            iTween.MoveTo(selectedobject, iTween.Hash("x", hit.collider.gameObject.transform.position.x, "y", hit.collider.gameObject.transform.position.y, "z", hit.collider.gameObject.transform.position.z, "trnsition", "linear", "time", timeoftransition, "oncomplete", "movecam", "oncompletetarget", gameObject));
                            selectedobject.GetComponent<whitequeencontroller>().setcurrentposition(hit.collider.gameObject.transform.position);
                            GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
                            for (int i = 0; i < 8; i++) {
                                for (int j = 0; j < 8; j++) {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    if (hit.collider.gameObject.transform.position.x >= upperranges[i, j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i, j].x && hit.collider.gameObject.transform.position.z >= upperranges[i, j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i, j].z) {
                                        //print ("here");
                                        chesspositions[i, j] = selectedobject.GetComponent<whitequeencontroller>().getstatus();
                                        selectedobject.GetComponent<whitequeencontroller>().setxpos(i);
                                        selectedobject.GetComponent<whitequeencontroller>().setypos(j);
                                        //printchesspositions ();
                                        break;
                                    }
                                }
                            }
                            for (int i = 0; i < temps.Length; i++)
                                Destroy(temps[i]);
                            whiteplay = false;
                        }
                        else if (selectedobject.tag == "blackqueen")
                        {
                            // move the white queen
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    //print(selectedobject.transform.position);
                                    if (selectedobject.transform.position.x >= upperranges[i, j].x && selectedobject.transform.position.x <= lowerranges[i, j].x && selectedobject.transform.position.z >= upperranges[i, j].z && selectedobject.transform.position.z <= lowerranges[i, j].z)
                                    {
                                        //print ("here");
                                        chesspositions[i, j] = 0;
                                        // printchesspositions ();
                                        break;
                                    }
                                }
                            }

                            // iTween.MoveTo(selectedobject, hit.collider.gameObject.transform.position, 2.0f);
                            iTween.MoveTo(selectedobject, iTween.Hash("x", hit.collider.gameObject.transform.position.x, "y", hit.collider.gameObject.transform.position.y, "z", hit.collider.gameObject.transform.position.z, "trnsition", "linear", "time", timeoftransition, "oncomplete", "movecam2", "oncompletetarget", gameObject));
                            selectedobject.GetComponent<whitequeencontroller>().setcurrentposition(hit.collider.gameObject.transform.position);
                            GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    if (hit.collider.gameObject.transform.position.x >= upperranges[i, j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i, j].x && hit.collider.gameObject.transform.position.z >= upperranges[i, j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i, j].z)
                                    {
                                        //print ("here");
                                        chesspositions[i, j] = selectedobject.GetComponent<whitequeencontroller>().getstatus();
                                        selectedobject.GetComponent<whitequeencontroller>().setxpos(i);
                                        selectedobject.GetComponent<whitequeencontroller>().setypos(j);
                                        //printchesspositions ();
                                        break;
                                    }
                                }
                            }
                            for (int i = 0; i < temps.Length; i++)
                                Destroy(temps[i]);
                            whiteplay = true;
                        }
                        else if (selectedobject.tag == "whiteknight") {
                            for (int i = 0; i < 8; i++) {
                                for (int j = 0; j < 8; j++) {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    //print(selectedobject.transform.position);
                                    if (selectedobject.transform.position.x >= upperranges[i, j].x && selectedobject.transform.position.x <= lowerranges[i, j].x && selectedobject.transform.position.z >= upperranges[i, j].z && selectedobject.transform.position.z <= lowerranges[i, j].z) {
                                        //print ("here");
                                        chesspositions[i, j] = 0;
                                        // printchesspositions ();
                                        break;
                                    }
                                }
                            }

                            //iTween.MoveTo(selectedobject, hit.collider.gameObject.transform.position, 2.0f);
                            iTween.MoveTo(selectedobject, iTween.Hash("x", hit.collider.gameObject.transform.position.x, "y", hit.collider.gameObject.transform.position.y, "z", hit.collider.gameObject.transform.position.z, "trnsition", "linear", "time", timeoftransition, "oncomplete", "movecam", "oncompletetarget", gameObject));
                            selectedobject.GetComponent<whiteknightcontroller>().setcurrentposition(hit.collider.gameObject.transform.position);
                            GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
                            for (int i = 0; i < 8; i++) {
                                for (int j = 0; j < 8; j++) {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    if (hit.collider.gameObject.transform.position.x >= upperranges[i, j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i, j].x && hit.collider.gameObject.transform.position.z >= upperranges[i, j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i, j].z) {
                                        //print ("here");
                                        chesspositions[i, j] = selectedobject.GetComponent<whiteknightcontroller>().getstatus();
                                        selectedobject.GetComponent<whiteknightcontroller>().setxpos(i);
                                        selectedobject.GetComponent<whiteknightcontroller>().setypos(j);
                                        //printchesspositions ();
                                        break;
                                    }
                                }
                            }
                            for (int i = 0; i < temps.Length; i++)
                                Destroy(temps[i]);
                            whiteplay = false;
                        }
                        else if (selectedobject.tag == "blackknight")
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    //print(selectedobject.transform.position);
                                    if (selectedobject.transform.position.x >= upperranges[i, j].x && selectedobject.transform.position.x <= lowerranges[i, j].x && selectedobject.transform.position.z >= upperranges[i, j].z && selectedobject.transform.position.z <= lowerranges[i, j].z)
                                    {
                                        //print ("here");
                                        chesspositions[i, j] = 0;
                                        // printchesspositions ();
                                        break;
                                    }
                                }
                            }

                            //iTween.MoveTo(selectedobject, hit.collider.gameObject.transform.position, 2.0f);
                            iTween.MoveTo(selectedobject, iTween.Hash("x", hit.collider.gameObject.transform.position.x, "y", hit.collider.gameObject.transform.position.y, "z", hit.collider.gameObject.transform.position.z, "trnsition", "linear", "time", timeoftransition, "oncomplete", "movecam2", "oncompletetarget", gameObject));
                            selectedobject.GetComponent<whiteknightcontroller>().setcurrentposition(hit.collider.gameObject.transform.position);
                            GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    //print (boardvectors [i, j] + " " + hit.collider.gameObject.transform.position);
                                    if (hit.collider.gameObject.transform.position.x >= upperranges[i, j].x && hit.collider.gameObject.transform.position.x <= lowerranges[i, j].x && hit.collider.gameObject.transform.position.z >= upperranges[i, j].z && hit.collider.gameObject.transform.position.z <= lowerranges[i, j].z)
                                    {
                                        //print ("here");
                                        chesspositions[i, j] = selectedobject.GetComponent<whiteknightcontroller>().getstatus();
                                        selectedobject.GetComponent<whiteknightcontroller>().setxpos(i);
                                        selectedobject.GetComponent<whiteknightcontroller>().setypos(j);
                                        //printchesspositions ();
                                        break;
                                    }
                                }
                            }
                            for (int i = 0; i < temps.Length; i++)
                                Destroy(temps[i]);
                            whiteplay = true;
                        }

                    printchesspositions();

                    }
					if (hit.collider.tag == "whitepawn" && whiteplay == true) {
						//display prefab of cube on possible locations
						//Debug.Log("here");
						onwhitepawnclicked(hit);
                        
					}
                    if (hit.collider.tag == "blackpawn" && whiteplay == false)
                    {
                        //display prefab of cube on possible locations
                        //Debug.Log("here");
                        onblackpawnclicked(hit);
                    }
                    if (hit.collider.tag == "whiterook" && whiteplay == true) {
						   //Debug.Log ("here");
						onwhiterookclicked(hit);
					}
                    if (hit.collider.tag == "blackrook" && whiteplay == false)
                    {
                        onblackrookclicked(hit);
                    }
					if (hit.collider.tag == "whitebishop" && whiteplay == true) {
						onwhitebishopclicked (hit);
					}
                    if (hit.collider.tag == "blackbishop" && whiteplay == false)
                    {
                        onblackbishopclicked(hit);
                    }
					if (hit.collider.tag == "whitequeen" && whiteplay == true) {
						onwhitequeenclicked (hit);
					}
                    if (hit.collider.tag == "blackqueen" && whiteplay == false)
                    {
                        onblackqueenclicked(hit);
                    }
					if (hit.collider.tag == "whiteknight" && whiteplay == true) {
						onwhiteknightclicked (hit);
					}
                    if(hit.collider.tag == "blackknight" && whiteplay == false)
                    {
                        onblackknightclicked(hit);
                    }
                    GameObject selected;
                    selected = (GameObject)Instantiate(selectedsurround, hit.collider.gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f));
                selected.tag = "surroundbox";
                //print("selected object: " + selectedobject.name);
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



		public void onwhitepawnclicked(RaycastHit hit){
        selectedobject = hit.collider.gameObject;
        pawncontroller pc = hit.collider.gameObject.GetComponent<pawncontroller>();
			if (pc.getfirstplay () == true) {
				GameObject[] temps = GameObject.FindGameObjectsWithTag ("possibleposition");
				for (int i = 0; i < temps.Length; i++)
					Destroy (temps [i]);
            if (chesspositions[pc.getxpos() - 1, pc.getypos()] >= 1 && chesspositions[pc.getxpos() - 1, pc.getypos()] <= 10) {
            } else if (chesspositions[pc.getxpos() - 2, pc.getypos()] >= 1 && chesspositions[pc.getxpos() - 2, pc.getypos()] <= 10 ) {
                GameObject temp;
                Vector3 currentposition = pc.getcurrentposition();
                temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x, currentposition.y, currentposition.z + 6f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
            }
            else {
                GameObject temp;
                Vector3 currentposition = pc.getcurrentposition();
                temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x, currentposition.y, currentposition.z + 6f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x, currentposition.y, currentposition.z + 12f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
            }
            try
            {
                if (chesspositions[pc.getxpos() - 1, pc.getypos() - 1] == 6 || chesspositions[pc.getxpos() - 1, pc.getypos() - 1] == 7 || chesspositions[pc.getxpos() - 1, pc.getypos() - 1] == 8 || chesspositions[pc.getxpos() - 1, pc.getypos() - 1] == 9 || chesspositions[pc.getxpos() - 1, pc.getypos() - 1] == 10)
                {
                    GameObject temp;
                    Vector3 currentposition = pc.getcurrentposition();
                    temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x - 6f, currentposition.y, currentposition.z + 6f), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                }
            }catch(Exception e)
            {

            }
            try
            {
                if (chesspositions[pc.getxpos() +1 , pc.getypos() - 1] == 6 || chesspositions[pc.getxpos() + 1, pc.getypos() - 1] == 7 || chesspositions[pc.getxpos() + 1, pc.getypos() - 1] == 8 || chesspositions[pc.getxpos() + 1, pc.getypos() - 1] == 9 || chesspositions[pc.getxpos() + 1, pc.getypos() - 1] == 10)
                {
                    GameObject temp;
                    Vector3 currentposition = pc.getcurrentposition();
                    temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x + 6f, currentposition.y, currentposition.z + 6f), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                }
            }catch(Exception e)
            {

            }

        } else if (pc.getfirstplay () == false) {
				if ((pc.getcurrentposition ().z <= 23.02 && pc.getcurrentposition ().z >= 19.02) || chesspositions[pc.getxpos()-1 , pc.getypos()]==1 || chesspositions[pc.getxpos()-1,pc.getypos()]==2) {
				}else{
					GameObject[] temps = GameObject.FindGameObjectsWithTag ("possibleposition");
					for (int i = 0; i < temps.Length; i++)
						Destroy (temps [i]);
                if (chesspositions[pc.getxpos() - 2, pc.getypos()] >= 1 && chesspositions[pc.getxpos() - 2, pc.getypos()] <= 10)
                {
                    GameObject temp;
                    Vector3 currentposition = pc.getcurrentposition();
                    temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x, currentposition.y, currentposition.z + 6f), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                }
            }
            try
            {
                if (chesspositions[pc.getxpos() - 1, pc.getypos() - 1] == 6 || chesspositions[pc.getxpos() - 1, pc.getypos() - 1] == 7 || chesspositions[pc.getxpos() - 1, pc.getypos() - 1] == 8 || chesspositions[pc.getxpos() - 1, pc.getypos() - 1] == 9 || chesspositions[pc.getxpos() - 1, pc.getypos() - 1] == 10)
                {
                    GameObject temp;
                    Vector3 currentposition = pc.getcurrentposition();
                    temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x - 6f, currentposition.y, currentposition.z + 6f), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                }
            }
            catch (Exception e)
            {

            }
            try
            {
                if (chesspositions[pc.getxpos() + 1, pc.getypos() - 1] == 6 || chesspositions[pc.getxpos() + 1, pc.getypos() - 1] == 7 || chesspositions[pc.getxpos() + 1, pc.getypos() - 1] == 8 || chesspositions[pc.getxpos() + 1, pc.getypos() - 1] == 9 || chesspositions[pc.getxpos() + 1, pc.getypos() - 1] == 10)
                {
                    GameObject temp;
                    Vector3 currentposition = pc.getcurrentposition();
                    temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x + 6f, currentposition.y, currentposition.z + 6f), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                }
            }
            catch (Exception e)
            {

            }
        }
		}


    public void onblackpawnclicked(RaycastHit hit)
    {
        selectedobject = hit.collider.gameObject;
        pawncontroller pc = hit.collider.gameObject.GetComponent<pawncontroller>();
        if (pc.getfirstplay() == true)
        {
            GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
            for (int i = 0; i < temps.Length; i++)
                Destroy(temps[i]);
            if (chesspositions[pc.getxpos() + 1, pc.getypos()] == 1 || chesspositions[pc.getxpos() + 1, pc.getypos()] == 2 )
            {
            }
            else if (chesspositions[pc.getxpos() + 2, pc.getypos()] == 1 || chesspositions[pc.getxpos() + 2, pc.getypos()] == 2)
            {
                GameObject temp;
                Vector3 currentposition = pc.getcurrentposition();
                temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x, currentposition.y, currentposition.z - 6f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                
            }
            else
            {
                GameObject temp;
                Vector3 currentposition = pc.getcurrentposition();
                temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x, currentposition.y, currentposition.z - 6f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x, currentposition.y, currentposition.z - 12f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
            }
            try
            {
                if (chesspositions[pc.getxpos() + 1, pc.getypos() - 1] == 1)
                {
                    GameObject temp;
                    Vector3 currentposition = pc.getcurrentposition();
                    temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x - 6f, currentposition.y, currentposition.z - 6f), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                }
            }catch(Exception e)
            {

            }
            try
            {
                if (chesspositions[pc.getxpos() + 1, pc.getypos() + 1] == 1)
                {
                    GameObject temp;
                    Vector3 currentposition = pc.getcurrentposition();
                    temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x + 6f, currentposition.y, currentposition.z - 6f), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                }
            }catch(Exception e)
            {

            }
        }
        else if (pc.getfirstplay() == false)
        {
            if ((pc.getcurrentposition().z <= 23.02 && pc.getcurrentposition().z >= 19.02) || chesspositions[pc.getxpos() + 1, pc.getypos()] == 1 || chesspositions[pc.getxpos() + 1, pc.getypos()] == 2)
            {
            }
            else
            {
                GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
                for (int i = 0; i < temps.Length; i++)
                    Destroy(temps[i]);
                GameObject temp;
                Vector3 currentposition = pc.getcurrentposition();
                temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x, currentposition.y, currentposition.z - 6f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                
            }
            try
            {
                if (chesspositions[pc.getxpos() + 1, pc.getypos() - 1] == 1)
                {
                    GameObject temp;
                    Vector3 currentposition = pc.getcurrentposition();
                    temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x - 6f, currentposition.y, currentposition.z - 6f), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                }
            }catch(Exception e)
            {

            }
            try
            {
                if (chesspositions[pc.getxpos() + 1, pc.getypos() + 1] == 1)
                {
                    GameObject temp;
                    Vector3 currentposition = pc.getcurrentposition();
                    temp = (GameObject)Instantiate(possibleposition, new Vector3(currentposition.x + 6f, currentposition.y, currentposition.z - 6f), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                }
            }catch(Exception e)
            {

            }
        }
    }



    public void onwhiterookclicked(RaycastHit hit){
        selectedobject = hit.collider.gameObject;
        GameObject[] temps = GameObject.FindGameObjectsWithTag ("possibleposition");
			for (int i = 0; i < temps.Length; i++)
				Destroy (temps [i]);
			whiterookcontroller wrc = hit.collider.gameObject.GetComponent<whiterookcontroller>();
			Vector3 currentpos = wrc.getcurrentposition ();
			int count = 1;
			//top possiblepositions
			try{
				while(chesspositions[wrc.getxpos()-count , wrc.getypos()]<1 || chesspositions[wrc.getxpos() - count, wrc.getypos()] > 5)
            {
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x , currentpos.y , currentpos.z + (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wrc.getxpos() - count, wrc.getypos()] == 6 || chesspositions[wrc.getxpos() - count, wrc.getypos()] == 7 || chesspositions[wrc.getxpos() - count, wrc.getypos()] == 8 || chesspositions[wrc.getxpos() - count, wrc.getypos()] == 9 || chesspositions[wrc.getxpos() - count, wrc.getypos()] == 10)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
				}
			}catch(Exception e){
				//handle the exception
			}
			try{
				count = 1;
				while(chesspositions[wrc.getxpos()+count , wrc.getypos()] < 1 || chesspositions[wrc.getxpos() + count, wrc.getypos()] > 5)
            {
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x , currentpos.y , currentpos.z - (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wrc.getxpos() + count, wrc.getypos()] == 6 || chesspositions[wrc.getxpos() + count, wrc.getypos()] == 7 || chesspositions[wrc.getxpos() + count, wrc.getypos()] == 8 || chesspositions[wrc.getxpos() + count, wrc.getypos()] == 9 || chesspositions[wrc.getxpos() + count, wrc.getypos()] == 10)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
                
				}
			}catch(Exception e){
				//print (e.Message);
			}
			try{
				count = 1;
				while(chesspositions[wrc.getxpos() , wrc.getypos()-count]<1 || chesspositions[wrc.getxpos(), wrc.getypos() - count] > 5)
            {
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x - (6*count), currentpos.y , currentpos.z ), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wrc.getxpos(), wrc.getypos() - count] == 6 || chesspositions[wrc.getxpos(), wrc.getypos() - count] == 7 || chesspositions[wrc.getxpos(), wrc.getypos() - count] == 8 || chesspositions[wrc.getxpos(), wrc.getypos() - count] == 9 || chesspositions[wrc.getxpos(), wrc.getypos() - count] == 10)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
                    
				}
			}catch(Exception e){
				//print (e.Message);
			}
			try{
				count = 1;
				while(chesspositions[wrc.getxpos() , wrc.getypos()+count]<1 || chesspositions[wrc.getxpos(), wrc.getypos() + count] > 5)
            {
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x + (6*count), currentpos.y , currentpos.z ), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wrc.getxpos(), wrc.getypos() + count] == 6 || chesspositions[wrc.getxpos(), wrc.getypos() + count] == 7 || chesspositions[wrc.getxpos(), wrc.getypos() + count] == 8 || chesspositions[wrc.getxpos(), wrc.getypos() + count] == 9 || chesspositions[wrc.getxpos(), wrc.getypos() + count] == 10)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
                
				}
			}catch(Exception e){
				//print (e.Message);
			}
		
		}


    public void onblackrookclicked(RaycastHit hit)
    {
        selectedobject = hit.collider.gameObject;
        GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
        for (int i = 0; i < temps.Length; i++)
            Destroy(temps[i]);
        whiterookcontroller wrc = hit.collider.gameObject.GetComponent<whiterookcontroller>();
        Vector3 currentpos = wrc.getcurrentposition();
        int count = 1;
        //top possiblepositions
        try
        {
            while (chesspositions[wrc.getxpos() + count, wrc.getypos()] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wrc.getxpos() + count, wrc.getypos()] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
                
            }
        }
        catch (Exception e)
        {
            //handle the exception
        }
        try
        {
            count = 1;
            while (chesspositions[wrc.getxpos() - count, wrc.getypos()] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wrc.getxpos() - count, wrc.getypos()] ==1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
                
            }
        }
        catch (Exception e)
        {
            //print (e.Message);
        }
        try
        {
            count = 1;
            while (chesspositions[wrc.getxpos(), wrc.getypos() + count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wrc.getxpos(), wrc.getypos() + count] ==1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
                
            }
        }
        catch (Exception e)
        {
            //print (e.Message);
        }
        try
        {
            count = 1;
            while (chesspositions[wrc.getxpos(), wrc.getypos() - count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wrc.getxpos(), wrc.getypos() - count] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
                
            }
        }
        catch (Exception e)
        {
            //print (e.Message);
        }

    }

    public void onwhitebishopclicked(RaycastHit hit){
        selectedobject = hit.collider.gameObject;
        GameObject[] temps = GameObject.FindGameObjectsWithTag ("possibleposition");
			for (int i = 0; i < temps.Length; i++)
				Destroy (temps [i]);
			whitebishopcontroller wbc = hit.collider.gameObject.GetComponent<whitebishopcontroller> ();
			Vector3 currentpos = wbc.getcurrentpos ();
			int count = 1;
			//top possiblepositions
			try{
				while(chesspositions[wbc.getxpos()-count , wbc.getypos()+count]< 1|| chesspositions[wbc.getxpos() - count, wbc.getypos() + count] > 5)
            {
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x+(6*count) , currentpos.y , currentpos.z + (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wbc.getxpos() - count, wbc.getypos() + count] >= 6 && chesspositions[wbc.getxpos() - count, wbc.getypos() + count] <= 10)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
					count++;
				}
			}catch(Exception e){
				//handle the exception
			}
			try{
				count = 1;
				while(chesspositions[wbc.getxpos()-count , wbc.getypos()-count] < 1 || chesspositions[wbc.getxpos() - count, wbc.getypos() - count]>5)
            {
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x-(6*count) , currentpos.y , currentpos.z + (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wbc.getxpos() - count, wbc.getypos() - count] >= 6 && chesspositions[wbc.getxpos() - count, wbc.getypos() - count] <= 10)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
					count++;
				}
			}catch(Exception e){
				//handle the exception
			}
			try{
				count = 1;
				while(chesspositions[wbc.getxpos()+count , wbc.getypos()-count] < 1 || chesspositions[wbc.getxpos() + count, wbc.getypos() - count] > 5)
            {
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x-(6*count) , currentpos.y , currentpos.z - (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wbc.getxpos() + count, wbc.getypos() - count] >= 6 && chesspositions[wbc.getxpos() + count, wbc.getypos() - count] <= 10)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
					count++;
				}
			}catch(Exception e){
				//handle the exception
			}

			try{
				count = 1;
				while(chesspositions[wbc.getxpos()+count , wbc.getypos()+count] < 1 || chesspositions[wbc.getxpos() + count, wbc.getypos() + count] > 5)
            {
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x+(6*count) , currentpos.y , currentpos.z - (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wbc.getxpos() + count, wbc.getypos() + count] >=6 && chesspositions[wbc.getxpos() + count, wbc.getypos() + count] <= 10)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
					count++;
				}
			}catch(Exception e){
				//handle the exception
			}
        
		}


    public void onblackbishopclicked(RaycastHit hit)
    {
        selectedobject = hit.collider.gameObject;
        GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
        for (int i = 0; i < temps.Length; i++)
            Destroy(temps[i]);
        whitebishopcontroller wbc = hit.collider.gameObject.GetComponent<whitebishopcontroller>();
        Vector3 currentpos = wbc.getcurrentpos();
        int count = 1;
        //top possiblepositions
        try
        {
            while (chesspositions[wbc.getxpos() + count, wbc.getypos() - count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wbc.getxpos() + count, wbc.getypos() - count] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //handle the exception
        }
        try
        {
            count = 1;
            while (chesspositions[wbc.getxpos() + count, wbc.getypos() + count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wbc.getxpos() + count, wbc.getypos() + count] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //handle the exception
        }
        try
        {
            count = 1;
            while (chesspositions[wbc.getxpos() - count, wbc.getypos() + count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wbc.getxpos() - count, wbc.getypos() + count] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //handle the exception
        }

        try
        {
            count = 1;
            while (chesspositions[wbc.getxpos() - count, wbc.getypos() - count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wbc.getxpos() - count, wbc.getypos() - count] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //handle the exception
        }
        
    }

		public void onwhitequeenclicked(RaycastHit hit){
        selectedobject = hit.collider.gameObject;
        GameObject[] temps = GameObject.FindGameObjectsWithTag ("possibleposition");
			for (int i = 0; i < temps.Length; i++)
				Destroy (temps [i]);
			whitequeencontroller wqc = hit.collider.gameObject.GetComponent<whitequeencontroller> ();
			Vector3 currentpos = wqc.getcurrentpos ();
			int count = 1;
			//top possiblepositions
			try{
				while(chesspositions[wqc.getxpos()-count , wqc.getypos()+count]!=1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x+(6*count) , currentpos.y , currentpos.z + (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() - count, wqc.getypos() + count] == 2)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
					count++;
				}
			}catch(Exception e){
				//handle the exception
			}
			try{
				count = 1;
				while(chesspositions[wqc.getxpos()-count , wqc.getypos()-count]!=1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x-(6*count) , currentpos.y , currentpos.z + (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() - count, wqc.getypos() - count] == 2)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
					count++;
				}
			}catch(Exception e){
				//handle the exception
			}
			try{
				count = 1;
				while(chesspositions[wqc.getxpos()+count , wqc.getypos()-count]!=1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x-(6*count) , currentpos.y , currentpos.z - (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() + count, wqc.getypos() - count] == 2)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
					count++;
				}
			}catch(Exception e){
				//handle the exception
			}

			try{
				count = 1;
				while(chesspositions[wqc.getxpos()+count , wqc.getypos()+count]!=1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x+(6*count) , currentpos.y , currentpos.z - (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() + count, wqc.getypos() + count] == 2)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
					count++;
				}
			}catch(Exception e){
				//handle the exception
			}

			try{
				count = 1;
				while(chesspositions[wqc.getxpos()-count , wqc.getypos()]!=1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x , currentpos.y , currentpos.z + (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() - count, wqc.getypos()] == 2)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                    count++;
				}
			}catch(Exception e){
				//handle the exception
			}
			try{
				count = 1;
				while(chesspositions[wqc.getxpos()+count , wqc.getypos()]!=1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x , currentpos.y , currentpos.z - (6*count)), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() + count, wqc.getypos()] == 2)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
					count++;
				}
			}catch(Exception e){
				//print (e.Message);
			}
			try{
				count = 1;
				while(chesspositions[wqc.getxpos() , wqc.getypos()-count]!=1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x - (6*count), currentpos.y , currentpos.z ), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos(), wqc.getypos() - count] == 2)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
					count++;
				}
			}catch(Exception e){
				//print (e.Message);
			}
			try{
				count = 1;
				while(chesspositions[wqc.getxpos() , wqc.getypos()+count]!=1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x + (6*count), currentpos.y , currentpos.z ), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos(), wqc.getypos() + count] == 2)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
					count++;
				}
			}catch(Exception e){
				//print (e.Message);
			}
        
		}


    public void onblackqueenclicked(RaycastHit hit)
    {
        selectedobject = hit.collider.gameObject;
        GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
        for (int i = 0; i < temps.Length; i++)
            Destroy(temps[i]);
        whitequeencontroller wqc = hit.collider.gameObject.GetComponent<whitequeencontroller>();
        Vector3 currentpos = wqc.getcurrentpos();
        int count = 1;
        //top possiblepositions
        try
        {
            while (chesspositions[wqc.getxpos() + count, wqc.getypos() - count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() + count, wqc.getypos() - count] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //handle the exception
        }
        try
        {
            count = 1;
            while (chesspositions[wqc.getxpos() + count, wqc.getypos() + count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() + count, wqc.getypos() + count] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //handle the exception
        }
        try
        {
            count = 1;
            while (chesspositions[wqc.getxpos() - count, wqc.getypos() + count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() - count, wqc.getypos() + count] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //handle the exception
        }

        try
        {
            count = 1;
            while (chesspositions[wqc.getxpos() - count, wqc.getypos() - count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() - count, wqc.getypos() - count] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //handle the exception
        }

        try
        {
            count = 1;
            while (chesspositions[wqc.getxpos() + count, wqc.getypos()] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() + count, wqc.getypos()] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z - (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //handle the exception
        }
        try
        {
            count = 1;
            while (chesspositions[wqc.getxpos() - count, wqc.getypos()] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos() - count, wqc.getypos()] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x, currentpos.y, currentpos.z + (6 * count)), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //print (e.Message);
        }
        try
        {
            count = 1;
            while (chesspositions[wqc.getxpos(), wqc.getypos() + count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos(), wqc.getypos() + count] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x + (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //print (e.Message);
        }
        try
        {
            count = 1;
            while (chesspositions[wqc.getxpos(), wqc.getypos() - count] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
                if (chesspositions[wqc.getxpos(), wqc.getypos() - count] == 1)
                {
                    temp = Instantiate(possibleposition, new Vector3(currentpos.x - (6 * count), currentpos.y, currentpos.z), Quaternion.Euler(0f, 0f, 0f));
                    temp.tag = "possibleposition";
                    break;
                }
                count++;
            }
        }
        catch (Exception e)
        {
            //print (e.Message);
        }
        
    }

		public void onwhiteknightclicked(RaycastHit hit){
        selectedobject = hit.collider.gameObject;
        GameObject[] temps = GameObject.FindGameObjectsWithTag ("possibleposition");
			for (int i = 0; i < temps.Length; i++)
				Destroy (temps [i]);
			whiteknightcontroller wkc = hit.collider.gameObject.GetComponent<whiteknightcontroller> ();
			Vector3 currentpos = wkc.getcurrentposition ();
			try{
			if(chesspositions[wkc.getxpos()-2 , wkc.getypos()+1] != 1){
				GameObject temp;
				temp = Instantiate (possibleposition, new Vector3 (currentpos.x + 6f, currentpos.y , currentpos.z +12f), Quaternion.Euler (0f, 0f, 0f));
				temp.tag = "possibleposition";
				}
			}catch(Exception e){
			}
			try{
				if(chesspositions[wkc.getxpos()-2 , wkc.getypos()-1] != 1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x - 6f, currentpos.y , currentpos.z +12f), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
				}
			}catch(Exception e){
			
			}

			try{
				if(chesspositions[wkc.getxpos()-1 , wkc.getypos()-2] != 1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x - 12f, currentpos.y , currentpos.z +6f), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
				}
			}catch(Exception e){

			}
			try{
				if(chesspositions[wkc.getxpos()-1 , wkc.getypos()+2] != 1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x + 12f, currentpos.y , currentpos.z +6f), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
				}
			}catch(Exception e){

			}
			try{
				if(chesspositions[wkc.getxpos()+2 , wkc.getypos()+1] != 1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x + 6f, currentpos.y , currentpos.z - 12f), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
				}
			}catch(Exception e){

			}
			try{
				if(chesspositions[wkc.getxpos()+2 , wkc.getypos()-1] != 1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x - 6f, currentpos.y , currentpos.z - 12f), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
				}
			}catch(Exception e){

			}
			try{
				if(chesspositions[wkc.getxpos()+1 , wkc.getypos()+2] != 1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x + 12f, currentpos.y , currentpos.z - 6f), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
				}
			}catch(Exception e){

			}
			try{
				if(chesspositions[wkc.getxpos()+1 , wkc.getypos()-2] != 1){
					GameObject temp;
					temp = Instantiate (possibleposition, new Vector3 (currentpos.x - 12f, currentpos.y , currentpos.z - 6f), Quaternion.Euler (0f, 0f, 0f));
					temp.tag = "possibleposition";
				}
			}catch(Exception e){

			}
		}


    public void onblackknightclicked(RaycastHit hit)
    {
        selectedobject = hit.collider.gameObject;
        GameObject[] temps = GameObject.FindGameObjectsWithTag("possibleposition");
        for (int i = 0; i < temps.Length; i++)
            Destroy(temps[i]);
        whiteknightcontroller wkc = hit.collider.gameObject.GetComponent<whiteknightcontroller>();
        Vector3 currentpos = wkc.getcurrentposition();
        try
        {
            if (chesspositions[wkc.getxpos() + 2, wkc.getypos() - 1] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x - 6f, currentpos.y, currentpos.z - 12f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
            }
        }
        catch (Exception e)
        {
        }
        try
        {
            if (chesspositions[wkc.getxpos() + 2, wkc.getypos() + 1] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x + 6f, currentpos.y, currentpos.z - 12f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            if (chesspositions[wkc.getxpos() + 1, wkc.getypos() + 2] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x + 12f, currentpos.y, currentpos.z - 6f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if (chesspositions[wkc.getxpos() + 1, wkc.getypos() - 2] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x - 12f, currentpos.y, currentpos.z - 6f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if (chesspositions[wkc.getxpos() - 2, wkc.getypos() - 1] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x - 6f, currentpos.y, currentpos.z + 12f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if (chesspositions[wkc.getxpos() - 2, wkc.getypos() + 1] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x + 6f, currentpos.y, currentpos.z + 12f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if (chesspositions[wkc.getxpos() - 1, wkc.getypos() - 2] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x - 12f, currentpos.y, currentpos.z + 6f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if (chesspositions[wkc.getxpos() - 1, wkc.getypos() + 2] != 2)
            {
                GameObject temp;
                temp = Instantiate(possibleposition, new Vector3(currentpos.x + 12f, currentpos.y, currentpos.z + 6f), Quaternion.Euler(0f, 0f, 0f));
                temp.tag = "possibleposition";
            }
        }
        catch (Exception e)
        {

        }
    }


    public void movecam(){
        //print(selectedobject.name);
        selectedobject.GetComponent<collisionscript>().setcheckcollision(true);
        cameraholder.GetComponent<cameracontroller> ().movecamera ();
            
		}
        
       public void movecam2()
        {
        //print(selectedobject.name);
        selectedobject.GetComponent<collisionscript>().setcheckcollision(true);
        cameraholder.GetComponent<cameracontroller>().movecamera2();

          }


		public int[,] getchesspositions(){
			return this.chesspositions;
		}

		public Vector3[,] getupperranges(){
				return this.upperranges;
		}

		public Vector3[,] getlowerranges(){
			return this.lowerranges;
		}


        public GameObject getselectedgameobject()
    {
        return selectedobject;
    }
       

	}
