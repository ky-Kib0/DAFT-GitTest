using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotate : MonoBehaviour
{
    public float rotateSpeed = 1;
    private float timer = 0;
    void Update()
    {
        //timer = (timer + Time.deltaTime * rotateSpeed) % 360;
        transform.Rotate(new Vector3(-Time.deltaTime * rotateSpeed, 0, 0));
        /*foreach(ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
        {
            ParticleSystem.VelocityOverLifetimeModule volm = ps.velocityOverLifetime;
            Vector3 particleSpeed
            volm.xMultiplier
        }*/
    }
}
