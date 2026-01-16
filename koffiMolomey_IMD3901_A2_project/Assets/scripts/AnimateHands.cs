using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHands : MonoBehaviour
{
    public InputActionProperty triggerValue;
    public InputActionProperty gripValue;

    public Animator handAnimator;


    // Update is called once per frame
    void Update()
    {

        float trigger = triggerValue.action.ReadValue<float>();
        float grip = gripValue.action.ReadValue<float>();

        //changing aniamtor values
        handAnimator.SetFloat("Trigger", trigger);

        handAnimator.SetFloat("Grip", grip);




    }
}
