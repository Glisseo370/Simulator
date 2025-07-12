using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorePrice : MonoBehaviour
{
    [SerializeField] private float unitPrice;
    [SerializeField] private float amountIngridient;
    [SerializeField] private float totalPrice;

    [SerializeField] private Button downAmountButton;
    [SerializeField] private Button upAmountButton;
    [SerializeField] private TextMeshProUGUI amountIngridientText;
    [SerializeField] private TextMeshProUGUI totalPriceText;

    private void Start()
    {
        downAmountButton.onClick.AddListener(() =>
        {
            DownAmount();
        });

        upAmountButton.onClick.AddListener(() =>
        {
            UpAmount();
        });

        EventBus.Instance.OnReseturchaseAmount += ResetPrice;
        EventBus.Instance.OnUpIngridientsCount += UpIngridientCount;
    }

    private void UpAmount()
    {
        amountIngridient++;
        if (amountIngridient > 20)
        {
            amountIngridient = 20;
            return;
        }
        ChangeTotalPrice();
        EventBus.Instance.OnChangePurchaseAmount?.Invoke(unitPrice);
    }

    private void DownAmount()
    {
        amountIngridient--;
        if (amountIngridient < 0)
        {
            amountIngridient = 0;
            return;
        }
        ChangeTotalPrice();
        EventBus.Instance.OnChangePurchaseAmount?.Invoke(-1 * unitPrice);
    }

    private void ChangeTotalPrice()
    {
        amountIngridientText.text = amountIngridient.ToString();
        totalPrice = amountIngridient * unitPrice;
        totalPriceText.text = totalPrice.ToString() + " $";
    }

    private void ResetPrice()
    {
        amountIngridient = 0;
        totalPrice = 0;
        amountIngridientText.text = amountIngridient.ToString();
        totalPriceText.text = totalPrice.ToString() + " $";
    }

    private void UpIngridientCount()
    {
        gameObject.GetComponent<TypeOfStoreIngridient>().typeOfIngridient.ingridientCount += (int)amountIngridient;
    }
}
