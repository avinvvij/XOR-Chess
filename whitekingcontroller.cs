using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class whitekingcontroller : MonoBehaviour {

    public Vector3 currentposition;
    public int xpos;
    public int ypos;
    public int status;
    GameObject chesscontroller;
    int[,] chesspositions;
    public Text notifications;

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

    public bool checkwhitecheck(int x, int y, int[,] cp , int from = 0)
    {
        if (from == 0)
            this.chesspositions = (int[,])chesscontroller.GetComponent<chesscontroller>().getchesspositions().Clone();
        else
            this.chesspositions = (int[,])cp.Clone();
        //printchesspositions();
        //print("here");
        bool result = false;
        int count = 1;
        try
        {
            while ((chesspositions[x - count, y] == 0) && result == false)
            {
                //it's a check to white king
                //print("Im here: "+ chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x-count , y] == 7 || chesspositions[x-count , y] == 8)
            {
                notifications.text = "Check To White";
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
            while ((chesspositions[x + count, y] == 0) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x + count, y] == 7 || chesspositions[x + count, y] == 8)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch(Exception e)
        {

        }
        try {
            count = 1;
            while ((chesspositions[x, y-count]== 0) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x, y-count] == 7 || chesspositions[x, y-count] == 8)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch(Exception e)
        {

        }
        try
        {
            count = 1;
            while ((chesspositions[x, y+count] == 0) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x, y+count] == 7 || chesspositions[x, y+count] == 8)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            count = 1;
            while ((chesspositions[x+count, y + count] == 0 )&& result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x+count, y + count] == 9 || chesspositions[x+count, y + count] == 8)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            count = 1;
            while ((chesspositions[x - count, y + count] == 0) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x - count, y + count] == 9 || chesspositions[x - count, y + count] == 8)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            count = 1;
            while ((chesspositions[x + count, y - count] == 0) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x + count, y - count] == 9 || chesspositions[x + count, y - count] == 8)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            count = 1;
            while ((chesspositions[x - count, y - count] == 0) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x - count, y - count] == 9 || chesspositions[x - count, y - count] == 8)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            if((chesspositions[x-1 , y-1] == 6) && result == false)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }catch(Exception e)
        {

        }

        try
        {
            if ((chesspositions[x - 1, y + 1] == 6) && result == false)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            if ((chesspositions[x - 2, y - 1] == 10 ) && result == false)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x - 2, y + 1] == 10 ) && result == false)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x + 2, y + 1] == 10 ) && result == false)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x + 2, y - 1] == 10 ) && result == false)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x - 1, y + 2] == 10 ) && result == false)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x + 1, y + 2] == 10 ) && result == false)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x - 1, y - 2] == 10 ) && result == false)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x + 1, y - 2] == 10 ) && result == false)
            {
                notifications.text = "Check To White";
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        return result;
    }


    public bool predictwhitecheck(int x, int y ,int prevx , int prevy , int status)
    {

        int[,] cp = (int[,]) chesscontroller.GetComponent<chesscontroller>().getchesspositions().Clone();
        cp[x, y] = status;
        cp[prevx, prevy] = 0;
        //printchesspositions();
        //print("here");
        bool result = false;
        int count = 1;
        try
        {
            while ((cp[x - count, y] == 0))
            {
                //it's a check to white king
                //print("Im here: "+ chesspositions[xpos - count, ypos]);
                count++;
            }

            if (cp[x - count, y] == 7 || cp[x - count, y] == 8)
            {
                notifications.text = "Check predicted";
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
            while ((cp[x + count, y] == 0))
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (cp[x + count, y] == 7 || cp[x + count, y] == 8)
            {
                notifications.text = "Check predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            count = 1;
            while ((cp[x, y - count] == 0))
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (cp[x, y - count] == 7 || cp[x, y - count] == 8)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            count = 1;
            while ((cp[x, y + count] == 0))
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (cp[x, y + count] == 7 || cp[x, y + count] == 8)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            count = 1;
            while ((cp[x + count, y + count]==0))
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (cp[x + count, y + count] == 9 || cp[x + count, y + count] == 8)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            count = 1;
            while ((cp[x - count, y + count]==0))
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (cp[x - count, y + count] == 9 || cp[x - count, y + count] == 8)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            count = 1;
            while ((cp[x + count, y - count]==0))
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (cp[x + count, y - count] == 9 || cp[x + count, y - count] == 8)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            count = 1;
            while ((cp[x - count, y - count] == 0))
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (cp[x - count, y - count] == 9 || cp[x - count, y - count] == 8)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            if ((chesspositions[x - 1, y - 1] == 6) && result == false)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            if ((chesspositions[x - 1, y + 1] == 6) && result == false)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        try
        {
            if ((chesspositions[x - 2, y - 1] == 10) && result == false)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x - 2, y + 1] == 10) && result == false)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x + 2, y + 1] == 10) && result == false)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x + 2, y - 1] == 10) && result == false)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x - 1, y + 2] == 10) && result == false)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x + 1, y + 2] == 10) && result == false)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x - 1, y - 2] == 10) && result == false)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            if ((chesspositions[x + 1, y - 2] == 10) && result == false)
            {
                notifications.text = "Check Predicted";
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        return result;
    }

    public bool predictwhitediffcheck(int x , int y , int prevx , int prevy , int status)
    {
        bool result = false;
        int[,] cp = (int[,])chesscontroller.GetComponent<chesscontroller>().getchesspositions().Clone();
        cp[x, y] = status;
        cp[prevx, prevy] = 0;
        result = checkwhitecheck(xpos, ypos , cp , 1);
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
