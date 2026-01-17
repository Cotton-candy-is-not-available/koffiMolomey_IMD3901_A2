using UnityEngine;

public class SeedManager : MonoBehaviour
{
   //public Vector3 lastPosition;
  public CropSpawner cropSpawner;//make access on creation

    //crop that we want to plant
    public GameObject cropPrefab;


    void OnCollisionStay(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Dirt")//if it collides with the dirt
            {
            cropSpawner.lastPosition = gameObject.transform.position ;//spawn plant here

            Debug.Log("last positon of seed: "+ cropSpawner.lastPosition);

            cropSpawner.SpawCrop(cropPrefab);//spawn respective crop
            // destroy this object
            Destroy(gameObject);
            }
        
    }




























}
