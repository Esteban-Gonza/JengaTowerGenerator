using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Header("Follow variables")]
    [Range(0.1f, 2.0f)]
    [SerializeField] float smoothFactor = 0.1f;
    [SerializeField] Transform[] towerPosition;
    Transform currentTower;
    [SerializeField] int positionIndex = 0;

    Vector3 camOffset;

    [Header("Rotation variables")]
    [SerializeField] bool rotationActive = true;
    [SerializeField] bool lookAtTower = true;
    [SerializeField] float rotationSpeed = 5.0f;

    void Start(){

        currentTower = towerPosition[0];
        camOffset = transform.position - currentTower.position;
    }

    void FixedUpdate(){

        currentTower = towerPosition[positionIndex];

        // Focus camera on tower
        Vector3 newPosition = currentTower.position + camOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if (rotationActive){

            Quaternion cameraTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

            camOffset = cameraTurnAngle * camOffset;
        }

        if(lookAtTower || rotationActive){

            transform.LookAt(currentTower);
        }
    }

    public void ChangeTower(){

        positionIndex++;
        if(positionIndex == 3){

            positionIndex = 0;
        }
    }
}