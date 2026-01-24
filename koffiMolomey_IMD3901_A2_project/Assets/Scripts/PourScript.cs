using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PourScript : MonoBehaviour
{

    public Vector3 xRotationAxis = new Vector3(1.0f,0.0f,0.0f);

    public float targetAngle = 0.01f;

    public float speed = 1.0f;


    public void Rotate()
    {

        //Debug.Log("transform" + transform.localRotation.x);


        if (transform.localRotation.x >= targetAngle)
        {

            //stay at this position
            Debug.Log("rotatingnnnnnn");
        }
        else
        {
            transform.Rotate(xRotationAxis, speed);//rotates watering can till reaches pouring angle

        }
        //make go back to original position

    }

}
