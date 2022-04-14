using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform actualTransform;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float leftMovementLimit = -4f;
    [SerializeField] private float rightMovementLimit = 4f;
    [SerializeField] private float movementSensitivity = 175f;

    public static bool isMoving;
    void Update()
    {
        if (isMoving)
        {
            actualTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (!isMoving)
        {
            actualTransform.Translate(Vector3.zero);
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 tempPosition = playerTransform.position;
        tempPosition.x = Mathf.Clamp(tempPosition.x + (eventData.delta.x / movementSensitivity), leftMovementLimit, rightMovementLimit);
        playerTransform.position = tempPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isMoving = true;
    }
}
