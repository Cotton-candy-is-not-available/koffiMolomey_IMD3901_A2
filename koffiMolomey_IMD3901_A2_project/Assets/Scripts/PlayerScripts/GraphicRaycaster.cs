using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GraphicRayCaster : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public CrossHairUI CrossHairUIAccess;

    bool hoveringButton = false; //to check if the buttons on the world space UI are being hovered


    void Start()
    {
        //fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //fetch the Event System from the Scene
        m_EventSystem = EventSystem.current;
    }

    void Update()
    {
        hoveringButton = false;

        if (Mouse.current == null) return;
        {
            m_PointerEventData = new PointerEventData(EventSystem.current);

            //set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = new Vector2(Screen.width / 2f, Screen.height / 2f);

            //create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //for every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("Clicked 11");

                //check if the left Mouse button is clicked
                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    string clickedButtonName = result.gameObject.name;
                    Debug.Log("Clicked " + result.gameObject.name);
                   
                }

                //if raycast is covering
                if (result.gameObject.GetComponent<Button>())
                {
                    hoveringButton = true;
                }
            }
        }
        Debug.Log(hoveringButton+ "hovering");
        CrossHairUIAccess.SetInteract(hoveringButton); //constantly update based on raycast

    }
}
