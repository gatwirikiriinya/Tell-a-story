using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{

    public Transform[] roomPositions;
    public float transitionDuration = 1f;

    private Camera mainCamera;
    private int currentRoomIndex = 0;

    private void Start()
    {
        mainCamera = Camera.main;
        

    }

    public void TransitionToNextRoom()
    {
        Debug.Log("Heyy I am getting clickedd");

        if (currentRoomIndex < roomPositions.Length -1)
        {
            currentRoomIndex++;

            StartCoroutine(MoveCamera(roomPositions[currentRoomIndex].position));
        }
        else
        { Debug.Log("No more rooms"); }
    }

    

    private IEnumerator MoveCamera(Vector3 targetPosition)
    {
        Vector3 startPosition = mainCamera.transform.position;

        float elapsedTime = 0f;

        while(elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;

            mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.position = targetPosition;
    }


}
