using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChooseButton : MonoBehaviour
{
    public Image image;
    Sprite sprite;
    public string animName = "Pete/PeteController";

    private void Start()
    {
        sprite = image.sprite;
    }
}
