using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class VRSFX : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XRGrabInteractable interactble = GetComponent<XRGrabInteractable>();
        interactble.selectEntered.AddListener(Selected);
        interactble.selectExited.AddListener(Deselected);
    }
    public void Selected(SelectEnterEventArgs arguments)
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance.pickupSFX);
    }

    public void Deselected(SelectExitEventArgs arguments)
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance.throwSFX);
    }
}
