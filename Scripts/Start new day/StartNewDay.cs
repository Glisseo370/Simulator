using UnityEngine;
using UnityEngine.UI;

public class StartNewDay : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            NextOrder.Instance.NewOrder();

            gameObject.SetActive(false);
        });
    }

    private void StartDay()
    {
        
    }
}
