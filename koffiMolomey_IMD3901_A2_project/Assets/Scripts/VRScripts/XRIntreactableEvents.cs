using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;


public class XRIntreactableEvents : MonoBehaviour
{
    public GameObject test;

    //XRGeneralGrabTransformer transformer;

    public void OnSelected()
    {
        //interactableObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //test = interactableObject;
        //XRGeneralGrabTransformer transformer = GetComponent<XRGeneralGrabTransformer>();
        //transform.localScale = transformer.transform.localScale;
        ////transformer.GetComponent<XRGeneralGrabTransformer>().
        //Debug.Log("Scaled down");

    }

    public void Start()
    {
    //gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

    }

    private void Update()
    {
        
    }
}
