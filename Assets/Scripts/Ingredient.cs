using UnityEngine;

public class Ingredient : MonoBehaviour
{    
    public string Name;

    public float X;
    //public float B;
    //public float C;
    public int UnlockedAtLevel { get; set; }
    public int Scarcity { get; set; }

    public Ingredient( string name, float x, /*float b, float c,*/ int unlockedAtLevel, int scarcity )
    {
        Name = name;
        X = x;
        //B = b;
        //C = c;
        UnlockedAtLevel = unlockedAtLevel;
        Scarcity = scarcity;
    }

    public override string ToString()
    {
        return "[Name: " + Name + " - X: " + X + "]"; // B: " + B + " C: " + C + "]";
    }
}
