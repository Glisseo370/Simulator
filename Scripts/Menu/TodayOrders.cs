using System.Collections.Generic;
using UnityEngine;

public class TodayOrders : MonoBehaviour
{
    public static TodayOrders Instance { get; private set; }

    [SerializeField] public List<int> ordersId /*{ get; }*/ = new List<int>();
    [SerializeField] public List<RecipeSO> ordersRecipe /*{ get; }*/ = new List<RecipeSO>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddOrder(int id, RecipeSO recipe, bool isChosen)
    {
        if(isChosen == false)
        {
            ordersId.Add(id);
            ordersRecipe.Add(recipe);
        }
        else
        {
            ordersId.Remove(id);
            ordersRecipe.Remove(recipe);
        }
    }
}
