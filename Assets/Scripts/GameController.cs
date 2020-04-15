using System;
using UniRx;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private FigureSpawner figureSpawner;

    [SerializeField]
    private GameObject adminPanel;

    private CompositeDisposable disposables;

    private void Awake()
    {
        PrefabsLoader.Load();
        figureSpawner.SpawnStateChange += SpawnStateChange;
    }

    private void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButton(0) && !figureSpawner.enabled).Subscribe(_ => OnMouseClick());
    }

    private void SpawnStateChange(GeometryObjectController controller)
    {
        figureSpawner.gameObject.SetActive(false);
        figureSpawner.enabled = false;

        Observable.Timer(TimeSpan.FromSeconds(GameDataContainer.Instance.GameData.observableTime)).Repeat().Subscribe(_ => controller.ChangeToRandomColor());
        adminPanel.SetActive(true);
    }

    private void OnEnable()
    {
        disposables = new CompositeDisposable();
    }

    private void OnDisable()
    {
        if (disposables != null)
        {
            disposables.Dispose();
        }
    }

    private void OnMouseClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            GeometryObjectController controller = hit.transform.GetComponent<GeometryObjectController>();
            if (controller == null)
            {
                return;
            }
            controller.Click();
        }
    }
}
