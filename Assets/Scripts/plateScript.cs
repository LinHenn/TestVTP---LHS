using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateScript : MonoBehaviour
{
    public static plateScript instance;

    [SerializeField] private Sprite[] ingredients = new Sprite[5];

    [SerializeField] private SpriteRenderer[] plateIngredients = new SpriteRenderer[4];

    int index = 0;

    private void Awake()
    {
        instance = this;
    }



    public void addIngredient(Utils.ingredients ingredient)
    {
        switch(ingredient)
        {
            case Utils.ingredients.Dragon_Steak:
                plateIngredients[index].sprite = ingredients[0];
                break;
            case Utils.ingredients.Spider_Legs:
                plateIngredients[index].sprite = ingredients[1];
                break;
            case Utils.ingredients.Troll_Finger:
                plateIngredients[index].sprite = ingredients[2];
                break;
            case Utils.ingredients.Unicorn_Horn:
                plateIngredients[index].sprite = ingredients[3];
                break;
            case Utils.ingredients.Witch_Nose:
                plateIngredients[index].sprite = ingredients[4];
                break;
        }

        plateIngredients[index].enabled = true;
        index++;
        
    }

    public void resetPlate(bool isRight)
    {
        if(isRight)
        {
            plateIngredients[0].enabled = false;
            plateIngredients[1].enabled = false;
            plateIngredients[2].enabled = false;
            plateIngredients[3].sprite = GameController.instance.actualOrder.RecipeArt;
            plateIngredients[3].enabled = true;
        }

        StartCoroutine(waitReset());
    }

    IEnumerator waitReset()
    {

        yield return new WaitForSeconds(0.5f);
        index = 0;
        foreach (var ing in plateIngredients)
        {
            ing.enabled = false;
        }
    }


}
