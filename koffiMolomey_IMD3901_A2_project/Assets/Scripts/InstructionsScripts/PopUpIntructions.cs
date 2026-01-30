using UnityEngine;

public class PopUpIntructions : MonoBehaviour
{
    public GameObject eToInteract;

    // Update is called once per frame
    public void eToInteractOnOff(bool OnOff)
    {
       eToInteract.SetActive(OnOff);//Turn ON interact prompt 
    }
}
