using TMPro;
using UnityEngine;

public class CurrentOrder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textName;

    public int id;
    public string orderName;
    public RecipeSO orderRecipe;

    private void Start()
    {
        EventBus.Instance.OnSetOrderName += SetNameOrder;
    }

    private void SetNameOrder()
    {
        textName.text = orderName;
    }

}
