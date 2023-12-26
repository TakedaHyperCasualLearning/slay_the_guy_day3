using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEndSystem
{
    private GameEvent gameEvent;
    private List<TurnComponent> turnComponentList = new List<TurnComponent>();

    public TurnEndSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < turnComponentList.Count; i++)
        {
            TurnComponent turnComponent = turnComponentList[i];
            if (!turnComponent.gameObject.activeSelf) continue;

            if (!turnComponent.IsMyTurn || turnComponent.TurnStatus != TurnState.End) continue;

            Debug.Log(turnComponent.gameObject.name + "のターン終了");
            gameEvent.TurnEnd?.Invoke(turnComponent.gameObject);
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();

        if (turnComponent == null) return;

        turnComponentList.Add(turnComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();

        if (turnComponent == null) return;

        turnComponentList.Remove(turnComponent);
    }
}
