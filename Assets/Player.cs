using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.GameOver();
    }
}
