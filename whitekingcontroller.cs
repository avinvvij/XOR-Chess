using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class whitekingcontroller : MonoBehaviour {

    public Vector3 currentposition;
    public int xpos;
    public int ypos;
    public int status;
    GameObject chesscontroller;
    int[,] chesspositions;

    // Use this for initialization
    void Start () {
        chesscontroller = GameObject.FindGameObjectWithTag("controller");
       
	}

    public Vector3 getcurrentposition()
    {
        return currentposition;
    }

    public void setcurrentposition(Vector3 cp)
    {
        this.currentposition = cp;
    }

    public int getxpos()
    {
        return xpos;
    }

    public int getypos()
    {
        return ypos;
    }

    public void setxpos(int x)
    {
        xpos = x;
    }

    public void setypos(int y)
    {
        ypos = y;
    }

    public int getstatus()
    {
        return this.status;
    }

    public bool checkwhitecheck(int x , int y)
    {
        this.chesspositions = chesscontroller.GetComponent<chesscontroller>().getchesspositions();
        //printchesspositions();
        //print("here");
        bool result = false;
        int count = 1;
        try
        {
            while ((chesspositions[x - count, y] != 7 && chesspositions[x - count, y] != 8) && result == false)
            {
                //it's a check to white king
                //print("Im here: "+ chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x-count , y] == 7 || chesspositions[x-count , y] == 8)
            {
                print("check");
                result = true;
            }

        }
        catch (Exception e)
        {
            //print(e.StackTrace);
        }
        try
        {
            count = 1;
            while ((chesspositions[x + count, y] != 7 && chesspositions[x + count, y] != 8) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x + count, y] == 7 || chesspositions[x + count, y] == 8)
            {
                print("check");
                result = true;
            }
        }
        catch(Exception e)
        {

        }
        try {
            count = 1;
            while ((chesspositions[x, y-count] != 7 && chesspositions[x, y-count] != 8) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x, y-count] == 7 || chesspositions[x, y-count] == 8)
            {
                print("check");
                result = true;
            }
        }
        catch(Exception e)
        {

        }
        try
        {
            count = 1;
            while ((chesspositions[x, y+count] != 7 && chesspositions[x, y+count] != 8) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x, y+count] == 7 || chesspositions[x, y+count] == 8)
            {
                print("check");
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            count = 1;
            while ((chesspositions[x+count, y + count] != 9 && chesspositions[x+count, y + count] != 8) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x+count, y + count] == 9 || chesspositions[x+count, y + count] == 8)
            {
                print("check");
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            count = 1;
            while ((chesspositions[x - count, y + count] != 9 && chesspositions[x - count, y + count] != 8) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x - count, y + count] == 9 || chesspositions[x - count, y + count] == 8)
            {
                print("check");
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            count = 1;
            while ((chesspositions[x + count, y - count] != 9 && chesspositions[x + count, y - count] != 8) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x + count, y - count] == 9 || chesspositions[x + count, y - count] == 8)
            {
                print("check");
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            count = 1;
            while ((chesspositions[x - count, y - count] != 9 && chesspositions[x - count, y - count] != 8) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x - count, y - count] == 9 || chesspositions[x - count, y - count] == 8)
            {
                print("check");
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            if((chesspositions[x-1 , y-1] == 6 || chesspositions[x-1 , y+1] == 6) && result == false)
            {
                print("check");
                result = true;
            }
        }catch(Exception e)
        {

        }

        try
        {
            if ((chesspositions[x - 2, y - 1] == 10 || chesspositions[x - 2, y + 1] == 10 || chesspositions[x + 2, y + 1] == 10 || chesspositions[x + 2, y - 1] == 10 || chesspositions[x - 1, y + 2] == 10 || chesspositions[x + 1, y + 2] == 10 || chesspositions[x - 1, y - 2]  == 10 || chesspositions[x + 1, y - 2] == 10) && result == false)
            {
                print("check");
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        return result;
    }


    public void printchesspositions()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Debug.Log(i + " " + j + " " + chesspositions[i, j]);
            }
        }
    }

}
