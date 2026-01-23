using UnityEngine;

public class PickupScript : MonoBehaviour
{

    [SerializeField] Transform holdArea;
    public GameObject heldObj;
    public Rigidbody heldObjRB;

    [SerializeField] private float pickupForce = 155.0f;

    float defaultScale = 1f;
    float smallScale = 0.5f;



    public void PickupObject(GameObject obj)
    {
            if (obj.GetComponent<Rigidbody>())
        {
            SoundFXManager.Instance.PlaySFX(SoundFXManager.Instance.pickupSFX);//play pickup SFX
            heldObjRB = obj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;//prevents object from falling
            heldObjRB.linearDamping = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;//prevents object from rotating
            heldObjRB.isKinematic = true;//prevents object from moving when hitting other objects in the scene

            heldObjRB.transform.parent = holdArea;//parent object to camera space so it can follow the camera

            holdArea.transform.localScale = new Vector3(smallScale, smallScale, smallScale);//make heldObj and hold area smaller when held

            heldObjRB.transform.position = holdArea.position;//move object to hold area positon

            heldObj = obj;
        }



    }


    public void DropObject()
    {
        heldObjRB.useGravity = true;//let the item fall
        heldObjRB.linearDamping = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;//prevents object form rotation

        heldObjRB.isKinematic = false;

        holdArea.transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale); ;//bring hold area and heldObj back to original size for the next object

        heldObjRB.transform.parent = null;//unfreeze transformations and unparent


        heldObj = null;//hand is now empty



    }


    public void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }


}
