using UnityEngine;

public class ModelHolder : MonoBehaviour
{
    [SerializeField] private GameObject currentModel;
    [SerializeField] private GameObject choosenModel;

    [SerializeField] private GameObject temporaryModel;

    [SerializeField] private Transform choosenPlace;

    public void ChoosePlace(Transform place)
    {
        choosenPlace = place;

        if(choosenPlace.childCount == 1)
        {
            currentModel = choosenPlace.GetChild(0).gameObject;
        }
    }

    public void ChooseModel(GameObject model)
    {
        if(temporaryModel != null)
        {
            Destroy(temporaryModel);
            temporaryModel = null;
        }
        choosenModel = model;

        if(currentModel != null)
        {
            currentModel.SetActive(false);
        }

        temporaryModel = Instantiate(choosenModel, choosenPlace);
    }

    public void CancelChange()
    {
        Destroy(temporaryModel);
        choosenModel = null;
        if(currentModel != null)
        {
            currentModel.SetActive(true);
        }
        choosenPlace = null;
        temporaryModel = null;
    }

    public void AcceptChange()
    {
        if(temporaryModel != null)
        {
            if(currentModel != null)
            {
                Destroy(currentModel);
            }
            currentModel = null;
            temporaryModel = null;
            choosenModel = null;
            choosenPlace = null;
        }

    }
}
