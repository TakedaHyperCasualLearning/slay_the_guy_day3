using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnComponent : MonoBehaviour
{
    private bool isMyTurn;
    private TurnState turnStatus;

    public bool IsMyTurn { get => isMyTurn; set => isMyTurn = value; }
    public TurnState TurnStatus { get => turnStatus; set => turnStatus = value; }
}
