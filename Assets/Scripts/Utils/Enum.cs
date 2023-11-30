using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Test
{
    None
}


public static class Consts
{
    public const int MAX_NUMBER_PARTY = 4;

    public const int DELETE_ENEMY_TIME = 5;
    public const int REFRESH_MAP_TIME = 1;

    public static readonly int[] LEFT_UP = new int[] { -1, -1 };
    public static readonly int[] LEFT = new int[] { -1, 0 };
    public static readonly int[] LEFT_DOWN = new int[] { -1, 1 };
    public static readonly int[] RIGHT_UP = new int[] { 0, -1 };
    public static readonly int[] RIGHT = new int[] { 1, 0 };
    public static readonly int[] RIGHT_DOWN = new int[] { 0, 1 };
}
