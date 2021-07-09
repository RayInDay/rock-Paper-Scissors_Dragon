using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private Button[] buttonArray;
    [SerializeField] private PlayerController knight;
    [SerializeField] private GameObject resetScreen;
    [SerializeField] private DragonScript dragon;

    private UnityEvent OnResetAll = new UnityEvent();
    private int KnightChose;
    private int DragonChose;
    private void Start()
    {
        knight.OnDie.AddListener(startResetScreen);
        dragon.OnDie.AddListener(startResetScreen);
        OnResetAll.AddListener(knight.RestartKnightStats);
        OnResetAll.AddListener(dragon.RestartDragonStats);
    }

    private void compareValues(){
        DragonChose = Random.Range(-1, 2);
        if (KnightChose != DragonChose)
        {
            if (KnightChose < DragonChose)
            {
                if (KnightChose == -1 && DragonChose == 1)
                {
                    dealDamage(knight);
                    setItemSprite();
                    StartCoroutine(nextRound());
                    return;
                }
                dealDamage(dragon);
            }
            else
            {
                if (KnightChose == 1 && DragonChose == -1)
                {
                    dealDamage(dragon);
                    setItemSprite();
                    StartCoroutine(nextRound());
                    return;
                }
                dealDamage(knight);
            }
        }
       setItemSprite();
       StartCoroutine(nextRound()) ;
      
      

    }
    private void setItemSprite()
    {
        dragon.ChangeItemSprite(DragonChose+1);
    }
    private IEnumerator nextRound()
    {
        foreach (Button button in buttonArray)
        {
            button.interactable = false;
        }
        yield return new WaitForSeconds(1);
        dragon.ChangeItemSprite(3);

        foreach (Button button in buttonArray)
        {
            button.interactable = true;
        }
    }
    private void dealDamage(IDamageble target)
    {
        target.TakeDamage();
    }
    private void startResetScreen (string text)
    {
        foreach (Button button in buttonArray)
        {
            button.interactable= false;
        }
        RestartScript reset =   resetScreen.GetComponent<RestartScript>();
        reset.GetButton().onClick.AddListener(stopResetScreen);
        reset.TextforView = text;
        resetScreen.SetActive (true);
    }
    private void stopResetScreen()
    {
        foreach (Button button in buttonArray)
        {
            button.interactable = true;
        }
     
        resetScreen.SetActive(false);
        OnResetAll.Invoke();
    }
    public void ButtonAction(int buttonType)
    {
       
        KnightChose = buttonType;
        compareValues();
    }
    
}

