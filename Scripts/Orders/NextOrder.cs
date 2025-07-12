using UnityEngine;

public class NextOrder : MonoBehaviour
{
    public static NextOrder Instance {  get; private set; }
    [SerializeField] private CurrentOrder curOrder;

    private void Awake()
    {
        Instance = this;
    }

    public void NewOrder()
    {
        int ran = Random.Range(0, TodayOrders.Instance.ordersId.Count);
        int id = TodayOrders.Instance.ordersId[ran];
        curOrder.id = id;
        curOrder.orderName = DictionaryOrders.Instance.orders[id];
        curOrder.orderRecipe = TodayOrders.Instance.ordersRecipe[ran];
        EventBus.Instance.OnSetOrderName?.Invoke();
    }
}
