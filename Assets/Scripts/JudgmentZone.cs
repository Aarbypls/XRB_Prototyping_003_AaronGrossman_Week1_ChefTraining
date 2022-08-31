using System;
using System.Collections;
using System.Collections.Generic;
using Food;
using UnityEditorInternal;
using UnityEngine;

public class JudgmentZone : MonoBehaviour
{
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private Material _successMaterial;
    [SerializeField] private GameObject _winUI;
    
    private bool _needsLambChop = false;
    private bool _needsSalmonWhole = false;
    private bool _needsSalmonFillet = false;
    private int _salmonCutsNeeded = 0;
    private bool _needsWholeMelon = false;
    private int _melonHalvesNeeded = 0;
    private int _melonSlicesNeeded = 0;
    private int _peachesNeeded = 0;
    private int _peachHalvesNeeded = 0;
    private int _peachSlicesNeeded = 0;
    private bool _needsCanSoda = false;
    private bool _needsBottleSoda = false;
    private bool _needsCarafeSake = false;

    private int _salmonCutsCount = 0;
    private int _melonHalvesCount = 0;
    private int _melonSlicesCount = 0;
    private int _peachesCount = 0;
    private int _peachHalvesCount = 0;
    private int _peachSlicesCount = 0;

    private bool _salmonWinCondition = false;
    private bool _lambChopWinCondition = false;
    private bool _melonWinCondition = false;
    private bool _peachWinCondition = false;
    private bool _beverageWinCondition = false;
    
    private bool _won = false;
    
    public void SetWinConditions()
    {
        SetProteinWinConditions();
        SetMelonWinConditions();
        SetPeachWinConditions();
        SetBeverageWinConditions();
    }

    private void SetBeverageWinConditions()
    {
        switch (_menuManager.beverageChoice)
        {
            case (MenuManager.BeverageChoice.CanSoda):
                _needsCanSoda = true;
                break;
            case (MenuManager.BeverageChoice.BottleSoda):
                _needsBottleSoda = true;
                break;
            case (MenuManager.BeverageChoice.Sake):
                _needsCarafeSake = true;
                break;
        }
    }

    private void SetPeachWinConditions()
    {
        switch (_menuManager.peachChoice)
        {
            case (MenuManager.PeachChoice.OneWhole):
                _peachesNeeded = 1;
                break;
            case (MenuManager.PeachChoice.TwoWhole):
                _peachesNeeded = 2;
                break;
            case (MenuManager.PeachChoice.ThreeWhole):
                _peachesNeeded = 3;
                break;
            case (MenuManager.PeachChoice.OneHalf):
                _peachHalvesNeeded = 1;
                break;
            case (MenuManager.PeachChoice.TwoHalves):
                _peachHalvesNeeded = 2;
                break;
            case (MenuManager.PeachChoice.ThreeHalves):
                _peachHalvesNeeded = 3;
                break;
            case (MenuManager.PeachChoice.FourHalves):
                _peachHalvesNeeded = 4;
                break;
            case (MenuManager.PeachChoice.TwoSlices):
                _peachSlicesNeeded = 2;
                break;
            case (MenuManager.PeachChoice.FourSlices):
                _peachSlicesNeeded = 4;
                break;
            case (MenuManager.PeachChoice.SixSlices):
                _peachSlicesNeeded = 6;
                break;
            case (MenuManager.PeachChoice.EightSlices):
                _peachSlicesNeeded = 8;
                break;
        }
    }

    private void SetMelonWinConditions()
    {
        switch (_menuManager.melonChoice)
        {
            case (MenuManager.MelonChoice.Whole):
                _needsWholeMelon = true;
                break;
            case (MenuManager.MelonChoice.OneHalf):
                _melonHalvesNeeded = 1;
                break;
            case (MenuManager.MelonChoice.TwoHalves):
                _melonHalvesNeeded = 2;
                break;
            case (MenuManager.MelonChoice.OneSlice):
                _melonSlicesNeeded = 1;
                break;
            case (MenuManager.MelonChoice.TwoSlices):
                _melonSlicesNeeded = 2;
                break;
            case (MenuManager.MelonChoice.ThreeSlices):
                _melonSlicesNeeded = 3;
                break;
            case (MenuManager.MelonChoice.FourSlices):
                _melonSlicesNeeded = 4;
                break;
        }
    }

