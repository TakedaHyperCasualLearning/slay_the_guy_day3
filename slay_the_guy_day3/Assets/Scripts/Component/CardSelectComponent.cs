using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectComponent : MonoBehaviour
{
    private Vector3 basePosition;
    private Vector3 baseRotation;
    [SerializeField] Vector3 positionOffset;
    private bool isSelect;
    [SerializeField] private float useBaseHeight;
    private bool isCanUse;

    public Vector3 BasePosition { get => basePosition; set => basePosition = value; }
    public Vector3 BaseRotation { get => baseRotation; set => baseRotation = value; }
    public Vector3 PositionOffset { get => positionOffset; set => positionOffset = value; }
    public bool IsSelect { get => isSelect; set => isSelect = value; }
    public float UseBaseHeight { get => useBaseHeight; set => useBaseHeight = value; }
    public bool IsCanUse { get => isCanUse; set => isCanUse = value; }
}
