using UnityEngine;

public class NextOrder : MonoBehaviour
{
    public static NextOrder Instance {  get; private set; }
    //[SerializeField] private CurrentOrder curOrder;

    [SerializeField] private GameObject orderPrefab;
    [SerializeField] private Transform orderListPlace;

    private void Awake()
    {
        Instance = this;
    }

    public void NewOrder()
    {
        int ran = Random.Range(0, TodayOrders.Instance.ordersId.Count);
        int id = TodayOrders.Instance.ordersId[ran];

        GameObject order = Instantiate(orderPrefab, orderListPlace);

        order.GetComponent<InstallationOrder>().nameId = id;
        order.GetComponent<InstallationOrder>().recipeId = ran;
        order.GetComponent<InstallationOrder>().orderTitle.text = DictionaryOrders.Instance.orders[id];

        //curOrder.id = id;
        //curOrder.orderName = DictionaryOrders.Instance.orders[id];
        //curOrder.orderRecipe = TodayOrders.Instance.ordersRecipe[ran];
        //EventBus.Instance.OnSetOrderName?.Invoke();

    }
}
