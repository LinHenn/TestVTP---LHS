using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    private List<Recipe> recipes;


    public delegate void mayWork(bool action);
    public static event mayWork canWork;


    [SerializeField]
    private List<Utils.ingredients> recipeIngredients;
    [SerializeField]
    private List<Utils.ingredients> myIngredients;

    public float timer { get; protected set; }
    public int points { get; protected set; }

    public Recipe actualOrder;

    private Animator orderAnim;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        orderAnim = Order.instance.gameObject.GetComponent<Animator>();
        timer = 20;
        PointCtrl.instance.setPoints((int)timer);

        
    }


    public void playGame()
    {

        newOrder();

        startTimer();

        canWork(true);

    }


    public void newOrder()
    {
        recipeIngredients.Clear();

        int i = Random.Range(0, recipes.Count);

        actualOrder = recipes[i];

        Order.instance.setOrder();
        
        foreach(var ing in recipes[i].ingredients)
        {
            recipeIngredients.Add(ing);
        }

        //Debug.Log(recipes[i].RecipeName);
    }


    //add ingredient on the burger
    public void AddIngredient(Utils.ingredients ingredient)
    {
        myIngredients.Add(ingredient);

        plateScript.instance.addIngredient(ingredient);

        if (myIngredients.Count == 3)
        {
            checkOrder();
            //plateScript.instance.resetPlate();
        }

    }

    public void checkOrder()
    {
        orderAnim.SetTrigger("finish");

        foreach (var ing in myIngredients)
        {
            for(int i = 0; i < recipeIngredients.Count; i++)
            {
                if(ing == recipeIngredients[i])
                {
                    recipeIngredients.Remove(ing);
                    break;
                }
            }
        }

        if (recipeIngredients.Count == 0)
        {
            points += 10;
            PointCtrl.instance.SetValue(points, true);
            plateScript.instance.resetPlate(true);
        }
        else
        {
            points -= 10;
            PointCtrl.instance.SetValue(points, false);
            plateScript.instance.resetPlate(false);
        }

        
        myIngredients.Clear();

        StartCoroutine(setNewOrder());
        
    }

    IEnumerator setNewOrder()
    {
        yield return new WaitForSeconds(0.5f);
        newOrder();

    }



    public void startTimer()
    {
        StartCoroutine(setTimer());
    }

    IEnumerator setTimer()
    {
        yield return new WaitForSeconds(1);
        timer--;
        PointCtrl.instance.setPoints((int)timer);

        if(timer > 0) StartCoroutine(setTimer());
        else
        {
            Debug.Log("Fim de jogo");
            canWork(false);
        }
    }


}
