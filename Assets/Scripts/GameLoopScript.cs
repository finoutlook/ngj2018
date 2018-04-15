using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLoopScript : MonoBehaviour {

    public int Level = 1;
    public int Turn = 1;
    public int NumberOfIngredientsPerTurn = 4;

    public List<GameObject> AllPossibleIngredients;
    public List<GameObject> SpawnPoints;

    public int CurrentNumberOfNegativeIngredients = 0;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    public List<GameObject> GetNewIngredients()
    {
        var newIngredients = new List<GameObject>();

        // only ingredients available at this level
        var possibleIngredients = AllPossibleIngredients.Where(x => x.GetComponent<Ingredient>().UnlockedAtLevel <= Level);
        
        if (possibleIngredients != null && possibleIngredients.Any())
        {
            int ingredientsAdded = 0;

            while (ingredientsAdded < NumberOfIngredientsPerTurn)
            {
                int index = Random.Range(0, possibleIngredients.Count());
                var ingredient = GameObject.Instantiate(possibleIngredients.ElementAt(index), SpawnPoints[ingredientsAdded].transform.position, Quaternion.identity);

                if (ingredient.GetComponent<Ingredient>().X < 0 && CurrentNumberOfNegativeIngredients < NumberOfIngredientsPerTurn - 1)
                {
                    newIngredients.Add(ingredient);
                    CurrentNumberOfNegativeIngredients++;
                    ingredientsAdded++;
                }
                else if (ingredient.GetComponent<Ingredient>().X >= 0 && CurrentNumberOfNegativeIngredients > 0)
                {
                    newIngredients.Add(ingredient);
                    ingredientsAdded++;
                }
                else
                {
                    GameObject.Destroy(ingredient);
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
            bool suitableIngredientFound = false;

            while (!suitableIngredientFound)
            {
                int index = Random.Range(0, possibleIngredients.Count());
                ingredient = GameObject.Instantiate(possibleIngredients.ElementAt(index), position, Quaternion.identity);

                if (ingredient.GetComponent<Ingredient>().X < 0 && CurrentNumberOfNegativeIngredients < NumberOfIngredientsPerTurn - 1)
                {
                    CurrentNumberOfNegativeIngredients++;
                    suitableIngredientFound = true;
                }
                else if (ingredient.GetComponent<Ingredient>().X >= 0 && CurrentNumberOfNegativeIngredients > 0)
                {
                    suitableIngredientFound = true;
                }
                else
                {
                    GameObject.Destroy(ingredient);
                }
            }
        }
        
        return ingredient;
    }

    public void RemoveNegativeIngredient()
    {
        CurrentNumberOfNegativeIngredients--;
    }
}