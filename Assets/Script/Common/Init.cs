using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Init : MonoBehaviour
{
    public GameObject Upward;
    public GameObject Downward;

    private void Update()
    {
        for (int i = 0; i < Upward.GetComponentsInChildren<Image>().Length; i++)
        {
            float a = RandomBeatScale();
            Upward.GetComponentsInChildren<Image>()[i].GetComponent<AudioSyncScale>().beatScale.y = a;
            Downward.GetComponentsInChildren<Image>()[i].GetComponent<AudioSyncScale>().beatScale.y = a;
            /*Upward.GetComponent<AudioSyncScale>().beatScale.y = RandomBeatScale();
            Downward[i].GetComponent<AudioSyncScale>().beatScale.y = RandomBeatScale();*/
        }
    }

    private float RandomBeatScale()
    {
        return Random.Range(0.3f, 2f);
    }
}
