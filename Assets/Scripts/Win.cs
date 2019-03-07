using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Win : MonoBehaviour {

    public GameObject winImage;

    
	// Use this for initialization
	void Start () {
        winImage.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		if(IniEnemy.EnemyLeft == 0)
        {
            Time.timeScale = 0;
            winImage.SetActive(true);
        }

        
    }

    public void onRestart()
    {
        SceneManager.LoadScene("map1");
        Time.timeScale = 1;
        winImage.SetActive(false);//让自己隐藏  
    }

    public void onBack()
    {
        SceneManager.LoadScene("mainMenu");
        Time.timeScale = 1;
        winImage.SetActive(false);//让自己隐藏  
    }
}
