using UnityEngine;

public class BuildingMode : MonoBehaviour
{
    [SerializeField] private GameObject buildCamera;
    [SerializeField] private Player player;
    [SerializeField] private GameObject buildPlace;

    private bool isModeOn = false;

    public void BuildingModeActive()
    {
        if(isModeOn == false)
        {
            buildPlace.SetActive(true);
            buildCamera.SetActive(true);
            player.enabled = false;
            isModeOn = true;
        }
        else
        {
            buildPlace.SetActive(false);
            buildCamera.SetActive(false);
            player.enabled = true;
            isModeOn = false;
        }
    }
}
