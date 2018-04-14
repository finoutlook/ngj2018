using UnityEngine;
using UnityEngine.SceneManagement;

public class Explodometer : MonoBehaviour
{

    private float a;
    private float b;
    private float c;
    //private float d;

    public float aMax = 255;
    public float bMax = 255;
    public float cMax = 255;
    //public float dMax = 100;

    public Flask flask;

	void Start ()
    {
		Reset();
	}
	
	void Update ()
    {
        // check for lose condition
        CheckLoseCondition();
	}

    public void Apply(float a, float b, float c/*, float d*/)
    {
        this.a = Mathf.Clamp( this.a + a, 0, aMax );
        this.b = Mathf.Clamp( this.b + b, 0, bMax );
        this.c = Mathf.Clamp( this.c + c, 0, cMax );
        //this.d = Mathf.Clamp( this.d + d, 0, dMax );

        flask.Color( this.a, this.b, this.c);

        Debug.Log("Explodometer: " + this.a + ", " + this.b + ", " + this.c /*+ ", " + this.d*/);
    }

    private void CheckLoseCondition()
    {
        // lose condition
        if ( a >= aMax || b >= bMax || c >= cMax )
        {
            // lose and explode
            Debug.Log("Explodometer: YOU LOSE!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Reset()
    {
        a = b = c /*= d*/ = 0;
        flask.Color( a, b, c );
    }
}
