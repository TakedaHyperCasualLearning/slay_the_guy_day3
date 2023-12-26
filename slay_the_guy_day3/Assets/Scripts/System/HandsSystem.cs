using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsSystem
{
    private GameEvent gameEvent;
    private GameObject playerObject;
    [SerializeField] private List<HandsUIComponent> handsUIComponentList = new List<HandsUIComponent>();

    public HandsSystem(GameEvent gameEvent, GameObject player)
    {
        this.gameEvent = gameEvent;
        playerObject = player;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        TurnComponent turnComponent = playerObject.GetComponent<TurnComponent>();
        if (!turnComponent.IsMyTurn || turnComponent.TurnStatus != TurnState.Draw) return;

        for (int i = 0; i < handsUIComponentList.Count; i++)
        {
            Debug.Log("手札を引く");
            HandsUIComponent handsUIComponent = handsUIComponentList[i];
            if (!handsUIComponent.gameObject.activeSelf) continue;

            DrawCard(gameEvent.DrawCard?.Invoke(), handsUIComponent);
            turnComponent.TurnStatus = TurnState.Battle;
            Debug.Log(turnComponent.gameObject.name + "のバトルフェーズ");
        }
    }

    private void DrawCard(List<CardBaseComponent> cardList, HandsUIComponent handsUIComponent)
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            CardBaseComponent cardBaseComponent = cardList[i];
            handsUIComponent.HandsList[i].AttackPoint = cardBaseComponent.AttackPoint;
            handsUIComponent.HandsList[i].ManaPoint = cardBaseComponent.ManaPoint;
            handsUIComponent.HandsList[i].Title = cardBaseComponent.Title;
            handsUIComponent.HandsList[i].Description = cardBaseComponent.Description;
            handsUIComponent.HandsList[i].gameObject.SetActive(true);

            handsUIComponent.HandsUIList[i].ManaText.text = handsUIComponent.HandsList[i].ManaPoint.ToString();
            handsUIComponent.HandsUIList[i].TitleText.text = handsUIComponent.HandsList[i].Title;
            handsUIComponent.HandsUIList[i].DescriptionText.text = handsUIComponent.HandsList[i].Description;

            Debug.Log(handsUIComponent.HandsList[i].Title + "を手札に追加");
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        HandsUIComponent handsUIComponent = gameObject.GetComponent<HandsUIComponent>();

        if (handsUIComponent == null) return;

        handsUIComponentList.Add(handsUIComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        HandsUIComponent handsUIComponent = gameObject.GetComponent<HandsUIComponent>();

        if (handsUIComponent == null) return;

        handsUIComponentList.Remove(handsUIComponent);
    }
}
