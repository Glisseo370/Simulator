using System.Collections.Generic;
using UnityEngine;

public class DictionaryIngredients : MonoBehaviour
{
    public static DictionaryIngredients Instance { get; private set; }

    public Dictionary<int, string> ingredients = new Dictionary<int, string>()
    {
        // Fruits
        {100,"Apple"},
        {101,"Orange"},
        {102,"Cherry"},
        {103,"Lemon"},
        {104,"Lime"},

        // Alcogol
        {200,""},
        {201,""},
        {202,""},

        // Other
        {300,"Water"},
        {301,""},
        {302,""},
    };

    private void Awake()
    {
        Instance = this;
    }
}
