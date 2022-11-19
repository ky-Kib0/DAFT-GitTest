using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    public Image[] CommonRotatingImages;
    public Image[] RandomRotatingImages;    
    public float RandomSpeedMax;
    public float RandomSpeedMin;
    public float RandomRotateSpeedMax;
    public float RandomRotateSpeedMin;
    public float Gaptime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RandomRotateFunction());       
        for (int i = 0; i < CommonRotatingImages.Length; i++)
        {
            CommonRotatingImages[i].transform.Rotate(Vector3.forward * Random.Range(RandomSpeedMin,RandomSpeedMax) * Mathf.Pow(-1, i));
        }
    }

    IEnumerator RandomRotateFunction()
    {
        for (int i = 0; i < RandomRotatingImages.Length; i++)
        {
            RandomRotatingImages[i].transform.Rotate(Vector3.forward * SpeedR());
        }
        yield return new WaitForSeconds(Gaptime);

    }

    private int RandomPower()
    {
        int a = 0;
        a = (int)(Mathf.Floor(Random.Range(1, 100)) % 2) * 2 - 1;
        return a;
    }

    private float SpeedR()
    {
        float b = Random.Range(RandomRotateSpeedMin, RandomRotateSpeedMax);
        //Debug.Log(b);
        return b;
    }

    
}
