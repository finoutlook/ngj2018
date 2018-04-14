using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBar : MonoBehaviour
{
    public Explodometer explodometer;
    public ScoreManager scoreManager;
    public GameLoopScript gameLoop;

    public List<Ingredient> ingredients;

    // Use this for initialization
    void Start ()
    {
        ingredients = gameLoop.GetNewIngredients();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && ingredients.Count > 0 )
        {
            Debug.Log("Ingredient 1 used");
            explodometer.Apply(ingredients[0].A, ingredients[0].B, ingredients[0].C /*ingredient1.d*/);
            scoreManager.UpdateScore(1);
            ingredients = gameLoop.GetNewIngredients();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && ingredients.Count > 1)
        {
            Debug.Log("Ingredient 2 used");
            explodometer.Apply(ingredients[1].A, ingredients[2].B, ingredients[1].C /*ingredient2.d*/);
            scoreManager.UpdateScore(1);
            ingredients = gameLoop.GetNewIngredients();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && ingredients.Count > 2)
        {
            Debug.Log("Ingredient 3 used");
            explodometer.Apply(ingredients[2].A, ingredients[2].B, ingredients[2].C /*ingredient3.d*/);
            scoreManager.UpdateScore(1);
            ingredients = gameLoop.GetNewIngredients();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && ingredients.Count > 3)
        {
            Debug.Log("Ingredient 4 used");
            explodometer.Apply(ingredients[3].A, ingredients[3].B, ingredients[3].C /*ingredient4.d*/);
            scoreManager.UpdateScore(1);
            ingredients = gameLoop.GetNewIngredients();
        }
    }
}
