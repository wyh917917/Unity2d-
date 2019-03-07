using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int hp = 3;

    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            Destroy(gameObject);
            IniEnemy.KillCount += 1;
            IniEnemy.EnemyLeft -= 1;
        }
    }


    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        PlayerBullet bullet = otherCollider.gameObject.GetComponent<PlayerBullet>();

        if (otherCollider.gameObject.tag == "PlayerBullet")
        {

            Damage(bullet.damage);
            
            Destroy(bullet.gameObject);
            
        }
    }
}
