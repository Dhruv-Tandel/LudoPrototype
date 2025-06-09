using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    public PlayerColor color;
    public int currentIndex = -1; // -1 means not on board
    public int homeIndex = -1;
    public bool isHome = false;
    public bool onMainPath = false;
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
                onMainPath = true;
            }
            return;
        }

        int entryPoint = BoardManager.Instance.homeEntry[color];

        if (!isHome && currentIndex + steps > entryPoint && !onMainPath)//TODO: wrong logic for overshoot
        {
            int overShoot = currentIndex + steps - entryPoint - 1;
            if (overShoot < 6)
            {
                isHome = true;
                homeIndex = overShoot;
                transform.position = BoardManager.Instance.homeRows[color][homeIndex].position;
            }
        }
        else if (onMainPath)
        {
            currentIndex += steps;
            transform.position = BoardManager.Instance.GetMainTile(currentIndex).position;
        }
        else if (isHome)
        {
            if (homeIndex + steps < 6)
            {
                homeIndex += steps;
                transform.position = BoardManager.Instance.homeRows[color][homeIndex].position;
            }
            else if (homeIndex + steps == 6)
            {
                hasFinished = true;
                gameObject.SetActive(false); // Reached center
            }
        }
    }
}
