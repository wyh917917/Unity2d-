using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float DestroyTime = 1.5f;

    public int damage = 1;
    

    // Use this for initialization
    void Start()
    {
        gameObject.tag = "Enemy";
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update() {


    }
}
