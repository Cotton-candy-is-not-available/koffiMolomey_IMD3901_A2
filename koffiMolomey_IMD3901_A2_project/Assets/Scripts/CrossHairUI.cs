using UnityEngine;
using UnityEngine.UI;

public class CrossHairUI : MonoBehaviour
{
    public Image crossHairImage;
    public Color normalColor = Color.white;
    public Color interactColor = Color.pink;


    public void SetInteract(bool canInteract)
    {
        crossHairImage.color=canInteract ? interactColor : normalColor;
    }

}
