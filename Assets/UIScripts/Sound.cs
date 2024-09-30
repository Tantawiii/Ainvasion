using UnityEngine;
using UnityEngine.UIElements;

public class Sound : MonoBehaviour
{
    private UIDocument _document;
    private Button _button;
    public AudioSource pressSound;
    private void OnAwake()
    {
        _document = GetComponent<UIDocument>();
        _button = _document.rootVisualElement.Q<Button>("StartButton");

        _button.RegisterCallback<ClickEvent>(OnAwake, TrickleDown.TrickleDown);
    }

    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnAwake, TrickleDown.TrickleDown);
    }

    private void OnAwake(EventBase evt)
    {
        if (evt.target is Button)
        {
            pressSound.Play();
        }
        //else
        //{
        //    _button.UnregisterCallback<ClickEvent>(OnAwake, TrickleDown.TrickleDown);
        //}
    }
}
