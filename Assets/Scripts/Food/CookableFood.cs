using UnityEngine;

namespace Food
{
    public class CookableFood : MonoBehaviour
    {
        public bool cooked = false;

        [SerializeField] private float _timeCooking = 0f;
        [SerializeField] private float _cookTime = 30f;
        [SerializeField] private Material _cookedMaterial;
        [SerializeField] private bool _cooking = false;
    
        public void SetCooked()
        {
            cooked = true;
            gameObject.GetComponent<Renderer>().material = _cookedMaterial;
        }

        public void SetCooking()
        {
            _cooking = true;
        }

        public void SetNotCooking()
        {
            _cooking = false;
        }

        public virtual void Update()
        {
            if (!_cooking)
            {
                return;
            }

            _timeCooking += Time.deltaTime;
        
            if (_timeCooking >= _cookTime)
            {
                SetCooked();
                SetNotCooking();
                _timeCooking = 0f;
            }
        }
    }
}
