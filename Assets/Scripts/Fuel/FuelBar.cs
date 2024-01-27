using UnityEngine;
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
        }
    }
}
