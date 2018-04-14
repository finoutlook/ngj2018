using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{    
    public string Name;

    public float A;
    public float B;
    public float C;
    public int UnlockedAtLevel { get; set; }
    public int Scarcity { get; set; }

    public Ingredient( string name, float a, float b, float c, int unlockedAtLevel, int scarcity )
    {
        Name = name;
        A = a;
        B = b;
        C = c;
        UnlockedAtLevel = unlockedAtLevel;
        Scarcity = scarcity;
    }

    public override string ToString()
    {
        return "[Name: " + Name + " - A: " + A + " B: " + B + " C: " + C + "]";
    }
}
