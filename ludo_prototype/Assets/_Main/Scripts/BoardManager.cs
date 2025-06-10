using UnityEngine;
using System.Collections.Generic;
public enum PlayerColor { Red, Green, Yellow, Blue }
public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;

    public Transform[] mainPathTiles; // 52 tiles

    public GameObject mainpath;
    public Transform[] redHomeRow;
    public Transform[] greenHomeRow;
    public Transform[] yellowHomeRow;
    public Transform[] blueHomeRow;

    public Dictionary<PlayerColor, int> homeEntry = new();
    public Dictionary<PlayerColor, Transform[]> homeRows = new();

    private void Awake()
    {
        mainPathTiles = new Transform[mainpath.transform.childCount];
        Instance = this;
        int i = 0;
        foreach (Transform obj in mainpath.transform)
        {
            mainPathTiles[i] = obj;
            i++;
         
        }

        homeEntry[PlayerColor.Red] = 13;
        homeEntry[PlayerColor.Green] = 26;
        homeEntry[PlayerColor.Yellow] = 39;
        homeEntry[PlayerColor.Blue] = 0;

        homeRows[PlayerColor.Red] = redHomeRow;
        homeRows[PlayerColor.Green] = greenHomeRow;
        homeRows[PlayerColor.Yellow] = yellowHomeRow;
        homeRows[PlayerColor.Blue] = blueHomeRow;
    }

    public Transform GetMainTile(int index)
    {
        return mainPathTiles[index % mainPathTiles.Length];
    }
}
