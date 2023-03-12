using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBase : MonoBehaviour
{
    public MinionType MinionType;
}

public enum MinionType
{
    Red,
    Blue,
    Green
}