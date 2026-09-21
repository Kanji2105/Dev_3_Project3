using UnityEngine;
using UnityEngine.InputSystem;

public class TurnMovement : MonoBehaviour
{
    
    public int maxMoves = 5;   // how many tiles the player is able to move 
    public int movesLeft;     // how many move is avaible

    private GridTransform gridTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gridTransform = GetComponent<GridTransform>();  // will help to find the player grid tranform component
        movesLeft = maxMoves;  




    }

    // Update is called once per frame
    void Update()
    {
        Vector2Int input = Vector2Int.zero; // will help to lock the player from moving anywhere else exept the moves anmd the grid

        if (Keyboard.current.wKey.wasPressedThisFrame)
            input.y = 1;

        if (Keyboard.current.sKey.wasPressedThisFrame)
            input.y = -1;

        if (Keyboard.current.aKey.wasPressedThisFrame)
            input.x = -1;

        if (Keyboard.current.dKey.wasPressedThisFrame)
            input.x = 1;
        //wasPreseed will help unity to count the key pressed once, so the player wont move cintinuesly

        if (movesLeft > 0 && input != Vector2Int.zero)
        {
            gridTransform.Move(input);
            movesLeft--;

            Debug.Log("MovesLeft: " + movesLeft);
        }

        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            movesLeft = maxMoves;
            Debug.Log("New turn! Moves resets to: " + movesLeft);
                

        }



    }
}
