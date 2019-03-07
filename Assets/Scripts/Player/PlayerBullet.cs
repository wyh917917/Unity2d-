using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float DestroyTime = 1.2f;

    public int damage = 1;


    // Use this for initialization
    void Start()
    {
        gameObject.tag = "PlayerBullet";
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {


    }
}
