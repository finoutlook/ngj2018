using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Color(float a, float b, float c)
    {
        var renderer = this.GetComponent<SpriteRenderer>();
        renderer.color = new UnityEngine.Color(a / 255f, b / 255f, c / 255f);
    }
}
