using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tic_Tac_Toe : MonoBehaviour {

    private int turn = 1;
    private int[,] buttons = new int[3, 3];
    private enum status : int{Owin = 1, Xwin = 2, GG = 3};
    private GUIStyle style = new GUIStyle();

    void Start () {
        Restart();
    }

    void Restart()
    {
        turn = 1;
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                buttons[i, j] = 0;
            }
        }
        GUI.Label(new Rect(300, 170, 100, 50), "", style);
    }

    void OnGUI()
    {
        GUI.skin.button.fontSize = 25; 

        GUIStyle style = new GUIStyle();
        style.fontSize = 40;
        style.normal.textColor = new Color(255, 255, 255);

        if(GUI.Button(new Rect(360, 500, 80, 80), "Restart")){
            Restart();
        }

        int StatusCode = check();
        
        if (StatusCode == (int)status.Owin)
        {
            GUI.Label(new Rect(340, 170, 100, 50), "O wins!", style);
        }
        else if (StatusCode == (int)status.Xwin)
        {
            GUI.Label(new Rect(340, 170, 100, 50), "X wins!", style);
        }
		else if (StatusCode == (int)status.GG)
        {
            GUI.Label(new Rect(300, 170, 100, 50), "GameOver!", style);
        }

        for (int i=0; i<3; i++)
        {
            for(int j=0; j<3; j++) {
                if (buttons[i, j] == 1)
                {
                    GUI.Button(new Rect(280 + i * 80, 220 + j * 80, 80, 80), "O");
                }
				else if (buttons[i, j] == 2)
                {
                    GUI.Button(new Rect(280 + i * 80, 220 + j * 80, 80, 80), "X");
                }
				else if (GUI.Button(new Rect(280 + i * 80, 220 + j * 80, 80, 80), "")&&StatusCode==0)
                {
                    if (turn == 1)
                    {
                        buttons[i, j] = 1;
                    }
					else
                    {
                        buttons[i, j] = 2;
                    }
                    turn = -turn;
                }
            }
        }
    }

    int check()
    {
        for (int i = 0; i < 3; ++i)
        {
            if (buttons[i, 0] != 0 && buttons[i, 0] == buttons[i, 1] && buttons[i, 1] == buttons[i, 2])
            {
                return buttons[i, 0];
            }
        }   
        for (int j = 0; j < 3; ++j)
        {
            if (buttons[0, j] != 0 && buttons[0, j] == buttons[1, j] && buttons[1, j] == buttons[2, j])
            {
                return buttons[0, j];
            }
        }   
        if (buttons[1, 1] != 0 &&
            buttons[0, 0] == buttons[1, 1] && buttons[1, 1] == buttons[2, 2] ||
            buttons[0, 2] == buttons[1, 1] && buttons[1, 1] == buttons[2, 0])
        {
            return buttons[1, 1];
        }
        
        bool allClick = true;
        
        for (int i=0; i<3; i++)
        {
            for (int j=0; j<3; j++)
            {
                if (buttons[i, j] == 0)
                {
                    allClick = false;
                }
            }
        }
        if (allClick)
            return (int)status.GG;
            
        return 0;
    }
}

