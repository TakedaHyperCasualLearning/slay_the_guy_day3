using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class DamageUISystem
{
    private GameEvent gameEvent;
    private Movement movement;
    private List<DamageUIComponent> damageUIComponentList = new List<DamageUIComponent>();

    public DamageUISystem(GameEvent gameEvent, Movement movement)
    {
        this.gameEvent = gameEvent;
        this.movement = movement;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }


    public void OnUpdate()
    {
        for (int i = 0; i < damageUIComponentList.Count; i++)
        {
            DamageUIComponent damageUIComponent = damageUIComponentList[i];

            if (!damageUIComponent.gameObject.activeSelf) continue;

            DamageEffect(damageUIComponent).MoveNext();
        }
    }

    private IEnumerator DamageEffect(DamageUIComponent damageUI)
    {
        damageUI.Timer += Time.deltaTime;
        Vector3 tempPosition = damageUI.transform.position;
        tempPosition = movement.Parabola(damageUI.StartPosition, new Vector3(1, -5, 0), 165, damageUI.Timer);
        // tempPosition.y -= 3.0f * Time.deltaTime;
        damageUI.transform.position = tempPosition;
        float ratio = damageUI.Timer / damageUI.LimitTime;
        damageUI.GetComponent<TextMeshPro>().color = new Color(1.0f, ratio, ratio, 1.0f - ratio);
        if (damageUI.Timer >= damageUI.LimitTime)
        {
            damageUI.Timer = 0.0f;
            gameEvent.ReleaseObject?.Invoke(damageUI.gameObject);
            yield return null;
        }

        yield break;
    }

    private void AddComponentList(GameObject gameObject)
    {
        DamageUIComponent damageUIComponent = gameObject.GetComponent<DamageUIComponent>();

        if (damageUIComponent == null) return;

        damageUIComponentList.Add(damageUIComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        DamageUIComponent damageUIComponent = gameObject.GetComponent<DamageUIComponent>();

        if (damageUIComponent == null) return;

        damageUIComponentList.Remove(damageUIComponent);
    }
}
