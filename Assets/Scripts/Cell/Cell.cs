using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public bool isGround;
    public bool hasTower = false;

    public GameObject shop, tower;
    public Color baseColor, currColor;


    private void OnMouseEnter()
    {
        if (!isGround && FindObjectsOfType<Shop>().Length == 0 )
            GetComponent<SpriteRenderer>().color = currColor;
    }

    private void OnMouseExit()
    {
        Debug.Log("kjhgfhjk");
        GetComponent<SpriteRenderer>().color = baseColor;
    }

    private void OnMouseDown()
    {
        if (!isGround && FindObjectsOfType<Shop>().Length == 0)
        {
            if(!hasTower)
            {
                GameObject shopObj = Instantiate(shop);
                shopObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
                shopObj.GetComponent<Shop>().selfCell = this;
            }
        }
    }

    public void BuildTower(TowerType towwer)
    {
        GameObject tempTower = Instantiate(tower);
        tempTower.transform.SetParent(transform, false);
        tempTower.transform.position = transform.position;
        tempTower.GetComponent<Tower>().towerType = (E_TowerType)towwer.type;

        hasTower = true;
        FindObjectOfType<Shop>().CloseShop();
    }
}
