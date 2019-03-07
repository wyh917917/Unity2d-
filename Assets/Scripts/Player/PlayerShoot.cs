using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public Transform Spawn;
    public AudioClip shotAudio;
    private AudioSource audioSource;
    public GameObject BulletPrefab;
    public float FireRate ;

    private float NextFire;
    public float BulletSpeed ;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Spawn = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    void FixedUpdate()
    {
        //计时器，子弹发射有间隙
        NextFire += Time.fixedDeltaTime;
        //如果按下了鼠标左键且计时器大于发射间隙
        if (Input.GetKey(KeyCode.J) && NextFire > FireRate)
        {

            //播放射击声效
            audioSource.PlayOneShot(shotAudio);
            //计时器归零
            NextFire = 0;

            //生成子弹
            GameObject b = Instantiate(BulletPrefab, Spawn.position, Quaternion.identity) as GameObject;

            if (UpBody.facingRight)
            {
                b.GetComponent<Rigidbody2D>().velocity = (new Vector3(1, 0, 0) * BulletSpeed);
            }
            else{
                b.GetComponent<Rigidbody2D>().velocity = (new Vector3(-1, 0, 0) * BulletSpeed);
            }

            //将所有子弹放在一个父物体下，方便操作
            b.transform.SetParent(GameObject.Find("Bullets").transform);
        }
      
    }

}