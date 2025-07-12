using System.Collections.Generic;
using UnityEngine;

public class DictionaryOrders : MonoBehaviour
{
    public static DictionaryOrders Instance {  get; private set; }

    public Dictionary<int, string> orders = new Dictionary<int, string>()
    {
        {0,"Water"},
        {1,"Apple juice"},
        {2,"Multifruit"},
    };

    private void Awake()
    {
        Instance = this;
    }
}
