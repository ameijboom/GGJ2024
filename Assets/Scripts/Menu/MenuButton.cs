using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private MyBox.SceneReference scene;
    public void SwitchScene() => scene.LoadScene();

    private void Awake() => GetComponent<Button>().onClick.AddListener(SwitchScene);
}
