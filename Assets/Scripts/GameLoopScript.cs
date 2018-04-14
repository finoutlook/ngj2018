using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLoopScript : MonoBehaviour {

    public int Level = 1;
    public int Turn = 1;
    public int NumberOfIngredientsPerTurn = 5;

    public List<GameObject> AllPossibleIngredients;
    public List<GameObject> SpawnPoints;
    private List<GameObject> CurrentIngredients;


	// Use this for initialization
	void Start () {
        /*AllPossibleIngredients = new List<Ingredient>()
        {
            new Ingredient("Apple", 20, 0, 0, 0, 1),
            new Ingredient("Orange", -10, 10, 0, 0, 1),
            new Ingredient("Strawberry", 5, -10, 15, 1, 1),
            new Ingredient("Banana", 0, 30, -5, 1, 1)
        };
        */
        //CurrentIngredients = GetNewIngredients();
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
                    ingredientOutput += ingredient.GetComponent<Ingredient>().ToString() + " ";
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

    public List<GameObject> GetNewIngredients()
    {
        var newIngredients = new List<GameObject>();

        // only ingredients available at this level
        var possibleIngredients = AllPossibleIngredients.Where(x => x.GetComponent<Ingredient>().UnlockedAtLevel <= Level);
        
        if (possibleIngredients != null && possibleIngredients.Any())
        {
            int negativeAddedSoFar = 0;

            int ingredientsAdded = 0;

            while (ingredientsAdded < NumberOfIngredientsPerTurn)
            {
                int index = Random.Range(0, possibleIngredients.Count());
                var obj = GameObject.Instantiate(possibleIngredients.ElementAt(index), SpawnPoints[ingredientsAdded].transform.position, Quaternion.identity);

                if (obj.GetComponent<Ingredient>().X < 0 && negativeAddedSoFar < NumberOfIngredientsPerTurn - 1)
                {
                    newIngredients.Add(obj);
                    negativeAddedSoFar++;
                    ingredientsAdded++;
                }
            }
        }

        return newIngredients;
    }

    public GameObject GetNewIngredient(Vector3 position)
    {
        GameObject ingredient = null;

        // only ingredients available at this level
        var possibleIngredients = AllPossibleIngredients.Where(x => x.GetComponent<Ingredient>().UnlockedAtLevel <= Level);

        if (possibleIngredients != null && possibleIngredients.Any())
        {
            int index = Random.Range(0, possibleIngredients.Count());
            ingredient = GameObject.Instantiate(possibleIngredients.ElementAt(index), position, Quaternion.identity);
        }

        return ingredient;
    }
}