using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageReceiver : MonoBehaviour
{
    public Slider slider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    private void TakeDamage(float damageAmount)
    {
        slider.value -= damageAmount;

        if (slider.value <= 0)
        {

        }
    }
}
