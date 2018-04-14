using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBar : MonoBehaviour
{
    public Explodometer explodometer;

    public Ingredient ingredient1;
    public Ingredient ingredient2;
    public Ingredient ingredient3;
    public Ingredient ingredient4;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Ingredient 1 used");
            explodometer.Apply(ingredient1.a, ingredient1.b, ingredient1.c /*ingredient1.d*/);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Ingredient 2 used");
            explodometer.Apply(ingredient2.a, ingredient2.b, ingredient2.c /*ingredient2.d*/);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Ingredient 3 used");
            explodometer.Apply(ingredient3.a, ingredient3.b, ingredient3.c /*ingredient3.d*/);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Ingredient 4 used");
            explodometer.Apply(ingredient4.a, ingredient4.b, ingredient4.c /*ingredient4.d*/);
        }
    }
}
