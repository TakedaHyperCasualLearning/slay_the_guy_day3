using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsUIComponent : MonoBehaviour
{
    [SerializeField] private List<CardBaseComponent> handsList;
    [SerializeField] private List<CardUIComponent> handsUIList;
    public List<CardBaseComponent> HandsList { get => handsList; set => handsList = value; }
    public List<CardUIComponent> HandsUIList { get => handsUIList; set => handsUIList = value; }
}
