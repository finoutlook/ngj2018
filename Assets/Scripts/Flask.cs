using System;
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

    // -100 = green, 0 = blue, 100 = red
    public void Color(float x)
    {
        float blue = 255 - Math.Abs(x);
        float green = 0;
        float red = 0;

        if (x < 0)
        {
            green = Math.Abs(x);
        }

        if (x > 0)
        {
            red = x;
        }       

        var renderer = this.GetComponent<SpriteRenderer>();
        renderer.color = new UnityEngine.Color(red / 255f, green / 255f, blue / 255f);
    }
}
