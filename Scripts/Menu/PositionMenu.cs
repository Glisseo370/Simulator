using UnityEngine;
using UnityEngine.UI;

public class PositionMenu : MonoBehaviour
{
    [SerializeField] private int orderId;
    [SerializeField] private RecipeSO orderName;
    [SerializeField] private GameObject chosenMark;

    private bool isChosen = false;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            TodayOrders.Instance.AddOrder(orderId, orderName, isChosen);
            if(isChosen == false)
            {
                isChosen = true;
                chosenMark.SetActive(true);
            }
            else
            {
                isChosen = false;
                chosenMark.SetActive(false);
            }
        });
    }
}
