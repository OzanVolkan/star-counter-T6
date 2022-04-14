using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Text scoreText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        scoreText.text = PlayerEffects.counter.ToString() + "x";
    }
}
