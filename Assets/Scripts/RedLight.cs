using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.totalFine += 100;
    }
}
