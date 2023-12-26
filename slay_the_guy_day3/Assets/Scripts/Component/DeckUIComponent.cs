using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckUIComponent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deckCardCountText;

    public TextMeshProUGUI DeckCardCountText { get => deckCardCountText; set => deckCardCountText = value; }
}
