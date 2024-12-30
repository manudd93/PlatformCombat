using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{

    public int Damage;
    public int Speed;
    public int TimeDestroy;
    public LayerMask mask;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, TimeDestroy);
    }

    public void SetBullet(int damage,int speed,int timeDestroy)
    {
        Damage = damage;
        Speed = speed;
        TimeDestroy = timeDestroy;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==9)
        {
            collision.GetComponent<EnemyBaseHealt>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
    }

   
  
}
