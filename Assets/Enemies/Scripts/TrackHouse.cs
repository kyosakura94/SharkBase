using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackHouse : MonoBehaviour
{
    #region Singleton

    public static TrackHouse instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject target; //Select what object the player is
}
