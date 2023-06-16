using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{

    private Animator anim;

    [SerializeField] private TextMeshProUGUI point;
    [SerializeField] private TextMeshProUGUI highScore;



    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        GameController.canWork += setEnd;
    }


    public void setEnd(bool mayPlay)
    {
        //Debug.Log(mayPlay);
        if (mayPlay) return;

        point.text = $"Score: {GameController.instance.points}";
        highScore.text = $"High Score: {GameController.highScore}";

        anim.SetTrigger("end");

        GameController.canWork -= setEnd;
    }



}
