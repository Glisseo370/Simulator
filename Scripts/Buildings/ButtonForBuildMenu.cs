using UnityEngine;
using UnityEngine.UI;

public class ButtonForBuildMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuWindow;

    private void Update()
    {
        if(menuWindow.activeInHierarchy == true)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
