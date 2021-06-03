using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RobotUI : MonoBehaviour
{
    public TMP_Text nameText;
    public Slider health;
    public Slider stamina;
    public Animator animator;
    public CooldownUI abilityPrefab;

    List<CooldownUI> abilityUIs = new List<CooldownUI>();

    public void Setup(string name, string animatorPath)
    {
        nameText.name = name;
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/" + animatorPath);
    }

    public void UpdateHealth(float health)
    {
        this.health.value = 1 / health;
    }

    public void UpdateStamina(float stamina)
    {
        this.stamina.value = 1 / stamina;
    }


}
