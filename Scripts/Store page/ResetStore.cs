using UnityEngine;
using UnityEngine.UI;

public class ResetStore : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            EventBus.Instance.OnReseturchaseAmount?.Invoke();
        });
    }
}
