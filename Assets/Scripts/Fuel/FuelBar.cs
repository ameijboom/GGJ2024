using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Fuel
{
    public class FuelBar : MonoBehaviour
    {
        [SerializeField] private float fuel = 100f;
        public Slider slider;

        private void Update()
        {
            fuel -= Time.deltaTime;
            slider.value = fuel;
            FuelEnd();
        }

        private void FuelEnd()
        {
            if (fuel <= slider.minValue)
            {
                Scene currentScene = SceneManager.GetActiveScene();
                int toLoad = (currentScene.buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
                SceneManager.LoadScene(toLoad);
            }
        }
    }
}
