using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class GarageUIController : MonoBehaviour
{
    private UIDocument _documentComponent;
    private VisualElement _root;

    void Start()
    {
        _documentComponent = GetComponent<UIDocument>();
        _root = _documentComponent.rootVisualElement;
    }
}