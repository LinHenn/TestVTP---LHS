using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Order : MonoBehaviour
{
    public static Order instance;
    private Animator anim;

    [SerializeField] private TextMeshProUGUI orderName;
    [SerializeField] private Image orderImage;
    [SerializeField] private TextMeshProUGUI[] orderIngredients = new TextMeshProUGUI[3];

    public Recipe _recipe;



    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }



    public void setOrder()
    {

        Recipe order = GameController.instance.actualOrder;
        orderName.text = order.RecipeName;
        orderImage.sprite = order.RecipeArt;
        
        for(int i = 0; i < 3; i++)
        {
            orderIngredients[i].text = order.ingredients[i].ToString();
        }

        anim.SetTrigger("new");
    }

}
