using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class addIngredient : MonoBehaviour
{
    public Utils.ingredients ingredient;

    private void Start()
    {
        GameController.canWork += mayPlay;
    }

    public void mayPlay(bool may)
    {
        GetComponent<BoxCollider2D>().enabled = may;
    }

    public void OnMouseDown()
    {
        GameController.instance.AddIngredient(ingredient);
        //Debug.Log(ingredient);
    }
}
