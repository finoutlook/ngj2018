using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBar : MonoBehaviour
{
    public Explodometer explodometer;
    public ScoreManager scoreManager;
    public GameLoopScript gameLoop;

    public List<GameObject> ingredients;

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
            addIngredient(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && ingredients.Count > 1)
        {
            Debug.Log("Ingredient 2 used");
            addIngredient(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && ingredients.Count > 2)
        {
            Debug.Log("Ingredient 3 used");
            addIngredient(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && ingredients.Count > 3)
        {
            Debug.Log("Ingredient 4 used");
            addIngredient(3);
        }
    }

    private void addIngredient(int i)
    {
        Ingredient ingredient = ingredients[i].GetComponent<Ingredient>();
        scoreManager.UpdateScore(explodometer.Apply(ingredient.X));
        reloadIngredient(i, ingredients[i].transform.position);
    }

    private void reloadIngredient(int index, Vector3 position)
    {
        GameObject.Destroy(ingredients[index]);
        ingredients[index] = gameLoop.GetNewIngredient(position);
    }

    private void refreshIngredients()
    {
        foreach ( GameObject obj in ingredients )
        {
            GameObject.Destroy(obj);
        }
        ingredients.Clear();
        ingredients = gameLoop.GetNewIngredients();
    }
}
