using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour {
    public Text textColor;
    // Use this for initialization
    void Start () {
        StartCoroutine(ChangeColors());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ChangeColors()
    {
        yield return new WaitForSeconds(0.1f);
        textColor.color = RandomColor();     //蓝 红 黑 三色切换
        yield return new WaitForSeconds(0.1f);
        textColor.color = RandomColor();
        yield return new WaitForSeconds(0.1f);
        textColor.color = RandomColor();
        yield return StartCoroutine(ChangeColors());
    }


    public Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        Color color = new Color(r, g, b);
        return color;
    }
}
