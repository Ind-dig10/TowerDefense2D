using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform itemGrid;

    private GameController gameController;
    [SerializeField] private Button closeButton;

    public Cell selfCell;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        closeButton.onClick.AddListener(CloseShop);

        foreach(TowerType tower in gameController.allTowers)
        {
            GameObject item = Instantiate(itemPrefab);
            item.transform.SetParent(itemGrid, false);
            item.GetComponent<ShopItem>().SetData(tower, selfCell);
        }
    }

    public void CloseShop()
    {
        Destroy(gameObject);
    }
}
