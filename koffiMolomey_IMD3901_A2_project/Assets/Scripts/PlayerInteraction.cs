using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 5f;//range of camera ray
    public Camera PlayerCamera;
    public CrossHairUI crossHairUIScript;


    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, interactRange))
        {
            if (hit.collider.CompareTag("Interactable"))//if collider has hit an object with interactble tag
            {
                crossHairUIScript.SetInteract(true);//calling to create rollover effect

                if (Keyboard.current.eKey.wasPressedThisFrame)//epresses button
                {
                    //Button button = hit.collider.GetComponent<Button>();

                    //button.Press();


                }

                return;
            }
        }

        crossHairUIScript.SetInteract(false);


    }
}
