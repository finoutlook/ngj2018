using UnityEngine;
using UnityEngine.SceneManagement;

public class Explodometer : MonoBehaviour
{
    private float _x;
    //private float b;
    //private float c;
    //private float d;

    public float xMax = 255;
    //public float bMax = 255;
    //public float cMax = 255;
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

    public void Apply(float x/*, float b, float c, float d*/)
    {
        _x = Mathf.Clamp(_x + x, -xMax, xMax );
        //this.b = Mathf.Clamp( this.b + b, 0, bMax );
        //this.c = Mathf.Clamp( this.c + c, 0, cMax );
        //this.d = Mathf.Clamp( this.d + d, 0, dMax );

        flask.Color(_x);

        Debug.Log("Explodometer: " + _x);
    }

    private void CheckLoseCondition()
    {
        // lose condition
        if (_x <= -xMax || _x >= xMax/* || b >= bMax || c >= cMax*/)
        {
            // lose and explode
            Debug.Log("Explodometer: YOU LOSE!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Reset()
    {
        _x = 0;
        flask.Color(_x);
    }
}
