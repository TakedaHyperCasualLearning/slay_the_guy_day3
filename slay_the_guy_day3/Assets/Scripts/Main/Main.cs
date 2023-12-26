using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] List<GameObject> cardList;

    private GameEvent gameEvent;

    private DamageSystem damageSystem;
    private HitPointUISystem hitPointUISystem;
    private ManaUISystem manaUISystem;
    private CardSelectSystem cardSelectSystem;


    void Start()
    {
        gameEvent = new GameEvent();

        damageSystem = new DamageSystem(gameEvent);
        hitPointUISystem = new HitPointUISystem(gameEvent);
        manaUISystem = new ManaUISystem(gameEvent);
        cardSelectSystem = new CardSelectSystem(gameEvent);

        gameEvent.AddComponentList?.Invoke(player);
        gameEvent.AddComponentList?.Invoke(enemy);
        foreach (GameObject card in cardList)
        {
            gameEvent.AddComponentList?.Invoke(card);
        }
    }

    void Update()
    {
        damageSystem.OnUpdate();
        hitPointUISystem.OnUpdate();
        manaUISystem.OnUpdate();
        cardSelectSystem.OnUpdate();
    }
}
