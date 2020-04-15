using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GeometryObjectController : MonoBehaviour
{
    private GeometryObjectModel model;

    private Material material;

    private void Awake()
    {
        model = GetComponent<GeometryObjectModel>();
    }

    private void Start()
    {

    }

    public void Click()
    {
        model.clickCount += 1;
        CheckModelClicks();
    }

    private void CheckModelClicks()
    {
        List<ClickColorData> clickColorDatas = GameDataContainer.Instance.GeometryData.data;
        ClickColorData matchedData = clickColorDatas.Where(obj => obj.objectType == name && obj.minClicksCount <= model.clickCount && obj.maxClicksCount >= model.clickCount).FirstOrDefault();
        if (matchedData == null)
        {
            return;
        }
        ChangeColor(matchedData.color);
    }

    public void ChangeColor(Color color)
    {
        if (material == null)
        {
            material = GetComponent<Renderer>().material;
        }
        material.color = color;
    }

    public void ChangeToRandomColor()
    {
        ChangeColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }
}
