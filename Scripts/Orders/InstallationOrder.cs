using TMPro;
using UnityEngine;

public class InstallationOrder : MonoBehaviour
{
    public int nameId;
    public int recipeId;

    public TextMeshProUGUI orderTitle;
    private void Awake()
    {

    }

    public void Installation()
    {
        CurrentOrder.Instance.id = nameId;
        CurrentOrder.Instance.orderName = DictionaryOrders.Instance.orders[nameId];
        CurrentOrder.Instance.orderRecipe = TodayOrders.Instance.ordersRecipe[recipeId];
        CurrentOrder.Instance.orderRecord = gameObject;
        EventBus.Instance.OnSetOrderName?.Invoke();
    }
}
