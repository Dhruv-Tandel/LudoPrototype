using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<PlayerPiece> redPieces;
    public List<PlayerPiece> greenPieces;
    public List<PlayerPiece> yellowPieces;
    public List<PlayerPiece> bluePieces;

    public PlayerColor currentTurn = PlayerColor.Red;
    public int lastRoll = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TryMove(redPieces[0]);
        }
    }

    void RollDice()
    {
        lastRoll = Random.Range(5, 7);
        Debug.Log("Rolled: " + lastRoll);
    }

    void TryMove(PlayerPiece piece)
    {
        if (piece.color != currentTurn) return;

        piece.Move(lastRoll);

        if (lastRoll != 6) // Don't skip turn on 6
        {
            AdvanceTurn();
        }
        
    }

    void AdvanceTurn()
    {
        currentTurn = (PlayerColor)(((int)currentTurn + 1) % 4);
        Debug.Log("Turn: " + currentTurn);
    }

}
