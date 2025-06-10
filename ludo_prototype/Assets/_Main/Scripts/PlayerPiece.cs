using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    public PlayerColor color;
    public int currentIndex = -1; // -1 means not on board
    public int homeIndex = -1;
    public int stepsFromStart = 0; 
    public bool isHome = false;
    public bool hasFinished = false;

    public void Move(int steps)
    {
        if (hasFinished) return;

        if (currentIndex == -1)
        {
            if (steps == 6)
            {
                currentIndex = BoardManager.Instance.homeEntry[color];
                transform.position = BoardManager.Instance.GetMainTile(currentIndex).position;
            }
            return;
        }

        int totalStepsAfterMove = stepsFromStart + steps;

        if (!isHome && totalStepsAfterMove > 51)
        {
            int stepsPastLoop = totalStepsAfterMove - 52;

            if (stepsPastLoop < 6)
            {
                // Enter home row
                isHome = true;
                homeIndex = stepsPastLoop;
                transform.position = BoardManager.Instance.homeRows[color][homeIndex].position;
            }
            else
            {
                // Overshoot home row — invalid move
                return;
            }
        }
        else if (!isHome)
        {
            stepsFromStart += steps;
            currentIndex = (currentIndex + steps) % 52;
            transform.position = BoardManager.Instance.GetMainTile(currentIndex).position;
        }
        else
        {
            // Already in home row
            if (homeIndex + steps < 6)
            {
                homeIndex += steps;
                transform.position = BoardManager.Instance.homeRows[color][homeIndex].position;
            }
            else if (homeIndex + steps == 6)
            {
                hasFinished = true;
                gameObject.SetActive(false);
            }
        }

    }
}
