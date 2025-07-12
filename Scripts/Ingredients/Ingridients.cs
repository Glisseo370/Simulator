using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ingridients : MonoBehaviour
{
    [SerializeField] private int ingridientsId;
    public int ingridientCount;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            AddIngridients(ingridientsId);
        });
    }

    public void AddIngridients(int id)
    {
        CurrentIngridients.Instance.curIngridients.Add(id);
        CurrentIngridients.Instance.GetCurrentIngridients();
    }

    public void DeleteIngridients(int id)
    {
        CurrentIngridients.Instance.curIngridients.Remove(id);
    }
}
