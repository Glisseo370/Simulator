using UnityEngine;
using UnityEngine.UI;

public class BuyIngridients : MonoBehaviour
{
    [SerializeField] private GameObject notEnoughWindow;
    [SerializeField] private GameObject wantBuyWindow;
    [SerializeField] private GameObject needSomeWindow;
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            if(PurchaseAmount.Instance.totalAmount == 0)
            {
                needSomeWindow.SetActive(true);
            }
            else if (PurchaseAmount.Instance.totalAmount <= Money.Instance.curMoney)
            {
                wantBuyWindow.SetActive(true);
            }
            else
            {
                notEnoughWindow.SetActive(true);
            }
        });
    }

    public void Buy()
    {
        EventBus.Instance.OnUpIngridientsCount?.Invoke();
        EventBus.Instance.OnChangeMoney?.Invoke(-1 * PurchaseAmount.Instance.totalAmount);
    }
}
