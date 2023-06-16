using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class addIngredient : MonoBehaviour //,IPointerClickHandler
{
    public Utils.ingredients ingredient;

    [SerializeField] SpriteRenderer around;

    private void Start()
    {
        GameController.canWork += mayPlay;
    }

    public void mayPlay(bool may)
    {
        GetComponent<BoxCollider2D>().enabled = may;

        if(!may) GameController.canWork -= mayPlay;
    }


    //I could use OnPointerClick (inheriting IPointerClickHandler) if it was on Canvas. But I decided to use as gameObject
    public void OnMouseDown()
    {
        GameController.instance.AddIngredient(ingredient);
        //Debug.Log(ingredient);
    }

    public void OnMouseEnter()
    {
        around.enabled = true;
    }

    private void OnMouseExit()
    {
        around.enabled = false;
    }
}
