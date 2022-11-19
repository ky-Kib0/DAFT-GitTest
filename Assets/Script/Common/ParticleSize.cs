using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSize : MonoBehaviour
{
    public float SizeControlValue = 0.9f;
    public float particleSize = 1;
    ParticleSystem ps;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (ps.startSpeed <= GetComponent<AudioSyncnerParticle>().BestSpeed * SizeControlValue)
        {
            ps.startSize = 0;
        }
        else 
        {
            ps.startSize = particleSize;
        }
    }
}
