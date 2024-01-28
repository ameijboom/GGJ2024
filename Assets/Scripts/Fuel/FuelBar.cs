using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Fuel
{
    public class FuelBar : MonoBehaviour
    {
        [SerializeField] private float fuel = 100f;
        public Slider slider;
        public Image image;
    
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
                SceneManager.LoadScene(0);
            }
        }
    }
}
