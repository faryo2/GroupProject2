using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleTime : MonoBehaviour
{
    public GameObject Slider;
    private bool onDamage = false;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (onDamage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time));
            meshRenderer.material.color = new Color(level, level, level, level);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!onDamage && col.gameObject.tag == "Enemy")
        {
            Slider.SendMessage("OnDamage", 10);
            OnDamageEffect();
        }
    }

    private void OnDamageEffect()
    {
        onDamage = true;
        StartCoroutine(WaitForInvincibleTime());
    }

    private IEnumerator WaitForInvincibleTime()
    {
        yield return new WaitForSeconds(1);

        onDamage = false;
        meshRenderer.material.color = Color.white;
    }
}
