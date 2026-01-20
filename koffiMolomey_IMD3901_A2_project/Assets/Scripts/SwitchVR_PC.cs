using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchVR_PC : MonoBehaviour
{
   public  GameObject VRObjects;
   public  GameObject PCObjects;

    [SerializeField] bool toggle = false;

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.mKey.wasPressedThisFrame)//press m to swtich between VR and PC mode
        {
            toggle = !toggle;

        }

        if (toggle == true)//Turn on VR mode
        {
            VRObjects.SetActive(true);
            PCObjects.SetActive(false);
        }

        else if (toggle == false)//Turn on PC mode
        {
            VRObjects.SetActive(false);
            PCObjects.SetActive(true);
        }
    }
}
