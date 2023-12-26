using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] List<GameObject> cardList;
    [SerializeField] GameObject turnEndButton;

    private GameEvent gameEvent;

    private DamageSystem damageSystem;
    private HitPointUISystem hitPointUISystem;
    private ManaUISystem manaUISystem;
    private CardSelectSystem cardSelectSystem;
    private EnemyActionSystem enemyActionSystem;
    private TurnSystem turnSystem;
    private TurnEndButtonSystem turnEndButtonSystem;
    private TurnStartSystem turnStartSystem;
    private TurnEndSystem turnEndSystem;


    void Start()
    {
        gameEvent = new GameEvent();

        damageSystem = new DamageSystem(gameEvent);
        hitPointUISystem = new HitPointUISystem(gameEvent);
        manaUISystem = new ManaUISystem(gameEvent);
        cardSelectSystem = new CardSelectSystem(gameEvent);
        enemyActionSystem = new EnemyActionSystem(gameEvent, player);
        turnSystem = new TurnSystem(gameEvent, player);
        turnEndButtonSystem = new TurnEndButtonSystem(gameEvent, player);
        turnStartSystem = new TurnStartSystem(gameEvent, player);
        turnEndSystem = new TurnEndSystem(gameEvent);

        gameEvent.AddComponentList?.Invoke(player);
        gameEvent.AddComponentList?.Invoke(enemy);
        foreach (GameObject card in cardList)
        {
            gameEvent.AddComponentList?.Invoke(card);
        }
        gameEvent.AddComponentList?.Invoke(turnEndButton);
    }

    void Update()
    {
        damageSystem.OnUpdate();
        hitPointUISystem.OnUpdate();
        manaUISystem.OnUpdate();
        cardSelectSystem.OnUpdate();
        enemyActionSystem.OnUpdate();
        turnStartSystem.OnUpdate();
        turnEndSystem.OnUpdate();
    }
}
