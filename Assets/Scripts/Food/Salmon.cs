using System;
using System.Collections;
using System.Collections.Generic;
using Food;
using UnityEngine;

namespace Food
{
    public enum Cut
    {
        Whole = 0,
        Fillet = 1,
        Cut = 2
    }

    public class Salmon : CookableFood
    {
        public Cut cutType;

        [SerializeField] private GameObject _salmonFillet;
        [SerializeField] private GameObject _salmonCuts;

        private int _cuts = 0;
        private int _cutThreshold = 5;

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
            
            if (cutType == Cut.Cut)
            {
                return;
            }

            if (_cuts >= _cutThreshold)
            {
                if (cutType == Cut.Whole)
                {
                    CutSalmon(_salmonFillet);
                }
                else if (cutType == Cut.Fillet)
                {
                    CutSalmon(_salmonCuts);
                }
            }
        }

        private void CutSalmon(GameObject smallerSalmon)
        {
            smallerSalmon.SetActive(true);
            smallerSalmon.transform.rotation = transform.rotation;
            smallerSalmon.transform.position = transform.position;
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