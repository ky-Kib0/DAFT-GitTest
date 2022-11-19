using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCameraZoom : AudioSyncer
{
    public Animator animator;
    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnBeat()
    {
        base.OnBeat();
        animator.SetTrigger("Zoom");
    }
}