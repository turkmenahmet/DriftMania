using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Finish");
            TimerManager.Instance.StopCoroutine("StopWatch");
            CarController.Instance.Freeze();
        }
    }
}
