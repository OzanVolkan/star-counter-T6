using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public static PlayerEffects instance;

    public GameObject spawnObject;
    public GameObject spawnPoint;
    public GameObject spawnParent;
    public GameObject winScreen;

    public List<GameObject> stars;

    public static int counter;
    private void Start()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Spawn();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Finish"))
        {
            InputController.isMoving = false;
            other.GetComponent<BoxCollider>().enabled = false;

            GetComponent<Rigidbody>().AddForce(Vector3.forward * 5f* counter, ForceMode.VelocityChange);
            winScreen.SetActive(true);
        }
    }

    public void Spawn()
    {
        GameObject cloned = Instantiate(spawnObject, spawnPoint.transform.position, Quaternion.Euler(new Vector3(-90,0,0)), spawnParent.transform);
        stars.Add(cloned);

        if (counter == 0)
        {
            stars[counter].GetComponent<SmoothDamp>().currentLeadTransform = this.transform;
        }
        else
        {
            stars[counter].GetComponent<SmoothDamp>().currentLeadTransform = stars[counter - 1].transform;
        }

        spawnPoint.transform.Translate(0f, 0f, 1.5f);
        counter++;
    }
}
