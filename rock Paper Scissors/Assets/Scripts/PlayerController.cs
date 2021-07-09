
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDamageble
{
 
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    private int health;

    public UnityEvent<string> OnDie = new UnityEvent<string>();

    private void Start()
    {
      
       
        RestartKnightStats();
    }
    private void setVisualHealth()
    {
        healthSlider.value = health / 100f;
        healthText.text = health.ToString();
    }
    public void RestartKnightStats()
    {
        health = 100;
        setVisualHealth();


    }
    public void Die()
    {
        OnDie.Invoke("You Lose!");
    }

    public void TakeDamage()
    {
        if (health - 10 == 0)
        {
            Die();
        }

        health -= 10;
        setVisualHealth();
    }


}
