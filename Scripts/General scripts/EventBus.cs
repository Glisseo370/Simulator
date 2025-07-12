using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Action OnSetOrderName;  //На экране
    public Action<float> OnChangeMoney; //Изменение общего количества денег
    public Action<float> OnChangePurchaseAmount; //Сумма покупки ингредиентов
    public Action OnReseturchaseAmount; //Сброс покупок в магазине
    public Action OnUpIngridientsCount; //Увеличить количество ингредиентов
    public Action OnDownIngridientsCount; //Уменьшить количество ингредиентов
    public Action OnCostCalculation; //Расчёт стоимости заказа;
}
