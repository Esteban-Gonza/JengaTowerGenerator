using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLayer : MonoBehaviour{

    public GameObject[] blocksPrefabs;
    int spacingZ = -1;

    [SerializeField] bool isParalel;

    void Start(){

        SpawnBlocksLayer();
    }

    public void SpawnBlocksLayer(){

        APIData studentData = APIInformationManager.GetData();

        for(int i = 0; i < blocksPrefabs.Length; i++){

            GameObject instantiatedBlock = Instantiate(blocksPrefabs[Random.Range(0, blocksPrefabs.Length)]);

            instantiatedBlock.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + spacingZ);
            instantiatedBlock.transform.parent = transform;

            spacingZ++;
        }

        if(isParalel == false){

            transform.Rotate(new Vector3(0, 90, 0));
        }
    }
}