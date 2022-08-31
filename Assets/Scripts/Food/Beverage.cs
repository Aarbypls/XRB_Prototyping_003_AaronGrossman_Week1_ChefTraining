using UnityEngine;

namespace Food
{
    public enum BeverageType
    {
        CanSoda = 0,
        BottleSoda = 1,
        Sake = 2
    }
    
    public class Beverage : MonoBehaviour
    {
        public BeverageType beverageType;
    }
}
