using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBlurFilter : SimpleFilter
{
    [Range(0, 0.6f)] public float _BlurRange;
    [Range(0, 6)] public float _BlurPower;
    protected override void OnUpdate()
    {
        _mat.SetFloat("_BlurRange", _BlurRange);
        _mat.SetFloat("_BlurPower", _BlurPower);        
    }
}
