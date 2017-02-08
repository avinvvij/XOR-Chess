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

                if (chesspositions[x - count, y] == 7 || chesspositions[x - count, y] == 8)
                {
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
                    result = true;
                }
            }
            catch (Exception e)
            {

            }
            try {
                count = 1;
                while ((chesspositions[x, y - count] == 0) && result == false)
                {
                    //it's a check to white king
                    //print("Im here: " + chesspositions[xpos - count, ypos]);
                    count++;
                }

                if (chesspositions[x, y - count] == 7 || chesspositions[x, y - count] == 8)
                {
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
                    result = true;
                }
            }
            catch (Exception e)
            {

            }
            try
            {
                count = 1;
                while ((chesspositions[x, y + count] == 0) && result == false)
                {
                    //it's a check to white king
                    //print("Im here: " + chesspositions[xpos - count, ypos]);
                    count++;
                }

                if (chesspositions[x, y + count] == 7 || chesspositions[x, y + count] == 8)
                {
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
                    result = true;
                }
            }
            catch (Exception e)
            {

            }
            try
            {
                count = 1;
                while ((chesspositions[x + count, y + count] == 0) && result == false)
                {
                    //it's a check to white king
                    //print("Im here: " + chesspositions[xpos - count, ypos]);
                    count++;
                }

                if (chesspositions[x + count, y + count] == 9 || chesspositions[x + count, y + count] == 8)
                {
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
                    result = true;
                }
            } catch (Exception e)
            {

            }

            try
            {
                if ((chesspositions[x - 1, y + 1] == 6) && result == false)
                {
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                    notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
                    result = true;
                }
            }
            catch (Exception e)
            {

            }
            if (result == true)
                checkCheckMate();

        return result;
        
        
    }


    public bool checkwhitecheckforcheckmate(int x, int y, int[,] cp, int from = 0)
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

            if (chesspositions[x - count, y] == 7 || chesspositions[x - count, y] == 8)
            {
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            count = 1;
            while ((chesspositions[x, y - count] == 0) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x, y - count] == 7 || chesspositions[x, y - count] == 8)
            {
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            count = 1;
            while ((chesspositions[x, y + count] == 0) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x, y + count] == 7 || chesspositions[x, y + count] == 8)
            {
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
                result = true;
            }
        }
        catch (Exception e)
        {

        }
        try
        {
            count = 1;
            while ((chesspositions[x + count, y + count] == 0) && result == false)
            {
                //it's a check to white king
                //print("Im here: " + chesspositions[xpos - count, ypos]);
                count++;
            }

            if (chesspositions[x + count, y + count] == 9 || chesspositions[x + count, y + count] == 8)
            {
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                notifications.text = (from == 0) ? notifications.text = "Check to white" : notifications.text;
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
                
                result = true;
            }
        }
        catch (Exception e)
        {

        }

        return result;
    }

    public bool predictwhitediffcheck(int x , int y , int prevx , int prevy , int status , bool fromcheckmate = false)
    {
        
        bool result = false;
        int[,] cp = (int[,])chesscontroller.GetComponent<chesscontroller>().getchesspositions().Clone();
        cp[x, y] = status;
        cp[prevx, prevy] = 0;
        if(fromcheckmate == false)
            result = checkwhitecheck(xpos, ypos , cp , 1);
        else
            result = checkwhitecheckforcheckmate(xpos, ypos, cp, 1);
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

    public bool checkCheckMate()
    {
        int resultcount = 0;
        int[,] cmchesspositions = (int[,])chesscontroller.GetComponent<chesscontroller>().getchesspositions().Clone();
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                switch (cmchesspositions[i,j])
                {
                    case 1:
                        if (resultcount == 0)
                        {
                            if (i == 6)
                            {
                                //pawn gonna play first time
                                if (cmchesspositions[i - 1, j] >= 1 && cmchesspositions[i - 1, j] <= 10 && cmchesspositions[i - 1, j] != 20 && cmchesspositions[i - 1, j] != 21)
                                {
                                    
                                }
                                if (cmchesspositions[i - 1, j] == 0)
                                {
                                    if (predictwhitediffcheck(i - 1, j, i, j, cmchesspositions[i, j] , true) == false)
                                    {
                                        resultcount++;
                                    }
                                    if (cmchesspositions[i - 2, j] == 0)
                                    {
                                        if (predictwhitediffcheck(i - 2, j, i, j, cmchesspositions[i, j],true) == false)
                                        {
                                            resultcount++;
                                        }
                                    }
                                }

                                try
                                {
                                    if (cmchesspositions[i - 1, j - 1] >= 6 && cmchesspositions[i - 1, j - 1] <= 10  )
                                    {
                                        if(predictwhitediffcheck(i - 1, j - 1, i, j, cmchesspositions[i, j] , true) == false)
                                        {
                                            resultcount++;
                                        }
                                    }
                                }
                                catch (Exception e)
                                {

                                }
                                try
                                {
                                    if (cmchesspositions[i - 1, j + 1] >= 6 && cmchesspositions[i - 1, j + 1] <= 10 )
                                    {
                                        if (predictwhitediffcheck(i - 1, j + 1, i, j, cmchesspositions[i, j] , true) == false)
                                        {
                                            resultcount++;
                                        }
                                    }
                                }
                                catch (Exception e)
                                {

                                }
                            }
                            else
                            {
                                //pawn has alerady been moved once
                                
                                try
                                {
                                    if (cmchesspositions[i - 1, j] == 0 )
                                    {
                                        if (predictwhitediffcheck(i - 1, j, i, j, cmchesspositions[i, j] , true) == false)
                                        {
                                            resultcount++;
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                }

                                try
                                {
                                    if (cmchesspositions[i - 1, j - 1] >= 6 && chesspositions[i - 1, j - 1] <= 10 )
                                    {
                                        if(predictwhitediffcheck(i - 1, j - 1, i, j, cmchesspositions[i, j],true) == false)
                                        {
                                            resultcount++;
                                        }
                                    }
                                }
                                catch (Exception e)
                                {

                                }
                                try
                                {
                                    if (cmchesspositions[i - 1, j + 1] >= 6 && chesspositions[i - 1, j + 1] <= 10)
                                    {
                                        if (predictwhitediffcheck(i - 1, j + 1, i, j, cmchesspositions[i, j] , true) == false)
                                        {
                                            resultcount++;
                                        }
                                    }
                                }
                                catch (Exception e)
                                {

                                }
                            }
                        }
                        break;
                    case 2:
                        //testing with rook
                        if (resultcount == 0)
                        {
                            int count = 1;
                            //top possiblepositions
                            try
                            {
                                while ((chesspositions[i - count, j] < 1 || chesspositions[i - count, j] > 5) && chesspositions[i - count, j] != 20)
                                {
                                    if (predictwhitediffcheck(i - count, j, i, j, cmchesspositions[i,j],true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i - count, j] == 6 || chesspositions[i - count, j] == 7 || chesspositions[i - count, j] == 8 || chesspositions[i - count, j] == 9 || chesspositions[i - count, j] == 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i + count, j] < 1 || chesspositions[i + count, j] > 5) && chesspositions[i + count, j] != 20)
                                {
                                    if (predictwhitediffcheck(i + count, j, i, j, cmchesspositions[i,j] , true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i + count, j] == 6 || chesspositions[i + count, j] == 7 || chesspositions[i + count, j] == 8 || chesspositions[i + count, j] == 9 || chesspositions[i + count, j] == 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i, j - count] < 1 || chesspositions[i, j - count] > 5) && chesspositions[i, j - count] != 20)
                                {
                                    if (predictwhitediffcheck(i, j - count, i, j, cmchesspositions[i,j] , true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i, j - count] == 6 || chesspositions[i, j - count] == 7 || chesspositions[i, j - count] == 8 || chesspositions[i, j - count] == 9 || chesspositions[i, j - count] == 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i, j + count] < 1 || chesspositions[i, j + count] > 5) && chesspositions[i, j + count] != 20)
                                {
                                    if (predictwhitediffcheck(i, j + count, i, j, cmchesspositions[i,j]) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i, j + count] == 6 || chesspositions[i, j + count] == 7 || chesspositions[i, j + count] == 8 || chesspositions[i, j + count] == 9 || chesspositions[i, j + count] == 10)
                                        {
                                            
                                            break;
                                        }
                                    }
                                    count++;

                                }
                            }
                            catch (Exception e)
                            {
                                //print (e.Message);
                            }
                        }
                        break;
                    case 3:
                        if (resultcount == 0)
                        {
                            int count = 1;
                            //top possiblepositions
                            try
                            {
                                while ((chesspositions[i - count, j + count] < 1 || chesspositions[i - count, j + count] > 5) && chesspositions[i - count, j + count] != 20)
                                {
                                    if (predictwhitediffcheck(i - count, j + count, i, j, cmchesspositions[i, j], true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i - count, j + count] >= 6 && chesspositions[i - count, j + count] <= 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i - count, j - count] < 1 || chesspositions[i - count, j - count] > 5) && chesspositions[i - count, j - count] != 20)
                                {
                                    if (predictwhitediffcheck(i - count, j - count, i, j, cmchesspositions[i, j], true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i - count, j - count] >= 6 && chesspositions[i - count, j - count] <= 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i + count, j - count] < 1 || chesspositions[i + count, j - count] > 5) && chesspositions[i + count, j - count] != 20)
                                {
                                    if (predictwhitediffcheck(i + count, j - count, i, j, cmchesspositions[i, j], true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i + count, j - count] >= 6 && chesspositions[i + count, j - count] <= 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i + count, j + count] < 1 || chesspositions[i + count, j + count] > 5) && chesspositions[i + count, j + count] != 20)
                                {
                                    if (predictwhitediffcheck(i + count, j + count, i, j, cmchesspositions[i, j], true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i + count, j + count] >= 6 && chesspositions[i + count, j + count] <= 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i - count, j] < 1 || chesspositions[i - count, j] > 5) && chesspositions[i - count, j] != 20)
                                {
                                    if (predictwhitediffcheck(i - count, j, i, j, cmchesspositions[i, j], true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i - count, j] >= 6 && chesspositions[i - count, j] <= 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i + count, j] < 1 || chesspositions[i + count, j] > 5) && chesspositions[i + count, j] != 20)
                                {
                                    if (predictwhitediffcheck(i + count, j, i, j, cmchesspositions[i, j], true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i + count, j] >= 6 && chesspositions[i + count, j] <= 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i, j - count] < 1 || chesspositions[i, j - count] > 5) && chesspositions[i, j - count] != 20)
                                {
                                    if (predictwhitediffcheck(i, j - count, i, j, cmchesspositions[i, j], true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i, j - count] >= 6 && chesspositions[i, j - count] <= 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i, j + count] < 1 || chesspositions[i, j + count] > 5) && chesspositions[i, j + count] != 20)
                                {
                                    if (predictwhitediffcheck(i, j + count, i, j, cmchesspositions[i, j], true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i, j + count] >= 6 && chesspositions[i, j + count] <= 10)
                                        {
                                            break;
                                        }
                                    }
                                    count++;
                                }
                            }
                            catch (Exception e)
                            {
                                //print (e.Message);
                            }

                        }
                        break;
                    case 4:
                        if(resultcount == 0)
                        {
                             int count = 1;
                            //top possiblepositions
                            try
                            {
                                while ((chesspositions[i - count, j + count] < 1 || chesspositions[i - count, j + count] > 5) && chesspositions[i - count, j + count] != 20)
                                {
                                    if (predictwhitediffcheck(i - count, j + count, i, j, cmchesspositions[i,j] , true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i - count, j + count] >= 6 && chesspositions[i - count, j + count] <= 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i - count, j - count] < 1 || chesspositions[i - count, j - count] > 5) && chesspositions[i - count, j - count] != 20)
                                {
                                    if (predictwhitediffcheck(i - count, j - count, i, j, cmchesspositions[i,j] , true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i - count, j - count] >= 6 && chesspositions[i - count, j - count] <= 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i + count, j - count] < 1 || chesspositions[i + count, j - count] > 5) && chesspositions[i + count, j - count] != 20)
                                {
                                    if (predictwhitediffcheck(i + count, j - count, i, j, cmchesspositions[i,j] , true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i + count, j - count] >= 6 && chesspositions[i + count, j - count] <= 10)
                                        {
                                            break;
                                        }
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
                                while ((chesspositions[i + count, j + count] < 1 || chesspositions[i + count, j + count] > 5) && chesspositions[i + count, j + count] != 20)
                                {
                                    if (predictwhitediffcheck(i + count, j + count, i, j, cmchesspositions[i,j] , true) == false)
                                    {
                                        resultcount++;
                                        if (chesspositions[i + count, j + count] >= 6 && chesspositions[i + count, j + count] <= 10)
                                        {
                                            break;
                                        }
                                    }
                                    count++;
                                }
                            }
                            catch (Exception e)
                            {
                                //handle the exception
                            }
                        }
                        break;
                    case 5:
                        break;
                }
            }
        }
        if(resultcount >= 1)
        {
            notifications.text = "saved Bud";
            return false;
        }else
        {
            notifications.text = "You are check mate";
            return true;
        }
    }

}
