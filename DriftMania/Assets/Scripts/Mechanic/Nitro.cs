using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            CarController.Instance.NitroSpeedIncrease();
            GUIManagement.Instance.FillNitro(40);
        }
    }
}
