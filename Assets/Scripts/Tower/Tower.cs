using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameController gameController;

    public TowerType selfTower;
    public E_TowerType towerType;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();

        selfTower = gameController.allTowers[(int)towerType];
        GetComponent<SpriteRenderer>().sprite = selfTower.spr;
    }

    private void Update()
    {
        if (CanShoot())
            SearchEnemy();

        if (selfTower.currColdown > 0)
            selfTower.currColdown -= Time.deltaTime;
    }

    private bool CanShoot()
    {
        if (selfTower.currColdown <= 0)
            return true;
        return false;
    }

    private void Shoot(Transform enemy)
    {
        selfTower.currColdown = selfTower.cooldown;
        GameObject bull = Instantiate(bullet);
        bull.transform.position = transform.position;
        bull.GetComponent<Bullet>().SetTarget(enemy);
        Debug.Log("Shor");
    }

    private void SearchEnemy()
    {
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float currDistance = Vector2.Distance(transform.position, enemy.transform.position);

            if(currDistance < nearestEnemyDistance && currDistance <= selfTower.range)
            {
                nearestEnemy = enemy.transform;
                nearestEnemyDistance = currDistance;
            }
        }

        if (nearestEnemy != null)
            Shoot(nearestEnemy);
    }
}
