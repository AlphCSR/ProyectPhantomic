using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargePlayer3 : MonoBehaviour
{
    public Text text1;
    public Text cooldownText1;
    public Image ringHealthBar1;

    public Text text2;
    public Text cooldownText2;
    public Image ringHealthBar2;

    public float cooldown1, cooldown2, maxCooldown1, maxCooldown2;
    float lerpSpeed;

    public Speed ability1;
    public Blindness ability2;

    public void Start()
    {
        ability1 = FindObjectOfType<Speed>();
        ability2 = FindObjectOfType<Blindness>();
        maxCooldown1 = ability1.maxCooldown;
        maxCooldown2 = ability2.maxCooldown;
    }

    public void Update()
    {
        Ability1();
        //Ability2(); No activa ahora mesmo
    }

    public void Ability1()
    {
        //Si la abilidad se desactiva inicia el cooldown
        if (!ability1.active)
        {
            int second = ((int)cooldown1) / 100;
            cooldownText1.text = "" + second + "";
            if (cooldown1 <= 0) cooldown1 = maxCooldown1;

            ringHealthBar1.fillAmount = cooldown1 / maxCooldown1;

            cooldown1 -= 1;
        }
        //Si se puede activa de nuevo reset
        else
        {
            cooldown1 = 0;
        }
    }

    public void Ability2()
    {
        //Si la abilidad se desactiva inicia el cooldown
        if (!ability2.active)
        {
            int second = ((int)cooldown2) / 100;
            cooldownText2.text = "" + second + "";
            if (cooldown2 <= 0) cooldown2 = maxCooldown2;

            ringHealthBar2.fillAmount = cooldown2 / maxCooldown2;

            cooldown2 -= 1;
        }
        //Si se puede activa de nuevo reset
        else
        {
            cooldown2 = 0;
        }
    }
}
