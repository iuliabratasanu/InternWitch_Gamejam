using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite testSprite, testSprite1, testSprite2;

    private int beautyLevel = 0;
    private int ageBracket = 0;
    private int evolutionStep = 0;

    int progress = 0;
    public Slider slider;

    private int desiredBeautyLevel = 0;
    private int desiredAgeBracket = 0;
    private int desiredEvolutionStep = 0;

    public void updateXpProgress()
    {
        progress++;
        slider.value = progress;
    }

    public void updateBeauty(int beautyLevel)
    {
        this.beautyLevel = this.beautyLevel + beautyLevel;
    }
    public void updateAge(int ageBracket)
    {
        this.ageBracket = this.ageBracket + ageBracket;
    }
    public void updateEvolution(int evolutionStep)
    {
        this.evolutionStep = this.evolutionStep + evolutionStep;
    }

    public void changeSprite(Sprite sprite)
    {
        if (spriteRenderer != null && sprite != null)
        {
            spriteRenderer.sprite = sprite;
            checkEffect();
        }
        else
        {
            Debug.LogWarning("Failed to load sprite");
        }
    }

    public void checkEffect()
    {
        if(desiredAgeBracket == ageBracket &&
            desiredEvolutionStep == evolutionStep &&
            desiredBeautyLevel == desiredAgeBracket)
        {
            updateXpProgress();
        }
    }

    public void updateLooks()
    {
        if (beautyLevel == 0)
        {
            changeSprite(testSprite);
        }
        else if (beautyLevel == 1)
        {
            changeSprite(testSprite1);
        }
        else if (beautyLevel == 2)
        {
            changeSprite(testSprite2);
        }

        if (ageBracket == 0)
        {
            changeSprite(testSprite);
        }
        else if (ageBracket == 1)
        {
            changeSprite(testSprite1);
        }
        else if (ageBracket == 2)
        {
            changeSprite(testSprite2);
        }

        if (evolutionStep == 0)
        {
            changeSprite(testSprite);
        }
        else if (evolutionStep == 1)
        {
            changeSprite(testSprite1);
        }
        else if (evolutionStep == 2)
        {
            changeSprite(testSprite2);
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    }
}
