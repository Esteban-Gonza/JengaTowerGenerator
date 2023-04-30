using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour{

    [SerializeField] GameObject[] blocksPrefabs;
    [SerializeField] int floors;
    int spacingY = 0;

    void Start(){
        
        for(int i = 0; i < floors; i++){
        
            if(i%2 == 0){

                GameObject layer = Instantiate(blocksPrefabs[0]);
                layer.transform.position = new Vector3(transform.position.x, transform.position.y + spacingY, transform.position.z);
                layer.transform.parent = transform;
            }else{

                GameObject layer = Instantiate(blocksPrefabs[1]);
                layer.transform.position = new Vector3(transform.position.x, transform.position.y + spacingY, transform.position.z);
                layer.transform.parent = transform;
            }

            spacingY++;
        }
    }
}