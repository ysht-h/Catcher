using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketController : MonoBehaviour 
{

    public AudioClip applese;
    public AudioClip bombse;
    AudioSource audioPlayer;
    GameObject gameDir;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "apple")
        {
            this.audioPlayer.PlayOneShot(this.applese);
            gameDir.GetComponent<gameMgr>().updateScore(0);
        }
        else
        {
            this.audioPlayer.PlayOneShot(this.bombse);
            gameDir.GetComponent<gameMgr>().updateScore(1);
        }
        Destroy(other.gameObject);
    }

	// Use this for initialization
	void Start () 
	{
        this.gameDir = GameObject.Find("gameDir");
        this.audioPlayer = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () 
	{

        if( Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);

                transform.position = new Vector3(x, 0.0f, z);
            }
        }
		
	}
}
