using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchVR_PC : MonoBehaviour
{
   public  GameObject VRObjects;
   public  GameObject PCObjects;

   public Transform VRPlayerPos;
   public Transform PCPlayerPos;

   public GameObject crossHair;

   public TextMeshProUGUI ToggleText;

    public GameObject soundSettingsCanvas;

   [SerializeField] bool toggle;

    void Awake()
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

            //set VR PLayer to same position as PC Player
            VRPlayerPos = PCPlayerPos;

            //Change text to view which mode user is in
            ToggleText.GetComponent<TextMeshProUGUI>().text = "VR mode";

            VRObjects.SetActive(true);//activate VR hands and controls

            PCObjects.SetActive(false);//turn OFF PC controls
            crossHair.SetActive(false);//turn ON crossHair


        }

        else if (toggle == false)//Turn on PC mode
        {
            //set VR PLayer to same position as PC Player
            PCPlayerPos = VRPlayerPos;

            ToggleText.GetComponent<TextMeshProUGUI>().text = "PC mode";

            VRObjects.SetActive(false);//deactivate VR hands and controls

            PCObjects.SetActive(true);//turn ON PC controls
            crossHair.SetActive(true);//turn ON crossHair



        }
    }
}
