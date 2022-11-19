using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float RotateSpeed;
    public GameObject Particle;

    private bool NeedBlur;
    private bool NeedRGBDispersion;

    private void Start()
    {
        NeedBlur = Particle.GetComponent<ParticleMode>().timeToChange[Particle.GetComponent<ParticleMode>().iterator].Blur;    
        NeedRGBDispersion = Particle.GetComponent<ParticleMode>().timeToChange[Particle.GetComponent<ParticleMode>().iterator].RGBDispersion;    
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        float X = -(Input.mousePosition.x - Screen.width / 2f) / (Screen.width / 2f);
        float Y = (Input.mousePosition.y - Screen.height / 2f) / (Screen.height / 2f);

        this.transform.localEulerAngles = new Vector3(Y * RotateSpeed, X * RotateSpeed + 270, 0);

        NeedBlur = Particle.GetComponent<ParticleMode>().timeToChange[Particle.GetComponent<ParticleMode>().iterator% Particle.GetComponent<ParticleMode>().timeToChange.Length].Blur;
        NeedRGBDispersion = Particle.GetComponent<ParticleMode>().timeToChange[Particle.GetComponent<ParticleMode>().iterator% Particle.GetComponent<ParticleMode>().timeToChange.Length].RGBDispersion;
        if (NeedBlur)
        {
            this.GetComponent<RadialBlurFilter>()._BlurRange = 0.05f;
        }
        else
        {
            this.GetComponent<RadialBlurFilter>()._BlurRange = 0;
        }
        if(NeedRGBDispersion)
        {
            this.GetComponent<DispersionFilter>()._DispersionRange = 0.985f;
        }
        else
        {
            this.GetComponent<DispersionFilter>()._DispersionRange = 1f;

        }
    }
}
