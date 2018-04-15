using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Explodometer : MonoBehaviour
{
    public float degradeSpeed = 10;
    private float difficulty;
    public GameObject PointsText;

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
    public ScoreManager scoreManager;

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
        slider.value = Mathf.Abs(_x);

        var points = 0;

        if ( increaseDifficulty )
        {
            points = (int)(Mathf.Round(1 * Mathf.Abs(_x)) + degradeSpeed); 
            degradeSpeed++;
            PointsText.GetComponent<Text>().text = "+" + points.ToString();
            Instantiate(PointsText, GameObject.FindGameObjectWithTag("GUI").transform);
        }
        
        return points;
        Debug.Log("Explodometer: " + _x);
    }

    private void CheckLoseCondition()
    {
        // lose condition
        if (_x <= -xMax || _x >= xMax/* || b >= bMax || c >= cMax*/)
        {
            // lose and explode
            Debug.Log("Explodometer: YOU LOSE!");

            ApplicationModel.playerScore = scoreManager.GetScore();

            SceneManager.LoadScene("Win");
        }
    }

    private void Reset()
    {
        _x = 0;
        flask.Color(_x);
    }
}
