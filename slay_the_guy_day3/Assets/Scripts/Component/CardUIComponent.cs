using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardUIComponent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI manaText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    public TextMeshProUGUI TitleText { get => titleText; set => titleText = value; }
    public TextMeshProUGUI ManaText { get => manaText; set => manaText = value; }
    public TextMeshProUGUI DescriptionText { get => descriptionText; set => descriptionText = value; }
}
