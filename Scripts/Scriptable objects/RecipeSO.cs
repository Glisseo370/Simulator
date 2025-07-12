using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RecipeSO")]
public class RecipeSO : ScriptableObject
{
    public int orderId;
    public List<int> ingredients;
    public GameObject arrow;
    public float price;
}
