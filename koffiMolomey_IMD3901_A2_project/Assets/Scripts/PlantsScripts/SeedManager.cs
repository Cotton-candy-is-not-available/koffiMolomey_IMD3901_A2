using UnityEngine;

public class SeedManager : MonoBehaviour
{
   //public Vector3 lastPosition;
  public CropSpawner cropSpawner;//make access on creation

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("collision");
            if (collision.gameObject.tag == "Dirt")
            {
            cropSpawner.lastPosition = gameObject.transform.position ;//spawn plant here

            Debug.Log("last positon of seed: "+ cropSpawner.lastPosition);

            cropSpawner.SpawCrop();
            // destroy this object
            Destroy(gameObject);
            }
        
    }




























}
