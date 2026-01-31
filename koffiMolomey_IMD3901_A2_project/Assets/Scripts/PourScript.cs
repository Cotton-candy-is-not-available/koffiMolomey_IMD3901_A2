using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PourScript : MonoBehaviour
{
    public GameObject water;

    // ------ PC variables --------------
    [SerializeField] float rotationProgress;
    [SerializeField] Quaternion PCStartRotation;
    [SerializeField] Quaternion PCEndRotation;

    // ------ VR variables --------------

    [SerializeField] float VRPourRotation = 30.0f;

    public GameObject VRObject;
    public GameObject wateringCan;


    private void Start()
    {
            water.SetActive(false);//turn off water particles

    }

    private void Update()
    {
        if (VRObject.activeSelf)//allow for pouring when VR mode is on
        {
            VRPouring();

            //Debug.Log("transform.rotation.z " + gameObject.transform.localRotation.z);
            //Debug.Log("transform.rotation.y " + gameObject.transform.localRotation.y);
            //Debug.Log("transform.rotation.x " + gameObject.transform.localRotation.x);

        }
    }


    public void Pouring()
    {

        if (rotationProgress < 1 && rotationProgress >= 0)
        {
            rotationProgress += Time.deltaTime * 5;//slowly rotate

            transform.rotation = Quaternion.Lerp(PCStartRotation, PCEndRotation, rotationProgress);//rotates watering can smoothly

            water.SetActive(true);//turn on water particles
        }

    }

    public void VRPouring()
    {
        Vector3 wateringCanRotation = wateringCan.transform.eulerAngles;
        Debug.Log("euler rotation" + wateringCanRotation.z);

        if (wateringCanRotation.z >= VRPourRotation || wateringCanRotation.x >= VRPourRotation)// if rotated more than VRPourRotation then start pouring
        {
            //Debug.Log("POUR");
            //Debug.Log("rot.z more " + wateringCanRotation.z);


            water.SetActive(true);//turn on water particles

        }
        else if (wateringCanRotation.z <= VRPourRotation || wateringCanRotation.x <= VRPourRotation)//if not rotating at VRPourRotation turn off water
        {
            //Debug.Log("NOT POUR");
            //Debug.Log("rot.z less " + wateringCanRotation.z);

            water.SetActive(false);//turn OFF water particles

        }

    }

    public void StopPouring()
    {

        transform.localRotation = Quaternion.identity;//set begining rotation to parent

        PCStartRotation = transform.rotation;//default rotation

        PCEndRotation = Quaternion.Euler(90.0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        rotationProgress = 0;

        if(transform.rotation == PCStartRotation)
        {
            Debug.Log("stop");
            water.SetActive(false);//turn off water particles

        }


    }

}







