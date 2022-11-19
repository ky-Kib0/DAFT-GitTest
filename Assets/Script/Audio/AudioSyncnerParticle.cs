using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncnerParticle : AudioSyncer
{
    private ParticleSystem ps;
    public float RestSpeed;
    public float BestSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();        
    }

    private IEnumerator ChangeToParticular(float _targetSpeed)
    {
        float curr = ps.startSpeed;
        //float curr = ps.velocityOverLifetime.speedModifierMultiplier;
        ParticleSystem.VelocityOverLifetimeModule velOverLifeMode = ps.velocityOverLifetime;
        float initial = curr;
        float timer = 0;

        

        while (curr != _targetSpeed) 
        {
            curr = Vector2.Lerp(new Vector2(initial, 0), new Vector2(_targetSpeed, 0), timer / timeToBeat).x;
            timer += Time.deltaTime;

            //velOverLifeMode.speedModifierMultiplier = curr;
            ps.startSpeed = curr;
            
            yield return null;
        }
        m_isBeat = false;
    }

    public override void OnBeat()
    {
        base.OnBeat();
        StopCoroutine("ChangeToParticular");
        StartCoroutine("ChangeToParticular", BestSpeed);
        //ps.startSize = 1;

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (m_isBeat) return;
        ps.startSpeed= Vector2.Lerp(new Vector2(ps.startSpeed, 0), new Vector2(RestSpeed, 0), restSmoothTime * Time.deltaTime).x;
        //ps.startSize = 0;
    }
}
