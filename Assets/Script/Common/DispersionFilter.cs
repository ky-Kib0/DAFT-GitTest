using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispersionFilter : SimpleFilter
{
    [Range(0, 2)] public float _DispersionRange;
    [Range(0, 6)] public float _DispersionPower;

    protected override void OnUpdate()
    {
        _mat.SetFloat("_DispersionRange", _DispersionRange);
        _mat.SetFloat("_DispersionPower", _DispersionPower);
    }
}
