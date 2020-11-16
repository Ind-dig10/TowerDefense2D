using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform target;
    private float speed = 7;
    private int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    private void Move()
    {
        if(target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < .1f)
            {
                target.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
            }
               
            else
            {
                Vector2 dir = target.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * speed);
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }

}
