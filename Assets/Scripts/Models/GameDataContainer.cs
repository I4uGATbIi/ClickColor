using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataContainer : MonoBehaviour
{
    public static GameDataContainer Instance { get; private set; }

    [SerializeField]
    private GameData gameData;

    [SerializeField]
    private GeometryObjectData geometryData;

    public GameData GameData => gameData;
    public GeometryObjectData GeometryData => geometryData;

    private void Awake()
    {
        Instance = this;
    }
}
