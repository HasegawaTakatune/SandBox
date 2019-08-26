using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GAMESTATE
    {
        TITLE,
        PLAY,
        GAMEOVER
    }

    public GAMESTATE gameState;

    private void Start()
    {
        gameState = GAMESTATE.TITLE;
    }

    private void Update()
    {
     
        
    }

    private void Title()
    {

    }
}
