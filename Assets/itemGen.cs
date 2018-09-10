using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGen : MonoBehaviour 
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0.0f;
    float maxSpan = 2.0f;
    float minSpeed = -0.01f;
    int maxBomb = 3;
    bool isGen = true;

    public void setParam(float span, float speed, int bombnum, bool gen)
    {
        this.maxSpan = span;
        this.minSpeed = speed;
        this.maxBomb = bombnum;
        this.isGen = gen;
    }

	// Use this for initialization
	void Start () 
    {
        this.span = Random.Range(0.5f, this.maxSpan);
    }
	
	// Update is called once per frame
	void Update () 
    {
        this.delta += Time.deltaTime;

        if(this.delta > this.span && isGen)
        {
            this.delta = 0.0f;
            this.span = Random.Range(0.5f, this.maxSpan);

            int type = Random.Range(0, 11);

            GameObject item;
            if(type < this.maxBomb)
            {
                item = Instantiate(bombPrefab) as GameObject;
            }
            else
            {
                item = Instantiate(applePrefab) as GameObject;
            }

            int x = Random.Range(-1, 2);
            int z = Random.Range(-1, 2);
            float y = Random.Range(3.0f, 5.0f);

            item.transform.position = new Vector3(x, y, z);

            item.GetComponent<itemController>().setMinSpeed(this.minSpeed);
        }
	}
}
