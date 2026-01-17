using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 5.0f;//range of camera ray
    public Camera PlayerCamera;
    public CrossHairUI crossHairUIScript;

    //Picking Up objects
    [SerializeField] Transform holdArea;
    [SerializeField] private float pickupForce = 155.0f;
    private GameObject heldObj;
    private Rigidbody heldObjRB;



    PickupScript pickup;

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


                    if (Keyboard.current.eKey.wasPressedThisFrame)//press e to grab and drop object
                    {

                    //if (pickup.heldObj == null)//if hand is empty
                    //{


                        //pickup object

                        //PickupScript pickup = gameObject.GetComponent<PickupScript>();//get pickup script
                        PickupObject(hit.transform.gameObject);//call pickup fucntion

                    //}


                    //else
                    //{
                    //    //Drop object
                    //    //PickupScript pickup = gameObject.GetComponent<PickupScript>();//get pickup script
                    //    pickup.DropObject();//call drop function

                    //}

                    //if (pickup.heldObj != null)
                    //{
                    //    //moveObject
                    //    //PickupScript pickup = gameObject.GetComponent<PickupScript>();//get pickup script
                    //    pickup.MoveObject();//call drop function
                    //}

                }

                    
                

               

                return;
            }
        }

        crossHairUIScript.SetInteract(false);


    }





    public void PickupObject(GameObject obj)
    {
        if (obj.GetComponent<Rigidbody>())
        {
            heldObjRB = obj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;//prevents object from falling
            heldObjRB.linearDamping = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;//prevents object form rotation
            heldObjRB.isKinematic = true;//prevents object from moving when hitting other objects in the scene
            heldObjRB.transform.parent = holdArea;//parent object to camera space so it can follow the camera

            heldObj = obj;
        }



    }


    public void DropObject()
    {

        heldObjRB.useGravity = true;//prevents object from falling
        heldObjRB.linearDamping = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;//prevents object form rotation

        heldObjRB.isKinematic = false;

        heldObjRB.transform.parent = null;//unfreeze transformations
        heldObj = null;



    }


    public void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }


}
