using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Recipe", menuName = "New Recipe")]
public class Recipe : ScriptableObject
{
    public string RecipeName;
    public Sprite RecipeArt;

    public List<Utils.ingredients> ingredients = new List<Utils.ingredients>(3);


}
