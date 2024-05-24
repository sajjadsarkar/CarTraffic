using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject Win;
    private void Start()
    {
        Win.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        Win.SetActive(true);
        Time.timeScale = 0; // Stop the game
    }
}
