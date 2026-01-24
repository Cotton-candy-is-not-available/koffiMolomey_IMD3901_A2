using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 4.0f;//range of camera ray
    public Camera PlayerCamera;
    public CrossHairUI crossHairUIScript;
    public PopUpIntructions ePickupPrompt;

    //public SeedSpawner spawn;


    public PickupScript pickup ;
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

                ePickupPrompt.eToInteractOnOff(true);//turn ON e to interact prompt

                //---------------------------------------------------------------//
                //rotate function
                if (pickup.heldObj != null)//if hand is empty
                {
                    if (Keyboard.current.rKey.isPressed)//Hold R key to rotate object
                    {
                        //Debug.Log("Rotate");
                        PourScript pouring = hit.collider.GetComponent<PourScript>();
                        pouring.Rotate();

                    }
                }
//---------------------------------------------------------------//


                if (Keyboard.current.eKey.wasPressedThisFrame)//press e to grab and drop object
                    {
                    if (pickup.heldObj == null)//if hand is empty
                    {
                        //pickup object
                        pickup.PickupObject(hit.transform.gameObject);//call pickup fucntion
                       
                        //if (Keyboard.current.rKey.wasPressedThisFrame)//press R to rotate object
                        //{
                        //    Debug.Log("Rotate");
                        //    hit.transform.gameObject.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);//rotate object  90degrees on objects x axis
                        //}

                    }


                    else//if hand is not empty
                    {
                        //Drop object
                        pickup.DropObject();//call drop function

                    }

                    if (pickup.heldObj != null)
                    {
                        //moveObject
                        pickup.MoveObject();//call drop function
                    }

                }

                return;
            }
            else
            {
                ePickupPrompt.eToInteractOnOff(false);//turn OFF e to interact prompt

            }

        }

        crossHairUIScript.SetInteract(false);


    }




}
