using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchVR_PC : MonoBehaviour
{
   public  GameObject VRObjects;
   public  GameObject PCObjects;

   public Transform VRPlayerPos;
   public Transform PCPlayerPos;


    [SerializeField] bool toggle;

    private void Start()
    {
        toggle = false;

    }

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

            //set VR PLayer to same position as PC Player
            VRPlayerPos = PCPlayerPos;
        }

        else if (toggle == false)//Turn on PC mode
        {
            VRObjects.SetActive(false);
            PCObjects.SetActive(true);

            //set VR PLayer to same position as PC Player
            PCPlayerPos = VRPlayerPos;
        }
    }
}
