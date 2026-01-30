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
        if (collision.gameObject.tag == "Dirt")//if it collides with the dirt
            {

            //Debug.Log("Planted");

            cropSpawner.lastPosition = gameObject.transform.position ;//spawn plant here

            //Debug.Log("last positon of seed: "+ cropSpawner.lastPosition);

            cropSpawner.SpawCrop(cropPrefab);//spawn respective crop
            SoundManager.Instance.PlaySFX(SoundManager.Instance.createCropSFX);//play createCropSFX SFX

            //cropPrefab.GetComponent<Rigidbody>().isKinematic = true;//stop crop from bouncing on creation
            // destroy this seed
            Destroy(gameObject);
        }
   
    }




























}
