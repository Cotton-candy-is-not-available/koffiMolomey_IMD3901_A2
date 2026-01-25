using UnityEngine;

public class GrowFlowers : MonoBehaviour
{
    [SerializeField] GameObject Stem;

    [SerializeField] float increaseHeightValue = 0.1f;

    [SerializeField] float maxHeight = 5.0f;

    private void OnParticleCollision(GameObject other)
    {
        //if (Stem.transform.localScale.y <= maxHeight) { 
        //    Stem.transform.localScale += new Vector3(0.0f, increaseHeightValue, 0.0f);
        //    Debug.Log("Growwwwwww");

        //}
        //else
        //{
        //    Debug.Log("Max reached");
        //}

        //Stem.transform.localScale += new Vector3(0.0f, 0.1f, 0.0f);//increase stem high by 0.1f

        //kep going until reaches max height
    }



}
