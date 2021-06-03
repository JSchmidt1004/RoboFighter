using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    public Image background;
    public Image abilityImage;

    public Color cooldownColor;

    bool onCooldown = false;
    Color normalColor;
    float cooldownTime;
    float timer;

    public void Cooldown(float time)
    {
        normalColor = background.color;
        background.color = cooldownColor;
        cooldownTime = time;
        timer = 0;
        onCooldown = true;
    }

    private void Update()
    {
        if (onCooldown)
        {
            float timer = 0;
            timer += Time.deltaTime / cooldownTime;
            background.color = Color.Lerp(background.color, normalColor, timer);
            if (timer >= 1) onCooldown = false;
        }
    }
}
