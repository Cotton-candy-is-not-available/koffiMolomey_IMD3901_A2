using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PourScript : MonoBehaviour
{


    //[SerializeField] Vector3 xRotationAxis = new Vector3(90.0f,0.0f,0.0f);

    public GameObject water;

    // ------ PC variables --------------
    [SerializeField] float rotationProgress;
    [SerializeField] Quaternion PCStartRotation;
    [SerializeField] Quaternion PCEndRotation;

    // ------ VR variables --------------

    [SerializeField] float VRStartRotation = 0.03f;

    public GameObject VRObject;


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
            rotationProgress += Time.deltaTime * 5;

            transform.rotation = Quaternion.Lerp(PCStartRotation, PCEndRotation, rotationProgress);//rotates watering can smoothly

            water.SetActive(true);//turn on water particles
        }

    }

    public void VRPouring()
    {
        //gameObject.transform.localRotation = Quaternion.identity;//set begining rotation to parent

        if (gameObject.transform.rotation.y>=VRStartRotation)
        {
            //Debug.Log("POUR");
            Debug.Log("transform.rotation.z more " + gameObject.transform.rotation.z);


            water.SetActive(true);//turn on water particles

        }
        else if (gameObject.transform.rotation.y<=VRStartRotation)
        {
            //Debug.Log("NOT POUR");
            Debug.Log("transform.rotation.z less " + gameObject.transform.rotation.z);

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







