using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public List<TowerType> allTowers = new List<TowerType>();

    private void Awake()
    {
        allTowers.Add(new TowerType("Tower_1",10,2, .5f, "TowerSprites/Tower1",0));
        allTowers.Add(new TowerType("Tower_2",15, 3, 0.5f, "TowerSprites/Tower2", 1));
    }

}

public class EnemyType
{

}

public class TowerType
{
    public float range, cooldown, currColdown = 0;
    public Sprite spr;
    public string name;
    public int price;
    public int type;

    public TowerType(string name, int price, float range, float cd, string path, int type)
    {
        this.name = name;
        this.price = price;
        this.range = range;
        this.type = type;
        cooldown = cd;
        spr = Resources.Load<Sprite>(path);
    }
}
