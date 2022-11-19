using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public float changeSpeed = 0.1f;
    public float sInHSV = 0.9f;
    public float vInHSV = 0.5f;
    public float intensity = 1.4f;
    public float intensityGudian = 3.9f;

    private float timer = 0;
    void Update()
    {
        float factor = Mathf.Pow(2, intensity);
        timer =  (timer+ Time.deltaTime* changeSpeed) -Mathf.Floor(timer + Time.deltaTime* changeSpeed);
        foreach (Image image in GetComponentsInChildren<Image>()) 
        {
            image.material.SetColor("_EmissionColor", Color.HSVToRGB(timer, sInHSV, vInHSV,true));
            image.material.SetColor("_Color", Color.HSVToRGB(timer, vInHSV, sInHSV,true)*factor);
        }
        float factorGudian = Mathf.Pow(2, intensityGudian);
        foreach (ParticleSystem ps in GetComponentsInChildren<ParticleSystem>()) 
        {
            ps.GetComponent<ParticleSystemRenderer>().material.SetColor("_EmissionColor", Color.HSVToRGB(timer, sInHSV, vInHSV, true)* factorGudian);

        }
    }
}
