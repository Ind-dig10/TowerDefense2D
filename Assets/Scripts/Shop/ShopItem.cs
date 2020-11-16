using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TowerType selfTower;
    public Cell selfCell;

    public Image towerLogo;
    public Text towerName;

    public Color baseColor, currColor;


    public void SetData(TowerType tower, Cell cell)
    {
        selfTower = tower;
        towerName.text = tower.name;
        selfCell = cell;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Тут должна быть проверка списания монет игрока
        selfCell.BuildTower(selfTower);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = currColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = baseColor;
    }
}
