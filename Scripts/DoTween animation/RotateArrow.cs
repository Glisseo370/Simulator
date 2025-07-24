using UnityEngine;
using DG.Tweening;
using System;

public class RotateArrow : MonoBehaviour
{
    private Tween testTween;
    [SerializeField] private float y;

    [SerializeField] private float speedArrow;
    [SerializeField] private GameObject parentObject;

    [SerializeField] private int greenUpBorder;
    [SerializeField] private int greenDownBorder;

    [SerializeField] private int redUpBorder;
    [SerializeField] private int redDownBorder;
    private void Start()
    {
    }

    private void OnEnable()
    {
        testTween = gameObject.transform.DORotate(new Vector3(0, 0, -360f), speedArrow, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            testTween.Kill();
            float i = gameObject.transform.eulerAngles.z;
            y = (float)Math.Round(i);
            y = (float)Math.Round((y / 360) * 100);

            if (y <= greenUpBorder && y >= greenDownBorder)
            {
                Debug.Log("Зелёный");
                CostCalculation.Instance.priceCoefficient = 1.2f;
            }
            else if (y <= redUpBorder && y >= redDownBorder)
            {
                Debug.Log("Красный");
                CostCalculation.Instance.priceCoefficient = 1.5f;
            }
            else
            {
                Debug.Log("Синий");
                CostCalculation.Instance.priceCoefficient = 1;
            }
            EventBus.Instance.OnCostCalculation?.Invoke();
            NextOrder.Instance.NewOrder();
            Destroy(parentObject);
            CurrentOrder.Instance.CleanCurrentOrder();
        }

    }
}
