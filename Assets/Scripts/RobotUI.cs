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

    public void SetName(string name)
    {
        nameText.name = name;
    }
    
    public void SetAnimator(string path)
    {
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/" + path);
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
