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


                if (Keyboard.current.eKey.wasPressedThisFrame)//press e to grab and drop object
                    {
                    if (pickup.heldObj == null)//if hand is empty
                    {
                        //pickup object
                        pickup.PickupObject(hit.transform.gameObject);//call pickup fucntion

                    }


                    else//if hand is not empty
                    {
                        //Drop object
                        pickup.DropObject();//call drop function

                    }

                    if (pickup.heldObj != null)//if there is an object picked up
                    {
                        //moveObject
                        pickup.MoveObject();//call drop function
                    }

                }

                 //Watering function 
                if (pickup.heldObj != null)//if hand is empty
                {
                    if (hit.collider.GetComponent<PourScript>())
                    {
                        if (Keyboard.current.rKey.isPressed)//Hold R key to rotate object
                        {
                            //Allow water to pour if watering can
                            PourScript pouring = hit.collider.GetComponent<PourScript>();
                            pouring.Pouring();


                        }
                        else
                        {
                            //Stop water from pouring
                            PourScript pouring = hit.collider.GetComponent<PourScript>();
                            pouring.StopPouring();
                        }
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
