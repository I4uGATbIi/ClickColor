using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ClickColorDataUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown objectType;

    [SerializeField]
    private TMP_InputField minClick;

    [SerializeField]
    private TMP_InputField maxClick;

    [SerializeField]
    private TMP_InputField colorR;

    [SerializeField]
    private TMP_InputField colorG;

    [SerializeField]
    private TMP_InputField colorB;

    [SerializeField]
    private Button removeBtn;

    private void Start()
    {
        SetObjectTypeOptions(PrefabsLoader.GetAllNames());
        removeBtn.onClick.AddListener(RemoveElement);
    }

    private void RemoveElement()
    {
        Destroy(gameObject);
    }

    public void SetAllData(ClickColorData data)
    {
        SetObjectType(data.objectType);
        SetMinClick(data.minClicksCount);
        SetMaxClick(data.maxClicksCount);
        SetColorData(data.color);
    }

    public void SetObjectTypeOptions(List<string> options)
    {
        objectType.ClearOptions();
        objectType.AddOptions(options);
    }

    public void SetObjectType(string type)
    {
        TMP_Dropdown.OptionData option = objectType.options.Where(data => data.text == type).FirstOrDefault();
        objectType.value = objectType.options.IndexOf(option);
        objectType.RefreshShownValue();
    }

    public void SetMinClick(int click)
    {
        minClick.text = click.ToString();
    }

    public void SetMaxClick(int click)
    {
        maxClick.text = click.ToString();
    }

    public void SetColorData(Color color)
    {
        SetColorR(color.r);
        SetColorG(color.g);
        SetColorB(color.b);
    }

    public void SetColorR(float value)
    {
        colorR.text = value.ToString();
    }

    public void SetColorG(float value)
    {
        colorG.text = value.ToString();
    }

    public void SetColorB(float value)
    {
        colorB.text = value.ToString();
    }

    public ClickColorData GetClickColorData()
    {
        ClickColorData data = new ClickColorData
        {
            objectType = objectType.options.ElementAt(objectType.value).text,
            minClicksCount = int.Parse(minClick.text),
            maxClicksCount = int.Parse(maxClick.text),
            color = new Color(float.Parse(colorR.text), float.Parse(colorG.text), float.Parse(colorB.text))
        };
        return data;
    }
}
