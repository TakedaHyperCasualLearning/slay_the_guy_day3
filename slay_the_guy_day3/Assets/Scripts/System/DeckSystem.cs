using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSystem
{
    List<DeckComponent> deckComponentList = new List<DeckComponent>();

    public DeckSystem(GameEvent gameEvent)
    {
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    private void Initialize(DeckComponent deckComponent)
    {
        for (int i = 0; i < deckComponent.DeckCardCount; i++)
        {
            deckComponent.DeckCardList.Add(new CardBaseComponent());
            deckComponent.DeckCardList[i].Title = "Card" + i;
            deckComponent.DeckCardList[i].ManaPoint = Random.Range(1, 3);
            deckComponent.DeckCardList[i].AttackPoint = Random.Range(1, 3);
            deckComponent.DeckCardList[i].Description = deckComponent.DeckCardList[i].AttackPoint + "Damage";

            Debug.Log(deckComponent.DeckCardList[i].Title + "をデッキに追加");
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();

        if (deckComponent == null) return;

        deckComponentList.Add(deckComponent);

        Initialize(deckComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();

        if (deckComponent == null) return;

        deckComponentList.Remove(deckComponent);
    }
}
