using System.Collections;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;

    public float redLightDuration = 5.0f;
    public float yellowLightDuration = 2.0f;
    public float greenLightDuration = 5.0f;


    private void Start()
    {
        StartCoroutine(TrafficLightSequence());
    }

    private IEnumerator TrafficLightSequence()
    {
        while (true)
        {
            SetLightState(redLight, true);
            SetLightState(yellowLight, false);
            SetLightState(greenLight, false);
            yield return new WaitForSeconds(redLightDuration);

            SetLightState(redLight, false);
            SetLightState(yellowLight, false);
            SetLightState(greenLight, true);
            yield return new WaitForSeconds(greenLightDuration);

            SetLightState(redLight, false);
            SetLightState(yellowLight, true);
            SetLightState(greenLight, false);
            yield return new WaitForSeconds(yellowLightDuration);
        }
    }

    private void SetLightState(GameObject light , bool state)
    {
        light.SetActive(state);
    }
}
