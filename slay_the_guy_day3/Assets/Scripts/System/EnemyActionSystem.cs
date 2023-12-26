using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionSystem
{
    private GameObject playerObject;
    private List<TurnComponent> turnComponentList = new List<TurnComponent>();
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();

    public EnemyActionSystem(GameEvent gameEvent, GameObject player)
    {
        playerObject = player;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < characterBaseComponentList.Count; i++)
        {
            TurnComponent turnComponent = turnComponentList[i];
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];
            if (!characterBaseComponent.gameObject.activeSelf) continue;
            if (characterBaseComponent.gameObject == playerObject) continue;
            if (!turnComponent.IsMyTurn || turnComponent.TurnStatus != TurnState.Battle) continue;

            int random = Random.Range(0, 2);
            if (random == 0)
            {
                DamageComponent damageComponent = playerObject.GetComponent<DamageComponent>();
                damageComponent.DamagePoint = characterBaseComponent.AttackPoint;
            }
            else
            {
                characterBaseComponent.DefensePoint += 1;
            }

            turnComponent.TurnStatus = TurnState.End;
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
