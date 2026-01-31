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

   public TextMeshProUGUI modeText;
   public TextMeshProUGUI xHideShowText;


    public GameObject xHideShowRect;
    public GameObject PCInstructionsCanvas;

    bool toggle;
   [SerializeField] bool PCInstructionsCanvasToggle;

    void Awake()
    {
        toggle = true;
        PCInstructionsCanvasToggle = false;

    }

    void Update()
    {

        if (Keyboard.current.mKey.wasPressedThisFrame)//press m to swtich between VR and PC mode
        {
            toggle = !toggle;

        }
        if (Keyboard.current.xKey.wasPressedThisFrame)//press x to turn on instruction
        {
            PCInstructionsCanvasToggle = !PCInstructionsCanvasToggle;

        }

        if (toggle == true)//Turn on VR mode
        {

            //set VR PLayer to same position as PC Player
            VRPlayerPos = PCPlayerPos;

            //Change text to view which mode user is in
            modeText.GetComponent<TextMeshProUGUI>().text = "VR mode";

            VRObjects.SetActive(true);//activate VR hands and controls

            PCObjects.SetActive(false);//turn OFF PC controls
            crossHair.SetActive(false);//turn ON crossHair
            PCInstructionsCanvas.SetActive(false);//turn off pc button instructions
            xHideShowRect.SetActive(false);


        }

        else if (toggle == false)//Turn on PC mode
        {
            //set VR PLayer to same position as PC Player
            PCPlayerPos = VRPlayerPos;

            modeText.GetComponent<TextMeshProUGUI>().text = "PC mode";

            VRObjects.SetActive(false);//deactivate VR hands and controls

            PCObjects.SetActive(true);//turn ON PC controls
            crossHair.SetActive(true);//turn ON crossHair

            xHideShowRect.SetActive(true);//show box saying press x to hide and show instructions


            if (PCInstructionsCanvasToggle)// show PC button instructions
            {
                PCInstructionsCanvas.SetActive(true);
                xHideShowText.GetComponent<TextMeshProUGUI>().text = "X to hide";

            }
            else
            {
                PCInstructionsCanvas.SetActive(false);// do not show PC button instructions
                xHideShowText.GetComponent<TextMeshProUGUI>().text = "X to show";

            }
        }
    }
}
