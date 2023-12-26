using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointUISystem
{
    private List<HitPointUIComponent> hitPointUIComponentList = new List<HitPointUIComponent>();
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();

    public HitPointUISystem(GameEvent gameEvent)
    {
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    private void Initialize(HitPointUIComponent hitPointUIComponent, CharacterBaseComponent characterBaseComponent)
    {
        characterBaseComponent.HitPoint = characterBaseComponent.HitPointMax;
        hitPointUIComponent.HitPointText.text = characterBaseComponent.HitPoint.ToString() + " / " + characterBaseComponent.HitPointMax.ToString();
    }

    public void OnUpdate()
    {
        for (int i = 0; i < hitPointUIComponentList.Count; i++)
        {
            HitPointUIComponent hitPointUIComponent = hitPointUIComponentList[i];
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];

            if (!hitPointUIComponent.gameObject.activeSelf) continue;

            hitPointUIComponent.HitPointText.text = characterBaseComponent.HitPoint.ToString() + " / " + characterBaseComponent.HitPointMax.ToString();
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        HitPointUIComponent hitPointUIComponent = gameObject.GetComponent<HitPointUIComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (hitPointUIComponent == null || characterBaseComponent == null) return;

        hitPointUIComponentList.Add(hitPointUIComponent);
        characterBaseComponentList.Add(characterBaseComponent);

        Initialize(hitPointUIComponent, characterBaseComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        HitPointUIComponent hitPointUIComponent = gameObject.GetComponent<HitPointUIComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (hitPointUIComponent == null || characterBaseComponent == null) return;

        hitPointUIComponentList.Remove(hitPointUIComponent);
        characterBaseComponentList.Remove(characterBaseComponent);
    }
}
