using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashUIComponent : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI trashCardCountText;

    public TextMeshProUGUI TrashCardCountText { get => trashCardCountText; set => trashCardCountText = value; }
}
