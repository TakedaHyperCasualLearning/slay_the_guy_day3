using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageUIComponent : MonoBehaviour
{
    [SerializeField] private TextMeshPro damageText;
    private Vector3 startPosition;
    [SerializeField] float limitTime;
    private float timer;


    public TextMeshPro DamageText { get => damageText; set => damageText = value; }
    public Vector3 StartPosition { get => startPosition; set => startPosition = value; }
    public float LimitTime { get => limitTime; set => limitTime = value; }
    public float Timer { get => timer; set => timer = value; }
}
