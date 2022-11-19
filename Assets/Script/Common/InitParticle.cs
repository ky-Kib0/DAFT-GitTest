using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitParticle : MonoBehaviour
{

    private void Update()
    {
        for (int i = 0; i < GetComponentsInChildren<ParticleSystem>().Length; i++)
        {
            float a = RandomBeatScale();
            GetComponentsInChildren<ParticleSystem>()[i].GetComponent<AudioSyncScale>().beatScale.y = a;
            /*Upward.GetComponent<AudioSyncScale>().beatScale.y = RandomBeatScale();
            Downward[i].GetComponent<AudioSyncScale>().beatScale.y = RandomBeatScale();*/
        }
    }

    private float RandomBeatScale()
    {
        return Random.Range(0.3f, 2f);
    }
}
