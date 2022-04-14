using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateCount : MonoBehaviour
{
    public GameObject failScreen;

    TextMeshProUGUI gateText;
    public int gateCount;
    void Start()
    {
        gateText = GetComponentInChildren<TextMeshProUGUI>();
       // gateText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            if (PlayerEffects.counter > 0)
            {
                for (int i = other.gameObject.GetComponent<SmoothDamp>().number; i <= PlayerEffects.instance.stars.Count; i++)
                {
                    Increase();

                }
            }

        }
        else if (other.CompareTag("Player"))
        {
            if (PlayerEffects.counter == 0)
            {
                failScreen.SetActive(true);
                InputController.isMoving = false;
            }
        }
    }
    public void Increase()
    {
        gateCount++;
        gateText.text = gateCount.ToString();
        PlayerEffects.counter--;
        Destroy(PlayerEffects.instance.stars[PlayerEffects.instance.stars.Count - 1]);
        PlayerEffects.instance.stars.RemoveAt(PlayerEffects.instance.stars.Count - 1);
    }
}
