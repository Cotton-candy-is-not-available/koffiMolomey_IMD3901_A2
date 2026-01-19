using UnityEngine;

public class SeedManager : MonoBehaviour
{
   //public Vector3 lastPosition;
  public GameObject plantManager;//make access on creation
  CropSpawner cropSpawner;

    //crop that we want to plant
    public GameObject cropPrefab;

     void Start()
    {
        plantManager = GameObject.FindGameObjectWithTag("PlantManager");
        cropSpawner = plantManager.GetComponent<CropSpawner>();
    }


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
