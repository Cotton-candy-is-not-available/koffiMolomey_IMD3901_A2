using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PourScript : MonoBehaviour
{


    //[SerializeField] Vector3 xRotationAxis = new Vector3(90.0f,0.0f,0.0f);

    public GameObject water;

    [SerializeField] float targetAngle = 0.01f;

    [SerializeField] float speed = 1.0f;

    [SerializeField] float rotationProgress;
    [SerializeField] Quaternion startRotation;
    [SerializeField] Quaternion endRotation;


    private void Start()
    {
            water.SetActive(false);//turn off water particles

    }



    public void Pouring()
    {

        if (rotationProgress < 1 && rotationProgress >= 0)
        {
            rotationProgress += Time.deltaTime * 5;

            transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);//rotates watering can smoothly

            water.SetActive(true);//turn on water particles
        }



        //transform.localRotation = Quaternion.identity;

        //Debug.Log("pour" + transform.localRotation.x);

        //    if (transform.localRotation.x >= targetAngle)
        //    {

        //        //stay at this position
        //        //start particles
        //        Debug.Log("at position");
        //    }
        //    else
        //    {
        //    Quaternion.Lerp(transform.rotation, xRotationAxis, Time.time * speed);

        //    //transform.Rotate(xRotationAxis, speed);//rotates watering can till reaches pouring angle

        //}


    }


    public void StopPouring()
    {

        transform.localRotation = Quaternion.identity;//set begining rotation to parent

        startRotation = transform.rotation;//default rotation

        endRotation = Quaternion.Euler(90.0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        rotationProgress = 0;

        if(transform.rotation == startRotation)
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







