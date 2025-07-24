using UnityEngine;
using UnityEngine.UI;

public class CheckRecipe : MonoBehaviour
{
    [SerializeField] private CurrentOrder curOrder;
    [SerializeField] private Transform placeForCircle;
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            Check();
            //NextOrder.Instance.NewOrder();
        });
    }

    private void Check()
    {
        if (CurrentOrder.Instance.orderRecord != null)
        {
            if (CurrentIngridients.Instance.curIngridients.SetEquals(curOrder.orderRecipe.ingredients))
            {
                Instantiate(curOrder.orderRecipe.arrow, placeForCircle);
            }
            else
            {
                Debug.Log("Нет");
            }
        }
        else
        {
            Debug.Log("Не выбран заказ");
        }
    }
}
