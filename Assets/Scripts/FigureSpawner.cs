using Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class FigureSpawner : MonoBehaviour
{
    public event Action<GeometryObjectController> SpawnStateChange;

    private GeometryObjectController controller;

    private void Start()
    {
        Observable.EveryUpdate().Where(_ => (Input.GetMouseButton(0) || Input.touchCount > 0) && controller == null).Subscribe(_ => OnMouseClick());
    }

    private void OnMouseClick()
    {
        string objectName = PrefabsLoader.GetRandomPrefabName();
        GameObject gO = Instantiate(Resources.Load<GameObject>($"{BaseDefinitions.PrefabFolder}/{objectName}"), Vector3.zero, Quaternion.identity);
        gO.name = objectName;
        controller = gO.GetComponent<GeometryObjectController>();

        SpawnStateChange(controller);
    }
}
