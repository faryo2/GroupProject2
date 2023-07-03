using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincileTime : MonoBehaviour
{
    public GameObject Slider;
    private bool on_damage = false;
    private MeshRenderer meshRenderer;

    // Use this for initialization
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on_damage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time));
            meshRenderer.material.color = new Color(level, level, level, level);
        }
    }
    void OnTrigerEnter(Collider col)
    {
        if (!on_damage && col.gameObject.tag == "Enemy")
        {
            Slider.SendMessage("OnDamage", 10);
            OnDamageEffect();
        }
    }

    void OnDamageEffect()
    {
        on_damage = true;
        StartCoroutine("WaitForIt");
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1);

        on_damage = false;
        meshRenderer.material.color = Color.white;
    }
}
