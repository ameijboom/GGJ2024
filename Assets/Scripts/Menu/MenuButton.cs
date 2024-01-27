using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    private MyBox.SceneReference scene;

    private void Awake() => GetComponent<Button>().onClick.AddListener(LoadScene);
    public void LoadScene() => scene.LoadScene();
}
