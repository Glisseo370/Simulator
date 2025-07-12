using System;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static Money Instance {  get; private set; }

    [SerializeField] private TextMeshProUGUI moneyText;
    public float curMoney;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventBus.Instance.OnChangeMoney += ChangeMoney;
    }

    private void ChangeMoney(float money)
    {
        curMoney += money;
        float roundMoney = (float)Math.Round(curMoney, 2);
        moneyText.text = "$ : " + roundMoney.ToString();
    }
}
