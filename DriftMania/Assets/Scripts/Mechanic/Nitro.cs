using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CarController.Instance.NitroSpeedIncrease();
            GUIManagement.Instance.FillNitro();
            CameraManagement.Instance.CameraShake(7f, 2f);
        }
    }
}
