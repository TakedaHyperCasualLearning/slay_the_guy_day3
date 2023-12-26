using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] List<GameObject> cardList;
    [SerializeField] GameObject turnEndButton;
    [SerializeField] GameObject deck;
    [SerializeField] GameObject hands;
    [SerializeField] GameObject trash;
    [SerializeField] GameObject damageUIRoot;

    private GameEvent gameEvent;
    private ObjectPool objectPool;
    private Movement movement;

    private DamageSystem damageSystem;
    private HitPointUISystem hitPointUISystem;
    private ManaUISystem manaUISystem;
    private CardSelectSystem cardSelectSystem;
    private EnemyActionSystem enemyActionSystem;
    private TurnSystem turnSystem;
    private TurnEndButtonSystem turnEndButtonSystem;
    private TurnStartSystem turnStartSystem;
    private TurnEndSystem turnEndSystem;
    private DeckSystem deckSystem;
    private DrawSystem drawSystem;
    private DeckUISystem deckUISystem;
    private HandsSystem handsSystem;
    private TrashUISystem trashUISystem;
    private DamageUISystem damageUISystem;

    void Start()
    {
        gameEvent = new GameEvent();
        objectPool = new ObjectPool(gameEvent);
        movement = new Movement();

        damageSystem = new DamageSystem(gameEvent, objectPool, damageUIRoot);
        hitPointUISystem = new HitPointUISystem(gameEvent);
        manaUISystem = new ManaUISystem(gameEvent);
        cardSelectSystem = new CardSelectSystem(gameEvent, player, enemy);
        enemyActionSystem = new EnemyActionSystem(gameEvent, player);
        turnSystem = new TurnSystem(gameEvent, player);
        turnEndButtonSystem = new TurnEndButtonSystem(gameEvent, player);
        turnStartSystem = new TurnStartSystem(gameEvent, player);
        turnEndSystem = new TurnEndSystem(gameEvent);
        deckSystem = new DeckSystem(gameEvent);
        drawSystem = new DrawSystem(gameEvent);
        deckUISystem = new DeckUISystem(gameEvent);
        handsSystem = new HandsSystem(gameEvent, player);
        trashUISystem = new TrashUISystem(gameEvent, deck);
        damageUISystem = new DamageUISystem(gameEvent, movement);

        gameEvent.AddComponentList?.Invoke(player);
        gameEvent.AddComponentList?.Invoke(enemy);
        foreach (GameObject card in cardList)
        {
            gameEvent.AddComponentList?.Invoke(card);
        }
        gameEvent.AddComponentList?.Invoke(turnEndButton);
        gameEvent.AddComponentList?.Invoke(deck);
        gameEvent.AddComponentList?.Invoke(hands);
        gameEvent.AddComponentList?.Invoke(trash);
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
        handsSystem.OnUpdate();
        deckUISystem.OnUpdate();
        trashUISystem.OnUpdate();
        damageUISystem.OnUpdate();
    }
}
