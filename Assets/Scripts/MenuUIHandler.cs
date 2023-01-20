using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private InputField _inputName;
    [SerializeField] private Text _bestScoreText;

    private void Start()
    {
        _inputName.text = DataHandler.Instance.dataToSave.Name;
        _bestScoreText.text = DataHandler.Instance.bestScore;
    }

    public void PlayNewGame()
    {
        DataHandler.Instance.dataToSave.Name = _inputName.text;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
