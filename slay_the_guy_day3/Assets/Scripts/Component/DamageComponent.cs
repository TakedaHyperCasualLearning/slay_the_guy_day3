using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] private GameObject damageTextPrefab;
    private int damagePoint;
    [SerializeField] private Vector3 uiPositionOffset;

    public GameObject DamageTextPrefab { get => damageTextPrefab; set => damageTextPrefab = value; }
    public int DamagePoint { get => damagePoint; set => damagePoint = value; }
    public Vector3 UiPositionOffset { get => uiPositionOffset; set => uiPositionOffset = value; }
}
