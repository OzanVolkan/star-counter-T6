using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private Vector3 range;

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, targetObject.transform.position + range, .1f);
    }
}
