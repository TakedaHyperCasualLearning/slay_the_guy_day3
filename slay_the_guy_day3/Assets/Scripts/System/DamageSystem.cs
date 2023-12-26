using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem
{
    private GameEvent gameEvent;
    private ObjectPool objectPool;
    private GameObject damageUIRoot;
    private List<DamageComponent> damageComponentList = new List<DamageComponent>();
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();

    public DamageSystem(GameEvent gameEvent, ObjectPool objectPool, GameObject damageUIRoot)
    {
        this.gameEvent = gameEvent;
        this.objectPool = objectPool;
        this.damageUIRoot = damageUIRoot;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < damageComponentList.Count; i++)
        {
            DamageComponent damageComponent = damageComponentList[i];
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];
            if (!damageComponent.gameObject.activeSelf) continue;

            damageComponent.DamagePoint -= characterBaseComponent.DefensePoint;
            if (damageComponent.DamagePoint <= 0)
            {
                damageComponent.DamagePoint = 0;
                characterBaseComponent.DefensePoint = 0;
                continue;
            }

            characterBaseComponent.HitPoint -= damageComponent.DamagePoint;
            GenerateUI(damageComponent);
            damageComponent.DamagePoint = 0;
            characterBaseComponent.DefensePoint = 0;

            if (characterBaseComponent.HitPoint > 0) continue;
            characterBaseComponent.HitPoint = 0;
        }
    }

    private void GenerateUI(DamageComponent damageComponent)
    {
        GameObject damageUI = objectPool.GetGameObject(damageComponent.DamageTextPrefab);
        Vector3 tempPosition = damageComponent.transform.position + damageComponent.UiPositionOffset;
        tempPosition.z = 0;
        damageUI.transform.SetParent(damageUIRoot.transform);
        damageUI.transform.position = tempPosition;
        DamageUIComponent damageUIComponent = damageUI.GetComponent<DamageUIComponent>();
        damageUIComponent.DamageText.text = damageComponent.DamagePoint.ToString();
        damageUIComponent.StartPosition = tempPosition;
        if (!objectPool.IsNewCreate) return;
        gameEvent.AddComponentList?.Invoke(damageUI);
        objectPool.IsNewCreate = false;
    }

    private void AddComponentList(GameObject gameObject)
    {
        DamageComponent damageComponent = gameObject.GetComponent<DamageComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (damageComponent == null || characterBaseComponent == null) return;

        damageComponentList.Add(damageComponent);
        characterBaseComponentList.Add(characterBaseComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        DamageComponent damageComponent = gameObject.GetComponent<DamageComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (damageComponent == null || characterBaseComponent == null) return;

        damageComponentList.Remove(damageComponent);
        characterBaseComponentList.Remove(characterBaseComponent);
    }
}
