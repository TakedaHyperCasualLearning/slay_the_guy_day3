using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawComponent : MonoBehaviour
{
    [SerializeField] int drawCount;

    public int DrawCount { get => drawCount; set => drawCount = value; }
}
