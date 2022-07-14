using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Player")
        {
            HitCameraShake.Instance.CameraShake(7f, .2f);
            Health.Instance.HealthDecrease();
        }
    }
}
