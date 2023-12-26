using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectSystem
{
    private List<CardSelectComponent> cardSelectComponentList = new List<CardSelectComponent>();

    public CardSelectSystem(GameEvent gameEvent)
    {
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    private void Initialize(CardSelectComponent cardSelectComponent)
    {
        cardSelectComponent.BasePosition = cardSelectComponent.transform.position;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < cardSelectComponentList.Count; i++)
        {
            CardSelectComponent cardSelectComponent = cardSelectComponentList[i];

            if (!cardSelectComponent.gameObject.activeSelf) continue;

            if (!IsSelectCard(cardSelectComponent))
            {
                cardSelectComponent.IsSelect = false;
                cardSelectComponent.transform.position = cardSelectComponent.BasePosition;
                continue;
            }

            if (!Input.GetMouseButtonDown(0)) continue;
            cardSelectComponent.IsSelect = true;
            cardSelectComponent.gameObject.SetActive(false);
            cardSelectComponent.transform.position = cardSelectComponent.BasePosition + cardSelectComponent.PositionOffset;
        }
    }

    private bool IsSelectCard(CardSelectComponent cardSelectComponent)
    {
        Vector2 position = Camera.main.WorldToScreenPoint(cardSelectComponent.transform.position) - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector2 size = cardSelectComponent.GetComponent<RectTransform>().sizeDelta * cardSelectComponent.transform.localScale / 2;
        float rad = cardSelectComponent.transform.rotation.z * Mathf.Deg2Rad;
        Vector2 vertex_left_up = new Vector2(
    (-size.x) * Mathf.Cos(rad) + (size.y * -Mathf.Sin(rad)),
    (-size.x) * Mathf.Sin(rad) + (size.y * Mathf.Cos(rad)));
        Vector2 vertex_right_up = new Vector2(
    (size.x) * Mathf.Cos(rad) + (size.y * -Mathf.Sin(rad)),
    (size.x) * Mathf.Sin(rad) + (size.y * Mathf.Cos(rad)));
        Vector2 vertex_left_down = new Vector2(
    (-size.x) * Mathf.Cos(rad) + (-size.y * -Mathf.Sin(rad)),
    (-size.x) * Mathf.Sin(rad) + (-size.y * Mathf.Cos(rad)));
        Vector2 vertex_right_down = new Vector2(
    (size.x) * Mathf.Cos(rad) + (-size.y * -Mathf.Sin(rad)),
    (size.x) * Mathf.Sin(rad) + (-size.y * Mathf.Cos(rad)));

        vertex_left_down += position;
        vertex_right_down += position;
        vertex_left_up += position;
        vertex_right_up += position;

        Vector2 left_down_to_left_up = vertex_left_up - vertex_left_down;
        Vector2 left_up_to_right_up = vertex_right_up - vertex_left_up;
        Vector2 right_up_to_right_down = vertex_right_down - vertex_right_up;
        Vector2 right_down_to_left_down = vertex_left_down - vertex_right_down;

        Vector2 mousePosition = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector2 left_down_to_mouse = mousePosition - vertex_left_down;
        Vector2 left_up_to_mouse = mousePosition - vertex_left_up;
        Vector2 right_up_to_mouse = mousePosition - vertex_right_up;
        Vector2 right_down_to_mouse = mousePosition - vertex_right_down;

        float crossCheck = 0.0f;
        crossCheck = left_down_to_left_up.x * left_down_to_mouse.y - left_down_to_left_up.y * left_down_to_mouse.x;
        if (crossCheck > 0) return false;
        crossCheck = left_up_to_right_up.x * left_up_to_mouse.y - left_up_to_right_up.y * left_up_to_mouse.x;
        if (crossCheck > 0) return false;
        crossCheck = right_up_to_right_down.x * right_up_to_mouse.y - right_up_to_right_down.y * right_up_to_mouse.x;
        if (crossCheck > 0) return false;
        crossCheck = right_down_to_left_down.x * right_down_to_mouse.y - right_down_to_left_down.y * right_down_to_mouse.x;
        if (crossCheck > 0) return false;

        return true;
    }

    private void AddComponentList(GameObject gameObject)
    {
        CardSelectComponent cardSelectComponent = gameObject.GetComponent<CardSelectComponent>();

        if (cardSelectComponent == null) return;

        cardSelectComponentList.Add(cardSelectComponent);

        Initialize(cardSelectComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        CardSelectComponent cardSelectComponent = gameObject.GetComponent<CardSelectComponent>();

        if (cardSelectComponent == null) return;

        cardSelectComponentList.Remove(cardSelectComponent);
    }
}
