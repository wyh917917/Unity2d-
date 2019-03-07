using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EggT : MonoBehaviour {
    public GameObject EggImage;

	// Use this for initialization
	void Start () {
        EggImage.SetActive(false);
	}

    public void onOK(string sceneName)
    {
        //Destroy(); 
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
        EggImage.SetActive(false);//让自己隐藏  
    }

    public void onBack(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
        EggImage.SetActive(false);//让自己隐藏  
    }

        void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Time.timeScale = 0;
        EggImage.SetActive(true);
    }
}
