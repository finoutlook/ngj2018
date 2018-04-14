using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLoopScript : MonoBehaviour {

    public int Level = 1;
    public int Turn = 1;
    public int NumberOfIngredientsPerTurn = 5;

    private List<Ingredient> AllPossibleIngredients;
    private List<Ingredient> CurrentIngredients;

	// Use this for initialization
	void Start () {
        AllPossibleIngredients = new List<Ingredient>()
        {
            new Ingredient("Apple", 20, 0, 0, 0, 1),
            new Ingredient("Orange", -10, 10, 0, 0, 1),
            new Ingredient("Strawberry", 5, -10, 15, 1, 1),
            new Ingredient("Banana", 0, 30, -5, 1, 1)
        };

        CurrentIngredients = GetNewIngredients();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Turn < 11)
            {
                string ingredientOutput = string.Empty;

                foreach (var ingredient in CurrentIngredients)
                {
                    ingredientOutput += ingredient.ToString() + " ";
                }

                Debug.Log("Level: " + Level + ", Turn: " + Turn + ", Ingredients: " + ingredientOutput);
                Turn++;
            }
            else
            {
                Debug.Log("Game finished");
            }
        }
	}

    public List<Ingredient> GetNewIngredients()
    {
        var newIngredients = new List<Ingredient>();

        // only ingredients available at this level
        var possibleIngredients = AllPossibleIngredients.Where(x => x.UnlockedAtLevel <= Level);

        if (possibleIngredients != null && possibleIngredients.Any())
        {
            for (int i = 0; i < NumberOfIngredientsPerTurn; i++)
            {
                int index = Random.Range(0, possibleIngredients.Count());
                newIngredients.Add(possibleIngredients.ElementAt(index));
            }
        }

        return newIngredients;
    }
}