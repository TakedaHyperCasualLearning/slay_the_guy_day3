using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckComponent : MonoBehaviour
{
    [SerializeField] int deckCardCount;
    private List<CardBaseComponent> deckCardList = new List<CardBaseComponent>();
    private List<CardBaseComponent> afterCardList = new List<CardBaseComponent>();

    public int DeckCardCount { get => deckCardCount; set => deckCardCount = value; }
    public List<CardBaseComponent> DeckCardList { get => deckCardList; set => deckCardList = value; }
    public List<CardBaseComponent> AfterCardList { get => afterCardList; set => afterCardList = value; }
}
