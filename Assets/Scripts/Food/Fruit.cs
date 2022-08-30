using UnityEngine;

namespace Food
{
    public enum FruitSize
    {
        Whole = 0,
        Halves = 1,
        Slices = 2
    }
    
    public class Fruit : MonoBehaviour
    {
        public FruitSize fruitSize;

        [SerializeField] private GameObject _fruitHalves;
        [SerializeField] private GameObject _fruitSlices;

        private int _cuts = 0;
        private int _cutThreshold = 1;

        // Update is called once per frame
        void Update()
        {
            if (fruitSize == FruitSize.Slices)
            {
                return;
            }

            if (_cuts >= _cutThreshold)
            {
                if (fruitSize == FruitSize.Whole)
                {
                    CutFruit(_fruitHalves);
                }
                else if (fruitSize == FruitSize.Halves)
                {
                    CutFruit(_fruitSlices);
                }
            }
        }

        private void CutFruit(GameObject smallerFruit)
        {
            smallerFruit.SetActive(true);
            smallerFruit.transform.rotation = transform.rotation;
            smallerFruit.transform.position = transform.position;
            Destroy(gameObject);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Cutter"))
            {
                _cuts++;
            }
        }
    }
}
