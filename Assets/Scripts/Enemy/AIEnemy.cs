using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    private bool IsWalk;
    private bool IsOnhit;
    private bool IsAtk;

    public Animator enemy_ani;
    public Transform player;
    public GameObject enemyOBG;
    public Rigidbody2D enemyRB2D;
    public HingeJoint2D HJ2D;

    public float finddistance = 10;
    public float chargedistance = 5;
    public float atkdistance = 2f;
    public float walkspeed = 2500;


    //private bool IsLookRight;
    private Vector3 SpriteOriginalScale;
    private Vector3 direction;
    private float minVelocity;
    private float maxVelocity;

    void Start()
    {
        IsWalk = false;
        IsAtk = false;

        HJ2D = GameObject.Find("DownBody").GetComponent<HingeJoint2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();

        SpriteOriginalScale = enemyOBG.transform.localScale;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        minVelocity = -1f;
        maxVelocity = 1f;
    }

    void FixedUpdate()
    {
        direction = player.position - this.transform.position;
        Lookplayer(direction);
        CanWalk(direction);
        CanAtk(direction);

        //////////////////////动画设置////////////  
        enemy_ani.SetBool("IsWalk", IsWalk);
        enemy_ani.SetBool("IsAtk", IsAtk);
    }

    void Lookplayer(Vector3 direction)
    {
        if (direction.x > 0)
        {
            //IsLookRight = false;
            enemyOBG.transform.localScale = SpriteOriginalScale;
            
        }
        else if (direction.x < 0)
        {
            //IsLookRight = true;
            enemyOBG.transform.localScale = new Vector3(-SpriteOriginalScale.x, SpriteOriginalScale.y, SpriteOriginalScale.z);

        }
    }

    void CanWalk(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) <= finddistance && Mathf.Abs(direction.x) >= chargedistance)
        {
            IsWalk = true;
            //向玩家移动  
            Vector3 forcedirect = Vector3.Normalize(direction);
            enemyRB2D.AddForce(forcedirect * walkspeed * Time.deltaTime);
            float x = Mathf.Clamp(enemyRB2D.velocity.x, minVelocity, maxVelocity);
            enemyRB2D.velocity = new Vector2(x, enemyRB2D.velocity.y);

        }
        else
        {
            IsWalk = false;
        }
    }


    void CanAtk(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) <= atkdistance && Mathf.Abs(direction.x) >= 0)
        {
            IsAtk = true;
            //向玩家攻击  

        }
        else
        {
            IsAtk = false;
        }
    }

    protected IniEnemy m_spawn;


    public void Init(IniEnemy spawn, int a)
    {
        m_spawn = spawn;
        m_spawn.m_EnemyCount += a;
    }
}
