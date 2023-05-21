using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerKill : MonoBehaviour
{
    private HealthBase healthBase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            HealthBase h = other.gameObject.GetComponent<HealthBase>();

            if (h != null)
            {
                h.Kill();
            }
        }
    }
}
