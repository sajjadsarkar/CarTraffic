using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject Win;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Win");
    }
}
