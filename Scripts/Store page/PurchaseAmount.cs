using System;
using TMPro;
using UnityEngine;

public class PurchaseAmount : MonoBehaviour
{
    public static PurchaseAmount Instance {  get; private set; }
    public float totalAmount;
    [SerializeField] private TextMeshProUGUI textTotalAmount;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventBus.Instance.OnChangePurchaseAmount += ChangePruchaseAmount;
        EventBus.Instance.OnReseturchaseAmount += ResetRurchaseAmount;
    }

    private void ChangePruchaseAmount(float amount)
    {
        totalAmount += amount;
        float roundTotalPrice = (float)Math.Round(totalAmount, 2);
        textTotalAmount.text = "Summa:   " + roundTotalPrice.ToString();
    }

    private void ResetRurchaseAmount()
    {
        totalAmount = 0;
        textTotalAmount.text = "Summa:   " + totalAmount.ToString();
    }
}
