using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionscript : MonoBehaviour {

    bool checkcollision = false;
    

    public void setcheckcollision(bool ck)
    {
        this.checkcollision = ck;
        //print(gameObject.name + ": " + this.checkcollision);
        Invoke("setcoltofalse", 1.8f);
    }

   public void setcoltofalse()
    {
        this.checkcollision = false;
        //print(gameObject.name + ": " + this.checkcollision);
    }

    public void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        //print(GameObject.FindGameObjectWithTag("controller").GetComponent<chesscontroller>().getselectedgameobject().name);
        if (checkcollision && other.gameObject.tag != "possibleposition")
        {
            //print(gameObject.name+" destroyed " +other.gameObject.name);
            Destroy(other.gameObject);
            this.checkcollision = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        //Destroy(other.gameObject);
        //print(GameObject.FindGameObjectWithTag("controller").GetComponent<chesscontroller>().getselectedgameobject().name);
        if (checkcollision && other.gameObject.tag != "possibleposition")
        {
            //print(gameObject.name + " destroyed " + other.gameObject.name);
            Destroy(other.gameObject);
            this.checkcollision = false;
        }
    }
}
