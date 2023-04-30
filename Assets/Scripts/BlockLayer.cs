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

        GameObject block = blocksPrefabs[0];
        if (studentData.Mastery == 1){

            block = blocksPrefabs[1];
        }else if (studentData.Mastery == 2){

            block = blocksPrefabs[2];
        }

        for (int i = 0; i < blocksPrefabs.Length; i++){

            GameObject instantiatedBlock = Instantiate(block);

            instantiatedBlock.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + spacingZ);
            instantiatedBlock.transform.parent = transform;

            spacingZ++;
        }

        if (isParalel == false){

            transform.Rotate(new Vector3(0, 90, 0));
        }
    }
}