using System.Collections.Generic;
using Food;
using UnityEngine;

namespace Appliances
{
    public class Oven : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _foodInOven = new List<GameObject>();
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CookableFood food) && !_foodInOven.Contains(other.gameObject))
            {
                _foodInOven.Add(food.gameObject);

                if (!food.cooked)
                {
                    food.SetCooking();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CookableFood food) && _foodInOven.Contains(other.gameObject))
            {
                _foodInOven.Remove(other.gameObject);
                food.SetNotCooking();
            }
        }
    }
}
