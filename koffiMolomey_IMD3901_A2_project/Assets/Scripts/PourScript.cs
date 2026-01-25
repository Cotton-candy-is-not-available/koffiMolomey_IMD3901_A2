using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PourScript : MonoBehaviour
{


    //[SerializeField] Vector3 xRotationAxis = new Vector3(90.0f,0.0f,0.0f);

    public GameObject water;

    // ------ PC variables --------------
    [SerializeField] float targetAngle = 0.01f;

    [SerializeField] float speed = 1.0f;

    [SerializeField] float rotationProgress;
    [SerializeField] Quaternion PCStartRotation;
    [SerializeField] Quaternion PCEndRotation;

    // ------ VR variables --------------

    [SerializeField] float VRStartRotation = 1.0f;

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
        transform.localRotation = Quaternion.identity;//set begining rotation to parent

        if (transform.rotation.x>=VRStartRotation)
        {
            Debug.Log("POUR");

            water.SetActive(true);//turn on water particles

        }
        else if (transform.rotation.y<=VRStartRotation)
        {
            Debug.Log("NOT POUR");
            Debug.Log("POtransform.rotation.xUR" + transform.rotation.x);

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



        //transform.localRotation = Quaternion.identity;

        //Debug.Log("Stop" + transform.localRotation.x);

        //    //stop particles
        //    //make go back to original position

        //    if (transform.localRotation.x <= startAngle.x)
        //    {
        //        Debug.Log("back to start");

        //    }
        //    else
        //    {
        //    transform.Rotate(-xRotationAxis, speed);//rotates watering to original rotation

        //    }


    }

}







