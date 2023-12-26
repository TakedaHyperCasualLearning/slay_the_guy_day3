using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitPointUIComponent : MonoBehaviour
{
    [SerializeField] private TextMeshPro hitPointText;

    public TextMeshPro HitPointText { get => hitPointText; set => hitPointText = value; }
}
