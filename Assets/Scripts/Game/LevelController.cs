using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int levelWidth;
    [SerializeField] private int levelHeigh;
    [SerializeField] GameObject cellPrefab;

    public Sprite[] pathPrefab = new Sprite[2];
    public Transform cellParent;
    public List<GameObject> wayPoints = new List<GameObject>();
    public GameObject[,] allCels = new GameObject[10, 16];

    public int curWayX;
    public int curWayY;
    public GameObject firstCell;


    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
        LoadWayPoints();
    }

    private void CreateLevel()
    {
        bool isGround;
        Vector3 worldVec = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        for(int i = 0; i<levelHeigh; i++)
        {
            for (int j = 0; j < levelWidth; j++)
            {   
                int sprIndex = int.Parse(LoadLevel(1)[i].ToCharArray()[j].ToString());
                Sprite spr = pathPrefab[sprIndex];

                isGround = spr == pathPrefab[1] ? true : false;

                CreateCell(isGround, spr, j, i, worldVec);
            }
        }
    }

    private void CreateCell(bool isGround, Sprite spr, int i, int j, Vector3 vec)
    {
        GameObject cell = Instantiate(cellPrefab);

        cell.transform.SetParent(cellParent, false);

        cell.GetComponent<SpriteRenderer>().sprite = spr;
        float sprSizeX = cell.GetComponent<SpriteRenderer>().bounds.size.x;
        float sprSizey = cell.GetComponent<SpriteRenderer>().bounds.size.y;

        cell.transform.position = new Vector3(vec.x +(sprSizeX * i), vec.y +(sprSizey * -j));

        if(isGround)
        {
            cell.GetComponent<Cell>().isGround = true;

            if(firstCell == null)
            {
                firstCell = cell;
                curWayX = i;
                curWayY = j;
            }
        }

        allCels[j, i] = cell;
    }

    private string[] LoadLevel(int i)
    {
        TextAsset pathLevel = Resources.Load<TextAsset>("Level_" + i);

        string str = pathLevel.text.Replace(Environment.NewLine, string.Empty);

        return str.Split('*');
    }

    private void LoadWayPoints()
    {
        GameObject tmp;
        wayPoints.Add(firstCell);

        while(true)
        {
            tmp = null;

            if(curWayX > 0 && allCels[curWayY, curWayX - 1].GetComponent<Cell>().isGround &&
                !wayPoints.Exists(x => x == allCels[curWayY, curWayX - 1]))
            {
                tmp = allCels[curWayY, curWayX - 1];
                curWayX--;
            }
            else if (curWayX < (levelWidth - 1) && allCels[curWayY, curWayX + 1].GetComponent<Cell>().isGround &&
                !wayPoints.Exists(x => x == allCels[curWayY, curWayX + 1]))
            {
                tmp = allCels[curWayY, curWayX + 1];
                curWayX++;
            }
            else if (curWayY > 0 && allCels[curWayY - 1, curWayX].GetComponent<Cell>().isGround &&
                !wayPoints.Exists(x => x == allCels[curWayY - 1, curWayX]))
            {
                tmp = allCels[curWayY-1, curWayX];
                curWayY--;
            }
            else if (curWayY < (levelHeigh - 1) && allCels[curWayY + 1, curWayX].GetComponent<Cell>().isGround &&
    !wayPoints.Exists(x => x == allCels[curWayY + 1, curWayX]))
            {
                tmp = allCels[curWayY + 1, curWayX];
                curWayY++;
            }
            else
            {
                break;
            }

            wayPoints.Add(tmp);
        }
    }
}
