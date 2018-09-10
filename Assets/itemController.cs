using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour 
{

    float speed = 0.0f;
    float minSpeed = -0.01f;

    public void setMinSpeed(float p)
    {
        this.minSpeed = p;
    }

	// Use this for initialization
	void Start () 
	{
        this.speed = Random.Range(-0.06f, this.minSpeed);
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(0.0f, this.speed, 0.0f);
        if(transform.position.y < -1.0f)
        {
            Destroy(gameObject);
        }
	}
}
