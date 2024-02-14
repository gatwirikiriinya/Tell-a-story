using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{

    public Transform[] roomPositions;
    public float transitionDuration = 10f;

    private Camera mainCamera;
    private int currentRoomIndex = 0;

    private void Start()
    {
        mainCamera = Camera.main;
        

    }

    public void TransitionToNextRoom()
    {

        if (currentRoomIndex < roomPositions.Length -1)
        {
            currentRoomIndex++;

            StartCoroutine(MoveCamera(roomPositions[currentRoomIndex]));

        }
        else { 
            currentRoomIndex = 0;
        StartCoroutine(MoveCamera(roomPositions[currentRoomIndex]));
    }
    }

    

    private IEnumerator MoveCamera(Transform targetTransform)
    {
        Vector3 startPosition = mainCamera.transform.position;
        Quaternion startRotation = mainCamera.transform.rotation;

        float elapsedTime = 0f;

        while(elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;

            mainCamera.transform.position = Vector3.Lerp(startPosition, targetTransform.position, t);
            mainCamera.transform.rotation = Quaternion.Slerp(startRotation, targetTransform.rotation, t);


            elapsedTime += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.position = targetTransform.position;
        mainCamera.transform.rotation = targetTransform.rotation;
    }


}
