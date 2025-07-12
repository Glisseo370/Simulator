using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Action OnSetOrderName;  //�� ������
    public Action<float> OnChangeMoney; //��������� ������ ���������� �����
    public Action<float> OnChangePurchaseAmount; //����� ������� ������������
    public Action OnReseturchaseAmount; //����� ������� � ��������
    public Action OnUpIngridientsCount; //��������� ���������� ������������
    public Action OnDownIngridientsCount; //��������� ���������� ������������
    public Action OnCostCalculation; //������ ��������� ������;
}
