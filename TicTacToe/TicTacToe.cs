using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    public Matrix<int> grid; //creating a matrix of 3 by 3
    public int currentPlayer; //player or the AI
    public Object circle; //this is for visual representation of objects
    public Object cross;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Matrix<int>(3,3); //creating initial 3 by 3 matrix in memeory 
        print(grid.ToString()); //printing the matrix the above specified value 
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 mousePos = Input.mousePosition *3; //getting the mouse location and multiplying my 3 for convinience 

        mousePos.x /= Screen.width;  //making it unit length
        mousePos.y /= Screen.height;  //unit height 
        if (Input.GetMouseButtonDown(0))  //0 means left mouse click, 1- right mouse click , 2- scroll wheel click
        {
     //  print(mousePos);
        }*/

        Peter(); //calling Peter's function 
     
    }

    //the interface getting the coordinates of the mouse 
    void Peter()
    {
        Vector3 mousePos = Input.mousePosition * 3;
        mousePos.x /= Screen.width;
        mousePos.y /= Screen.height;
        mousePos.y = 3 - mousePos.y;
        if (Input.GetMouseButtonDown(0))
        {            
            //print(mousePos);
            int x = (int)mousePos.x; //rounding down to the nearest integer after converting it into unit length
            int y = (int)mousePos.y;
            if (x<0) //eliminating any negative values 
            {
                x = 0;
            }
            if (x>2) // preventing x not to be beyound the matrix coordinate we intended
            {
                x = 2;
            }
            if (y < 0)
            {
                y = 0;
            }

            if(y>2)
            {
                y = 2;
            }
            //Vector3 v = new Vector3(x +0.5f,-y-0.5f,0);            
            Choice(y,x,currentPlayer); //choice takes in x and y coordinates and which player just played to see if they won or not 
            print(grid.ToString());
            //currentPlayer = -1 * currentPlayer; //taking turns in player
            print(mousePos); //for testing 

            int value = Decision(); //calling the function to check if any player has won or not 
            if (value !=0)
            {
                print("Hooray Player " + value + " has won this round"); //printing the end result if anyone won 
                grid = new Matrix<int>(3, 3);
            }
           

        }
    }

    int Decision( )
    {
        //the various ways one can win the game, setting initial value to 0
        int sumCol = 0;
        int sumRow = 0;
        int sumDigLeft = 0;
        int sumDigRight = 0;

        //creating nested loop for summing up the points 
        for (int i = 0; i<3; i++)
        {
            sumCol = 0;
            sumRow = 0;
            sumDigLeft = 0;
            sumDigRight = 0; 
            for (int j = 0; j<3; j++)
            {                
                 sumRow += grid[i, j];
                 sumCol += grid[j, i];               
                 sumDigLeft += grid[j, j];
                 sumDigRight += grid[j,2-j];      //summiung up the anti diagonal value             
            }

            if ((sumRow == 3) || (sumCol == 3) || (sumDigLeft == 3) || (sumDigRight == 3))
            {
                return 1;
            }

            if ((sumRow == -3) || (sumCol == -3) || (sumDigLeft == -3) || (sumDigRight == -3))
            {
                return -1;
            }
        }

        return 0; //by defult it returns 0 unless one of the if statement is true by above 
    }

    void Choice(int x, int y, int player)  //creating the interface 
    {       
        //Vector3 coor = new Vector3(x, y, 0);
        Vector3 v = new Vector3(y - 0.5f,-x + 0.5f, 0); //drawing in the middle of a grid 
        if (grid[x,y]==0)
        {
            grid[x, y] = player; //the player is at that coordinates 
         if (player == 1)
         {
            Instantiate(cross,v,Quaternion.identity);
         //Choice(x, y, currentPlayer); //choice takes in x and y coordinates and which player just played to see if they won or not
            currentPlayer = -1 * currentPlayer; //taking turns in player
            }
         if (player == -1)
         {
            Instantiate(circle, v, Quaternion.identity);
         //Choice(x, y, currentPlayer); //choice takes in x and y coordinates and which player just played to see if they won or not
            currentPlayer = -1 * currentPlayer; //taking turns in player
         
            }
        }
       
    }
}
