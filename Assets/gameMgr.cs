using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMgr : MonoBehaviour 
{
    float time = 30.0f;
    int score = 0;
    GameObject timerTxt;
    GameObject scoreTxt;
    GameObject itemGen;

    public void updateScore(int type)
    {
        if (type == 0)
        {
            score += 100;
        }
        else
        {
            score /= 2;
        }
    }

	// Use this for initialization
	void Start () 
	{
        this.timerTxt = GameObject.Find("time");
        this.scoreTxt = GameObject.Find("point");
        this.itemGen = GameObject.Find("itemMgr");
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.time -= Time.deltaTime;

        if(this.time < 0.0f)
        {
            this.time = 0.0f;
            this.itemGen.GetComponent<itemGen>().setParam(0.0f, 0.0f, 0, false);
        }
        else
        if( this.time >= 0 && this.time < 5)
        {
            this.itemGen.GetComponent<itemGen>().setParam(1.7f, -0.02f, 4, true);
        }
        else
        if (this.time >= 5 && this.time < 10)
        {
            this.itemGen.GetComponent<itemGen>().setParam(1.4f, -0.04f, 6, true);
        }
        else
        if (this.time >= 10 && this.time < 20)
        {
            this.itemGen.GetComponent<itemGen>().setParam(1.7f, -0.025f, 5, true);
        }
        else
        if (this.time >= 20 && this.time < 30)
        {
            this.itemGen.GetComponent<itemGen>().setParam(2.0f, -0.01f, 3, true);
        }

        this.timerTxt.GetComponent<Text>().text = this.time.ToString("F1");

        this.scoreTxt.GetComponent<Text>().text = this.score.ToString() + "point";
	}
}
