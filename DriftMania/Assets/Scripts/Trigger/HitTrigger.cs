using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Player")
        {
            CameraManagement.Instance.CameraShake(5f, .2f);
            Health.Instance.HealthDecrease();
        }
    }
}
