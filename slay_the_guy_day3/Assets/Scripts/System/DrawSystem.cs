using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSystem
{
    private GameObject deckObject;
    private List<DrawComponent> drawComponentList = new List<DrawComponent>();
    private List<DeckComponent> deckComponentList = new List<DeckComponent>();

    public DrawSystem(GameEvent gameEvent)
    {
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
        gameEvent.DrawCard += DrawAction;
    }

    private List<CardBaseComponent> DrawAction()
    {
        List<CardBaseComponent> tempCardBaseComponentList = new List<CardBaseComponent>();
        for (int i = 0; i < deckComponentList.Count; i++)
        {
            DeckComponent deckComponent = deckComponentList[i];
            if (deckComponent.DeckCardList.Count <= 0)
            {
                int count = deckComponent.AfterCardList.Count;
                for (int j = 0; j < count; j++)
                {
                    CardBaseComponent cardBaseComponent = deckComponent.AfterCardList[0];
                    deckComponent.DeckCardList.Add(cardBaseComponent);
                    deckComponent.AfterCardList.RemoveAt(0);
                    Debug.Log(cardBaseComponent.Title + "をデッキに追加");
                }
            }

            for (int j = 0; j < drawComponentList[0].DrawCount; j++)
            {
                CardBaseComponent cardBaseComponent = deckComponent.DeckCardList[0];
                tempCardBaseComponentList.Add(cardBaseComponent);
                deckComponent.AfterCardList.Add(cardBaseComponent);
                deckComponent.DeckCardList.RemoveAt(0);
            }
        }
        return tempCardBaseComponentList;
    }

    private void AddComponentList(GameObject gameObject)
    {
        DrawComponent drawComponent = gameObject.GetComponent<DrawComponent>();
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();

        if (drawComponent == null || deckComponent == null) return;

        drawComponentList.Add(drawComponent);
        deckComponentList.Add(deckComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        DrawComponent drawComponent = gameObject.GetComponent<DrawComponent>();
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();

        if (drawComponent == null || deckComponent == null) return;

        drawComponentList.Remove(drawComponent);
        deckComponentList.Remove(deckComponent);
    }

}
