using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Explodometer : MonoBehaviour
{
    public float degradeSpeed = 10;
    private float difficulty;

    private float _x;
    //private float b;
    //private float c;
    //private float d;

    public float xMax = 255;
    //public float bMax = 255;
    //public float cMax = 255;
    //public float dMax = 100;

    public Flask flask;
    public Slider slider;

	void Start ()
    {
		Reset();
	}
	
	void Update ()
    {
        // change stability
        if ( _x < 0 )
        {
            Apply(-degradeSpeed * Time.deltaTime, false);
        }
        else if ( _x > 0 )
        {
            Apply(degradeSpeed * Time.deltaTime, false);
        }

        // check for lose condition
        CheckLoseCondition();
	}

    public int Apply(float x, bool increaseDifficulty = true/*, float b, float c, float d*/)
    {
        _x = Mathf.Clamp(_x + x, -xMax, xMax );
        //this.b = Mathf.Clamp( this.b + b, 0, bMax );
        //this.c = Mathf.Clamp( this.c + c, 0, cMax );
        //this.d = Mathf.Clamp( this.d + d, 0, dMax );

        flask.Color(_x);
        slider.value = _x;

        if ( increaseDifficulty )
        {
            degradeSpeed++;
        }

        return (int)(Mathf.Round(1 * Mathf.Abs(_x)) + difficulty);

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
