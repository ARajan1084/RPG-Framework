using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public TMP_Text titleField;
    public TMP_Text imageField;
    public TMP_Text bodyField;
    private string title;
    private Image image;
    private string body;

    public string Title
    {
        get => title;
        set => title = value;
    }

    public Image Image
    {
        get => image;
        set => image = value;
    }

    public string Body
    {
        get => body;
        set => body = value;
    }
}
