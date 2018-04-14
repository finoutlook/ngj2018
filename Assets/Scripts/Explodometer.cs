using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explodometer : MonoBehaviour {

    private float a;
    private float b;
    private float c;
    private float d;

    public float aMax = 100;
    public float bMax = 100;
    public float cMax = 100;
    public float dMax = 100;
    
	void Start ()
    {
		reset();
	}
	
	void Update ()
    {
        // check for lose condition
        checkLoseCondition();
	}

    public void apply(float a, float b, float c, float d)
    {
        this.a += a;
        this.b += b;
        this.c += c;
        this.d += d;

        Debug.Log("Explodometer: " + this.a + ", " + this.b + ", " + this.c + ", " + this.d);
    }

    private void checkLoseCondition()
    {
        // lose condition
        if (a >= aMax || b >= bMax || c >= cMax || d >= dMax)
        {
            // lose and explode
            Debug.Log("Explodometer: YOU LOSE!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void reset()
    {
        a = b = c = d = 0;
    }
}
