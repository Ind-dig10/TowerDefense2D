using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCpawner : MonoBehaviour
{
    [SerializeField] private LevelController levelController;

    public float timeToSpawn = 4;
    private int spawntCount = 0;
    public GameObject enemyPrefab;
   

    private void Update()
    {
        if(timeToSpawn <= 0)
        {
            StartCoroutine(SpawnEnemy(spawntCount + 1));
            timeToSpawn = 4;
        }

        timeToSpawn -= Time.deltaTime;

    }

    IEnumerator SpawnEnemy(int enemyCount)
    {
        spawntCount++;

        for(int i = 0; i< enemyCount; i++)
        {
            GameObject tmpEnemy = Instantiate(enemyPrefab);
            tmpEnemy.transform.SetParent(gameObject.transform, false);

            Transform startCelPosition = levelController.wayPoints[0].transform;
            Vector3 startPos = new Vector3(startCelPosition.position.x + startCelPosition.GetComponent<SpriteRenderer>().bounds.size.x / 2,
                startCelPosition.position.y + startCelPosition.GetComponent<SpriteRenderer>().bounds.size.y);


            tmpEnemy.transform.position = startPos;
           
            yield return new WaitForSeconds(0.3f);
        }
    }
}
