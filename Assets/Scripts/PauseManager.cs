using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
    public GameObject image;

    public Text killCount;
    public Text enemyCount;

    void Start() {
        Destroy(GameObject.Find("BGM"));
        image.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            image.SetActive(true);

        }

        //if(!GameObject.FindGameObjectWithTag("Enemy"))
        //{
        //    SceneManager.LoadScene("mainMenu");
        //}

        killCount.text = "已杀死：" + IniEnemy.KillCount + "名敌人";
        enemyCount.text = "还剩余：" + IniEnemy.EnemyLeft + "名敌人";
    }

    public void onOK(string sceneName)
    {
        //Destroy(); 
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
        image.SetActive(false);//让自己隐藏  
    }

    public void onBack()
    {

        Time.timeScale = 1;
        image.SetActive(false);//让自己隐藏  
    }



}
