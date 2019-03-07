using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
    public Slider HPStrip;    //添加血条Slider的引用
    public static int hp;     //生命值初始化

    public HingeJoint2D HJ2D;
    public Rigidbody2D dbRB2D;
    public Rigidbody2D ubRB2D;
    public GameObject Player;
    public GameObject image;

    public GameObject[] enemy;
    public GameObject[] enemyShootPos;
    public GameObject[] players;

    public void Damage(int damageCount)
    {
        hp -= damageCount;
        HPStrip.value = hp;    //适当的时候对血条执行操作
        
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        EnemyBullet bullet = otherCollider.gameObject.GetComponent<EnemyBullet>();
        

        if (otherCollider.gameObject.tag == "Enemy")
        {

            Damage(bullet.damage);

            checkDeath();

            Destroy(bullet.gameObject);
        }
    }

    void Update()
    {
        
    }

    void Start()
    {
        hp = 8;
        HPStrip.value = HPStrip.maxValue = hp;    //初始化血条

        image.SetActive(false);  //隐藏死亡image
    }

    void checkDeath()
    {
        if (hp <= 0)
        {

            HJ2D.enabled = false;
            //this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<BloodUI>().enabled = false;
            GameObject.Find("UpBody").GetComponent<UpBody>().enabled = false;
            GameObject.Find("DownBody").GetComponent<DownBody>().enabled = false;

            GameObject.Find("UpBody").GetComponent<Animator>().enabled = false;
            GameObject.Find("DownBody").GetComponent<Animator>().enabled = false;

            

            enemyShootPos = GameObject.FindGameObjectsWithTag("EnemyShootPos");
            foreach (GameObject EnemyShootPos in enemyShootPos)
            {
                EnemyShootPos.GetComponent<EnemyShoot>().enabled = false;
            }

            GameObject.Find("PlayerShootPos").GetComponent<PlayerShoot>().enabled = false;

            GameObject.Find("MainCamera").GetComponent<CameraController>().enabled = false;

            dbRB2D.AddForce(new Vector2(Random.Range(-200f, 200f), Random.Range(0, 300f)));
            ubRB2D.AddForce(new Vector2(Random.Range(-200f, 200f), Random.Range(0, 300f)));

            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            dbRB2D.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            ubRB2D.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            StartCoroutine(wait());

            
        }
    }

    public void onOK()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject Player in players)
        {
            Destroy(Player);
        }
        SceneManager.LoadScene("map1");
        Time.timeScale = 1;
        image.SetActive(false);//让自己隐藏  
    }

    public void onBack()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject Player in players)
        {
            Destroy(Player);
        }
        SceneManager.LoadScene("mainMenu");
        Time.timeScale = 1;
        image.SetActive(false);//让自己隐藏  
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.0f);

        Time.timeScale = 0;

        image.SetActive(true);

        //Destroy(gameObject);

        
    }
}
