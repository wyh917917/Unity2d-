using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IniEnemy : MonoBehaviour {

    public Transform m_Enemy;

    public int m_EnemyCount = 0;  

    public int m_EnemyMax;

    public float m_EnemyTime = 0;

    public static int KillCount ;   //供EnemyHealth调用
    public static int EnemyLeft ;   //供EnemyHealth调用


    protected Transform m_transform;

    void Start()
    {
        m_transform = GetComponent<Transform>();

        EnemyLeft = m_EnemyMax;
        KillCount = 0;
    }


    void Update()
    {

        m_EnemyTime -= Time.deltaTime;

        if (m_EnemyTime <= 0)
        {
            if (m_EnemyCount < 10)
            {
                m_EnemyTime = Random.Range(0, 4f);
            }
            else if (m_EnemyCount >= 10 && m_EnemyCount < m_EnemyMax)
            {
                m_EnemyTime = Random.Range(0, 1.5f);
            }
            else
            {
                return;
            }
            Transform transformEnemy = (Transform)Instantiate(m_Enemy, m_transform.position, Quaternion.identity);
            //获取敌人脚本
            AIEnemy enemy = transformEnemy.GetComponent<AIEnemy>();
            //初始化敌人
            enemy.Init(this, 1);
            enemy.transform.SetParent(GameObject.Find("AllEnemy").transform);
        }

    }

}
