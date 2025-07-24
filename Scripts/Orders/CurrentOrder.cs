using TMPro;
using UnityEngine;

public class CurrentOrder : MonoBehaviour
{
    public static CurrentOrder Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI textName;

    public int id;
    public string orderName;
    public RecipeSO orderRecipe;
    public GameObject orderRecord;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        EventBus.Instance.OnSetOrderName += SetNameOrder;
    }

    private void SetNameOrder()
    {
        textName.text = orderName;
    }


    public void CleanCurrentOrder()
    {
        Destroy(orderRecord);
        textName.text = "";
        orderRecipe = null;
        orderName = "";
    }
}
