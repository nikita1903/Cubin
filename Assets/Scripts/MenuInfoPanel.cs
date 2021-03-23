using UnityEngine;

public class MenuInfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    private bool isActive = false;
    public void DisableInformation()
    { 
        infoPanel.SetActive(!isActive);
        isActive = !isActive;
    }
}
