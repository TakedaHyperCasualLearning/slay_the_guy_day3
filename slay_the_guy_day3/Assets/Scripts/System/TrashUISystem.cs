using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashUISystem
{
    private GameObject deckObject;
    private List<TrashUIComponent> trashUIComponentList = new List<TrashUIComponent>();

    public TrashUISystem(GameEvent gameEvent, GameObject deck)
    {
        deckObject = deck;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < trashUIComponentList.Count; i++)
        {
            TrashUIComponent trashUIComponent = trashUIComponentList[i];

            if (!trashUIComponent.gameObject.activeSelf) continue;

            DeckComponent deckComponent = deckObject.GetComponent<DeckComponent>();
            trashUIComponent.TrashCardCountText.text = (deckComponent.AfterCardList.Count - 5).ToString();
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        TrashUIComponent trashUIComponent = gameObject.GetComponent<TrashUIComponent>();

        if (trashUIComponent == null) return;

        trashUIComponentList.Add(trashUIComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        TrashUIComponent trashUIComponent = gameObject.GetComponent<TrashUIComponent>();

        if (trashUIComponent == null) return;

        trashUIComponentList.Remove(trashUIComponent);
    }
}
