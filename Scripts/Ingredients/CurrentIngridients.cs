using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentIngridients : MonoBehaviour
{
    public static CurrentIngridients Instance { get; private set; }

    public HashSet<int> curIngridients = new HashSet<int>();

    [SerializeField] private TextMeshProUGUI curListIngridients;
    private void Awake()
    {
        Instance = this;
    }

    public void GetCurrentIngridients()
    {
        string curList = "";
        foreach(int element in curIngridients)
        {
            curList += DictionaryIngredients.Instance.ingredients[element] + "\n";
        }
        curListIngridients.text = curList;
    }

    public void DeleteCurrentIngridients()
    {
        curIngridients.Clear();
        curListIngridients.text = "";
    }
}