    private void SetProteinWinConditions()
    {
        _needsLambChop = _menuManager.lambChopOnMenu;

        if (!_needsLambChop)
        {
            _lambChopWinCondition = true;
        }
        
        _needsSalmonWhole = (_menuManager.salmonChoice == MenuManager.SalmonChoice.WholeCooked);
        _needsSalmonFillet = (_menuManager.salmonChoice == MenuManager.SalmonChoice.FilletCooked);

        switch (_menuManager.salmonChoice)
        {
            case (MenuManager.SalmonChoice.OneCutCooked):
                _salmonCutsNeeded = 1;
                break;
            case (MenuManager.SalmonChoice.TwoCutsCooked):
                _salmonCutsNeeded = 2;
                break;
            case (MenuManager.SalmonChoice.ThreeCutsCooked):
                _salmonCutsNeeded = 3;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_won)
        {
            return;
        }
        
        if (other.gameObject.TryGetComponent(out Salmon salmon))
        {
            if (salmon)
            {
                if (salmon.cutType == Cut.Whole && salmon.cooked && _needsSalmonWhole)
                {
                    _salmonWinCondition = true;
                }
                else if (salmon.cutType == Cut.Fillet && salmon.cooked && _needsSalmonFillet)
                {
                    _salmonWinCondition = true;
                }
                else if (salmon.cutType == Cut.Cut && salmon.cooked)
                {
                    _salmonCutsCount++;

                    if (_salmonCutsCount == _salmonCutsNeeded)
                    {
                        _salmonWinCondition = true;
                    }
                }
            }
        }
        else if (other.gameObject.TryGetComponent(out CookableFood cookableFood))
        {
            // Doesn't have a Salmon script and is cookable = is a Lamb Chop
            if (cookableFood && cookableFood.cooked && _needsLambChop)
            {
                _lambChopWinCondition = true;
            }
        }
        else if (other.gameObject.TryGetComponent(out Fruit fruit))
        {
            if (fruit)
            {
                if (fruit.fruitType == FruitType.Melon)
                {
                    if (fruit.fruitSize == FruitSize.Whole && _needsWholeMelon)
                    {
                        _melonWinCondition = true;
                    }
                    else if (fruit.fruitSize == FruitSize.Halves)
                    {
                        _melonHalvesCount++;

                        if (_melonHalvesCount == _melonHalvesNeeded)
                        {
                            _melonWinCondition = true;
                        }
                    }
                    else if (fruit.fruitSize == FruitSize.Slices)
                    {
                        _melonSlicesCount++;

                        if (_melonSlicesCount == _melonSlicesNeeded)
                        {
                            _melonWinCondition = true;
                        }
                    }
                }
                else if (fruit.fruitType == FruitType.Peach)
                {
                    if (fruit.fruitSize == FruitSize.Whole)
                    {
                        _peachesCount++;

                        if (_peachesCount == _peachesNeeded)
                        {
                            _peachWinCondition = true;
                        }
                    }
                    else if (fruit.fruitSize == FruitSize.Halves)
                    {
                        _peachHalvesCount++;

                        if (_peachHalvesCount == _peachHalvesNeeded)
                        {
                            _peachWinCondition = true;
                        }
                    }
                    else if (fruit.fruitSize == FruitSize.Slices)
                    {
                        _peachSlicesCount++;

                        if (_peachSlicesCount == _peachSlicesNeeded)
                        {
                            _peachWinCondition = true;
                        }                    
                    }
                }
            }
        }
        else if (other.gameObject.TryGetComponent(out Beverage beverage))
        {
            if (beverage)
            {
                if (beverage.beverageType == BeverageType.CanSoda && _needsCanSoda)
                {
                    _beverageWinCondition = true;
                }
                else if (beverage.beverageType == BeverageType.BottleSoda && _needsBottleSoda)
                {
                    _beverageWinCondition = true;
                }
                else if (beverage.beverageType == BeverageType.Sake && _needsCarafeSake)
                {
                    _beverageWinCondition = true;
                }
            }
        }
    }

    private void Update()
    {
        if (_won)
        {
            return;
        }

        if (_lambChopWinCondition && _salmonWinCondition && _melonWinCondition && _peachWinCondition && _beverageWinCondition)
        {
            OnWin();
        }
    }

    private void OnWin()
    {
        gameObject.GetComponent<Renderer>().material = _successMaterial;
        _winUI.SetActive(true);
        _won = true;
    }
}
