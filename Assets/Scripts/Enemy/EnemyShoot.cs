using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    public Transform shootPos;
    public AudioClip shotAudio;
    private AudioSource audioSource;
    public GameObject BulletPrefab;
    public Animator anim;
    public Transform Player;
    public float FireRate = 1f;
    private float NextFire;
    public float BulletSpeed = 3.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player = GameObject.Find("Player").GetComponent<Transform>();
        //shootPos = GetComponent<Transform>();
        //anim = GetComponent<Animator>();
        //Player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //计时器，子弹发射有间隙
        NextFire += Time.fixedDeltaTime;

        bool IsAtk = anim.GetBool("IsAtk");

        if (IsAtk == true && NextFire > FireRate)
        {

            //播放射击声效
            audioSource.PlayOneShot(shotAudio);

            //记录玩家位置
            Vector3 direction = Player.position - this.transform.position;

            //计时器归零
            NextFire = 0;

            //生成子弹
            GameObject b = Instantiate(BulletPrefab, shootPos.position, Quaternion.identity) as GameObject;

            //子弹速度由鼠标点击的位置减去屏幕的宽高的1/2得到
            //主要就是坐标的转换
            b.GetComponent<Rigidbody2D>().velocity = (direction.normalized * BulletSpeed);
            //将所有子弹放在一个父物体下，方便操作
            b.transform.SetParent(GameObject.Find("Bullets").transform);
        }

    }


}