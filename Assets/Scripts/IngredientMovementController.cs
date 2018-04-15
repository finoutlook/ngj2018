using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientMovementController : MonoBehaviour {

	public Rigidbody2D rb2D;  

	public GameObject target;      
	public float moveTime = 0.1f;
	private float inverseMoveTime;
	private float index;
	public Explodometer explodometer;
    public ScoreManager scoreManager;
    

	// Use this for initialization
	void Start () {
		rb2D = GetComponent <Rigidbody2D> ();
		explodometer = GameObject.FindGameObjectWithTag("Explode").GetComponent<Explodometer>();
		scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
		//target = GetComponent <GameObject>();
		inverseMoveTime = 1f / moveTime;
	}
	
	// Update is called once per frame
	void Update () {	
		if (transform.position.y < 0)
		{
			scoreManager.UpdateScore(explodometer.Apply(index));
			Destroy(this.gameObject);
		}
		
	}

	public void ThrowIntoFlask(float index)
	{
		this.index=index;
		Vector2 start = transform.position;
		Vector2 end = target.transform.position;
		StartCoroutine (SmoothMovement (end));
		
	}

	private void Move(int x, int y)
	{
		Debug.Log("Moving");
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (x, y);
		StartCoroutine (SmoothMovement (end));
		
	}

	private IEnumerator SmoothMovement (Vector3 end)
        {
            //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
            //Square magnitude is used instead of magnitude because it's computationally cheaper.
            float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			Debug.Log("remainging " + sqrRemainingDistance);
            
            //While that distance is greater than a very small amount (Epsilon, almost zero):
            while(sqrRemainingDistance > 0.001f)
            {
                //Find a new position proportionally closer to the end, based on the moveTime
                Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
                
                //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
				Debug.Log("Moving the dragon");
                rb2D.MovePosition (newPostion);
                
                //Recalculate the remaining distance after moving.
                sqrRemainingDistance = (transform.position - end).sqrMagnitude;
                Debug.Log("Remaining distance: " + sqrRemainingDistance);
                //Return and loop until sqrRemainingDistance is close enough to zero to end the function
                yield return null;
            }
			rb2D.gravityScale = 1;
        }
}
