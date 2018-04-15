using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

    public float TTLSeconds;
    public float Speed;
    private float timeLived = 0;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if ( timeLived >= TTLSeconds)
        {
            // destroy
            GameObject.Destroy(this.gameObject);
        }

        timeLived += Time.deltaTime;
        this.transform.position = new Vector3(this.transform.position.x, transform.position.y + (Speed * Time.deltaTime), transform.position.z);
	}
}
