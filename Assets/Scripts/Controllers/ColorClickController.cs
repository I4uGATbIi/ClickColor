using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ColorClickController : MonoBehaviour
{
    [SerializeField]
    private GameObject uiPrefab;

    [SerializeField]
    private Button saveBtn;

    [SerializeField]
    private Button addBtn;

    [SerializeField]
    private Button restoreBtn;

    [SerializeField]
    private TMP_Text timer;

    private List<ClickColorDataUI> clickColorDataUIs;

    private void Start()
    {
        LoadSavedData();
        saveBtn.onClick.AddListener(SaveData);
        addBtn.onClick.AddListener(AddData);
        restoreBtn.onClick.AddListener(RestoreData);
        timer.text = $"Color change in: {GameDataContainer.Instance.GameData.observableTime}";
    }

    private void LoadSavedData()
    {
        clickColorDataUIs = new List<ClickColorDataUI>();

        foreach (ClickColorData clickColorData in GameDataContainer.Instance.GeometryData.data)
        {
            AddData(clickColorData);
        }
    }

    public void SaveData()
    {
        GameDataContainer.Instance.GeometryData.SetDirty();
        GameDataContainer.Instance.GeometryData.data = CollectData();
        AssetDatabase.SaveAssets();
    }

    private List<ClickColorData> CollectData()
    {
        List<ClickColorData> collectedData = new List<ClickColorData>();

        foreach (ClickColorDataUI data in clickColorDataUIs)
        {
            collectedData.Add(data.GetClickColorData());
        }

        return collectedData;
    }

    private void AddData()
    {
        AddData(null);
    }

    public void AddData(ClickColorData data)
    {
        GameObject gameObject = Instantiate(uiPrefab, transform);
        ClickColorDataUI clickColorDataUI = gameObject.GetComponent<ClickColorDataUI>();
        clickColorDataUIs.Add(clickColorDataUI);
        if (data != null)
        {
            clickColorDataUI.SetAllData(data);
        }
    }

    public void RestoreData()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        LoadSavedData();
    }
}
