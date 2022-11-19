using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSyncerColor : AudioSyncer
{
    public Color BestColor;
    public Color RestColor;      
    

    private IEnumerator ChangeToColor(Color _targetColor)
    {
        Color _curr = GetComponent<Image>().color;
        Color _initial = _curr;
        float _timer = 0;

        while (_curr != _targetColor) 
        {
            _curr = Color.Lerp(_initial, _targetColor, _timer / 
                timeToBeat);
            _timer += Time.deltaTime;

            GetComponent<Image>().color = _curr;

            yield return null;
        }
        m_isBeat = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (m_isBeat) return;
        GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, RestColor, restSmoothTime * Time.deltaTime);
    }

    public override void OnBeat()
    {
        base.OnBeat();
        
        StopCoroutine("ChangeToColor");
        StartCoroutine("ChangeToColor", BestColor);
    }

    


}
