using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDamp : MonoBehaviour
{
    public Transform currentLeadTransform;

    private float velocity = 2.5f;
    private float smoothTime = .1f;

    public int number;

    private void Start()
    {
        number = PlayerEffects.counter;
    }
    public void SetLeadTransform(Transform leadTransform)
    {
        currentLeadTransform = leadTransform;
    }
    private void Update()
    {
        if (currentLeadTransform == null)
        {
            return;
        }

        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, currentLeadTransform.position.x, ref velocity, smoothTime), transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            PlayerEffects.instance.Spawn();
            Destroy(other.gameObject);
        }
    }
}
