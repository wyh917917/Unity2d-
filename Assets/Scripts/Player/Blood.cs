using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour {

    public float speed = 5.0f;

    public float bloodnow;       //输入当前的血量  
    public float bloodbefore;
    public float bloodmax;
    // Use this for initialization
    void Start () {
        bloodbefore = bloodmax;
    }
	
	// Update is called once per frame
	void Update () {
        if (bloodbefore != bloodnow)
            bloodbefore = bloodnow;


        StartCoroutine(Changeblood(bloodnow / bloodmax));
    }

    IEnumerator Changeblood(float px)
    {
        //实现血条缩减  
        if (px < 0)
            px = 0;
        else if (px > 1)
            px = 1;

        if (this.transform.localScale.x >= px + 0.005 || this.transform.localScale.x <= px - 0.005)
        {
            yield return null;
            this.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(px, this.transform.localScale.y, this.transform.localScale.z), speed * Time.deltaTime / 3f);
        }
    }
}
