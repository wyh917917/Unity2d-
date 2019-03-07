using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodUI : MonoBehaviour {
    public float xOffset;
    public float yOffset;
    public RectTransform recTransform;


    void Start()
    {
        

    }
    void Update()
    {
        Vector2 player2DPosition = transform.position;
        recTransform.position = player2DPosition + new Vector2(xOffset, yOffset);

        //血条超出屏幕就不显示  
        //if (player2DPosition.x > Screen.width || player2DPosition.x < 0 || player2DPosition.y > Screen.height || player2DPosition.y < 0)
        //{
        //    recTransform.gameObject.SetActive(false);
        //}
        //else
        //{
        //    recTransform.gameObject.SetActive(true);
        //}
    }
}
