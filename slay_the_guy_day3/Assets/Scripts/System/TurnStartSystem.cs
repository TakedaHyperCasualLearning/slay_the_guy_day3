using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStartSystem
{
    private GameObject playerObject;
    private List<TurnComponent> turnComponentList = new List<TurnComponent>();

    public TurnStartSystem(GameEvent gameEvent, GameObject player)
    {
        this.playerObject = player;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < turnComponentList.Count; i++)
        {
            TurnComponent turnComponent = turnComponentList[i];
            if (!turnComponent.gameObject.activeSelf) continue;

            if (!turnComponent.IsMyTurn || turnComponent.TurnStatus != TurnState.Start) continue;

            if (turnComponent.gameObject != playerObject)
            {
                turnComponent.TurnStatus = TurnState.Battle;
                Debug.Log(turnComponent.gameObject.name + "のバトルフェーズ");
                continue;
            }

            turnComponent.TurnStatus = TurnState.Draw;
            Debug.Log(turnComponent.gameObject.name + "のドローフェーズ");
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
