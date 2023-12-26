using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStartSystem
{
    private GameObject playerObject;
    private List<TurnComponent> turnComponentList = new List<TurnComponent>();
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();

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
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];
            if (!turnComponent.gameObject.activeSelf) continue;

            if (!turnComponent.IsMyTurn || turnComponent.TurnStatus != TurnState.Start) continue;

            if (turnComponent.gameObject != playerObject)
            {
                turnComponent.TurnStatus = TurnState.Battle;
                Debug.Log(turnComponent.gameObject.name + "のバトルフェーズ");
                continue;
            }

            turnComponent.TurnStatus = TurnState.Draw;
            characterBaseComponent.Mana = characterBaseComponent.ManaMax;
            Debug.Log(turnComponent.gameObject.name + "のドローフェーズ");
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (turnComponent == null || characterBaseComponent == null) return;

        turnComponentList.Add(turnComponent);
        characterBaseComponentList.Add(characterBaseComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (turnComponent == null || characterBaseComponent == null) return;

        turnComponentList.Remove(turnComponent);
        characterBaseComponentList.Remove(characterBaseComponent);
    }
}
