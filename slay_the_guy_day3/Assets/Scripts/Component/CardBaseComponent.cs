using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBaseComponent : MonoBehaviour
{
    private string title;
    private int manaPoint;
    private string description;
    private int attackPoint;

    public string Title { get => title; set => title = value; }
    public int ManaPoint { get => manaPoint; set => manaPoint = value; }
    public string Description { get => description; set => description = value; }
    public int AttackPoint { get => attackPoint; set => attackPoint = value; }
}

