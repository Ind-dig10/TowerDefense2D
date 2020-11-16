using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int pathIndex = 0;
    private int speed = 4;
    private int health = 50;

    List<GameObject> wayPoints = new List<GameObject>();
   

    private void Start()
    {
        GetWayPoints();
    }

    private void Update()
    {
        Move();
        Death();
    }

    private void GetWayPoints()
    {
        wayPoints = GameObject.Find("Scripts").GetComponent<LevelController>().wayPoints;
    }

    private void Move()
    {
        Transform currWayPoint = wayPoints[pathIndex].transform;
        Vector3 currWayPos = new Vector3(currWayPoint.position.x + currWayPoint.GetComponent<SpriteRenderer>().bounds.size.x / 2,
            currWayPoint.position.y - currWayPoint.GetComponent<SpriteRenderer>().bounds.size.y / 2);


        Vector3 dir = currWayPos - transform.position;

        transform.Translate(dir.normalized * Time.deltaTime * speed);

        if(Vector3.Distance(transform.position, currWayPos) < 0.1f)
        {
            if (pathIndex < wayPoints.Count - 1)
                pathIndex++;
            else
                Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void Death()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
        
}

