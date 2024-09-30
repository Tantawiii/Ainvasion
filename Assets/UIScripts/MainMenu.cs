//using UnityEngine;
//using UnityEngine.UIElements;
//using UnityEngine.SceneManagement;

//public class MainMenu : MonoBehaviour
//{
//    private UIDocument _document;
//    private Button _button;

//    private void Awake()
//    {
//        _document = GetComponent<UIDocument>();
//        _button = _document.rootVisualElement.Q("StartButton") as Button;
//        _button.RegisterCallback<ClickEvent>(OnPlayGameClick);
//    }

//    private void OnPlayGameClick(ClickEvent evt)
//    {
//        SceneManager.LoadScene("Start");
//    }
//}

//using UnityEngine;
//using UnityEngine.UIElements;
//using UnityEngine.SceneManagement; // Required for Scene management

//public class StartButton : MonoBehaviour
//{
//    private UIDocument _document;
//    private Button _button;

//    private void Awake()
//    {
//        _document = GetComponent<UIDocument>();
//        _button = _document.rootVisualElement.Q("StartButton") as Button;
//        _button.RegisterCallback<ClickEvent>(LoadSceneByName);
//    }

//    // This function will be triggered when the button is clicked
//    public void LoadSceneByName(string Start)
//    {
//        SceneManager.LoadScene(Start); // Loads the scene with the specified�name
//����}
//}

using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; // Required for Scene management

public class StartButton : MonoBehaviour
{
    private UIDocument _document;
    private Button _button;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _button = _document.rootVisualElement.Q<Button>("StartButton"); // Cast directly to Button
        _button.RegisterCallback<ClickEvent>(evt => LoadSceneByName()); // Correct callback
    }

    // This function will be triggered when the button is clicked
    public void LoadSceneByName()
    {
        SceneManager.LoadScene("Start"); // Specify the scene name explicitly
    }
}