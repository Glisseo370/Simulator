using UnityEngine;
using System;

public class CostCalculation : MonoBehaviour
{
    [SerializeField] private CurrentOrder currentOrder;

    public static CostCalculation Instance { get; private set; }

    public float priceCoefficient;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventBus.Instance.OnCostCalculation += Calculate;
    }

    private void Calculate()
    {
        EventBus.Instance.OnChangeMoney?.Invoke((float)Math.Round(currentOrder.orderRecipe.price * priceCoefficient, 2));
    }
}
