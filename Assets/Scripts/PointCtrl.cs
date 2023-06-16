using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PointCtrl : MonoBehaviour
{
    public static PointCtrl instance;

    [SerializeField] TextMeshProUGUI points;
    [SerializeField] Slider timer;


    private void Awake()
    {
        instance = this;
    }


    public void SetValue(int value, bool isAdd)
    {
        points.text = value.ToString();

        if(isAdd)
        {
            points.color = new Color32(0,255,0,255);
            StartCoroutine(returnColor());
        }
        else
        {
            points.color = new Color32(255,0,0,255);
            StartCoroutine(returnColor());
        }
    }

    IEnumerator returnColor()
    {

        yield return new WaitForSeconds(1);
        points.color = new Color32(255,255,255,255);
    }


    public void setPoints(float timeValue)
    {
        timer.value = timeValue;
    }

}
