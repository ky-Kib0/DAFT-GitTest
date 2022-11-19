using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParticleModeType {gudian,beisi,xuanlv }

public class ParticleMode : MonoBehaviour
{
    
    [System.Serializable]
    public struct ChangeModeStruct 
    {
        public float time;
        public ParticleModeType particleModeType;
        public bool Blur;
        public bool RGBDispersion;
    };
    public ChangeModeStruct[] timeToChange;
    public ParticleSystem[] gudianParticle;
    public ParticleSystem[] beisiParticle;
    public ParticleSystem[] xuanlvParticle;
    public Animator cameraAnimator;

    public AudioSource audio;

    [HideInInspector] public int iterator;
    

    private float timer = 0;

    
    void Start()
    {

    }
    void Update()
    {
        timer = audio.time % audio.clip.length ;

        for (int i = 0; i < timeToChange.Length; i++) 
        {
            if (timer >= timeToChange[i % timeToChange.Length].time && timer < timeToChange[(i + 1) % timeToChange.Length].time)
            {
                ChangeParticleModeWay(timeToChange[i % timeToChange.Length].particleModeType);
                iterator = i;
            }
        }

        Debug.Log(iterator);

    }

    private void ChangeParticleModeWay(ParticleModeType particleModeType) 
    {
        //Debug.Log(particleModeType);
        switch (particleModeType) 
        {
            case ParticleModeType.gudian:
                foreach(ParticleSystem ps in gudianParticle){ ps.gameObject.SetActive(true); }
                foreach (ParticleSystem ps in beisiParticle) { ps.gameObject.SetActive(false); }
                foreach (ParticleSystem ps in xuanlvParticle) { ps.gameObject.SetActive(false); }
                cameraAnimator.enabled = false;
                break;
            case ParticleModeType.beisi:
                foreach (ParticleSystem ps in gudianParticle) { ps.gameObject.SetActive(true); }
                foreach (ParticleSystem ps in beisiParticle) { ps.gameObject.SetActive(true); }
                foreach (ParticleSystem ps in xuanlvParticle) { ps.gameObject.SetActive(false); }
                cameraAnimator.enabled = false;
                break;
            case ParticleModeType.xuanlv:
                foreach (ParticleSystem ps in gudianParticle) { ps.gameObject.SetActive(true); }
                foreach (ParticleSystem ps in beisiParticle) { ps.gameObject.SetActive(true); }
                foreach (ParticleSystem ps in xuanlvParticle) { ps.gameObject.SetActive(true); }
                cameraAnimator.enabled = true;
                break;
        }
    }
}
