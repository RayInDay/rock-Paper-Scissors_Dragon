using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DragonScript : MonoBehaviour, IDamageble,ISpriteChangeble
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image Item;
    [SerializeField] private Sprite[] itemSprites ;
    [SerializeField] private Sprite[] characterSprites ;
    [SerializeField]private SpriteRenderer characterRenderer;
    private int health;

    public UnityEvent<string> OnDie = new UnityEvent<string>();
    void Start()
    {
        characterRenderer=GetComponent<SpriteRenderer>();
        RestartDragonStats();
    }

  
    private void setVisualHealth()
    {
        healthSlider.value =health / 100f;
        healthText.text = health.ToString();
    }
    private void Die()
    {
        OnDie.Invoke("You Win!");
    }
    public void RestartDragonStats()
    {
        health = 100;
        setVisualHealth();
        ChangeCharacterSprite(0);

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

    public void ChangeItemSprite(int index)
    {
        Item.sprite = itemSprites[index];
    }

     public void ChangeCharacterSprite(int index)
    {
        characterRenderer.sprite = characterSprites[index];
    }
}
