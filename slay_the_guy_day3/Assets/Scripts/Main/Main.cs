using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    private GameEvent gameEvent;

    private DamageSystem damageSystem;
    private HitPointUISystem hitPointUISystem;
    private ManaUISystem manaUISystem;

    void Start()
    {
        gameEvent = new GameEvent();

        damageSystem = new DamageSystem(gameEvent);
        hitPointUISystem = new HitPointUISystem(gameEvent);
        manaUISystem = new ManaUISystem(gameEvent);

        gameEvent.AddComponentList?.Invoke(player);
        gameEvent.AddComponentList?.Invoke(enemy);
    }

    void Update()
    {
        damageSystem.OnUpdate();
        hitPointUISystem.OnUpdate();
        manaUISystem.OnUpdate();
    }
}
