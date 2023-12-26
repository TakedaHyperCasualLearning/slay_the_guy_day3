using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnState
{
    None,
    Start,
    Draw,
    Battle,
    End
};

public class TurnSystem
{
    private List<TurnComponent> turnComponentList = new List<TurnComponent>();

    public TurnSystem(GameEvent gameEvent)
    {
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
        gameEvent.TurnEnd += TurnEnd;
    }

    private void TurnEnd(GameObject gameObject)
    {
        for (int i = 0; i < turnComponentList.Count; i++)
        {
            TurnComponent turnComponent = turnComponentList[i];

            if (!turnComponent.gameObject.activeSelf) continue;

            if (turnComponent.gameObject == gameObject)
            {
                turnComponent.TurnStatus = TurnState.None;
                turnComponent.IsMyTurn = false;
                continue;
            }

            turnComponent.TurnStatus = TurnState.Start;
            turnComponent.IsMyTurn = true;
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
