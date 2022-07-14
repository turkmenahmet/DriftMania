using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Player")
        {
            print(target.gameObject.tag);
            HitCameraShake.Instance.CameraShake(3.5f, .1f);
        }
    }
}
