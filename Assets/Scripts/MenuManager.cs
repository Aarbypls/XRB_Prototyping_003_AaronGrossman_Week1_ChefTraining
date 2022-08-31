using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lambChopText;
    [SerializeField] private TextMeshProUGUI _salmonText;
    [SerializeField] private TextMeshProUGUI _melonText;
    [SerializeField] private TextMeshProUGUI _peachText;
    [SerializeField] private TextMeshProUGUI _beverageText;
    [SerializeField] private JudgmentZone _judgmentZone;

    public bool lambChopOnMenu = false;
    public SalmonChoice salmonChoice;
    public MelonChoice melonChoice;
    public PeachChoice peachChoice;
    public BeverageChoice beverageChoice;
    
    public enum SalmonChoice
    {
        WholeCooked = 0,
        FilletCooked = 1,
        OneCutCooked = 2,
        TwoCutsCooked = 3,
        ThreeCutsCooked = 4
    }

    public enum MelonChoice
    {
        Whole = 0,
        OneHalf = 1,
        TwoHalves = 2,
        OneSlice = 3,
        TwoSlices = 4,
        ThreeSlices = 5,
        FourSlices = 6
    }

    public enum PeachChoice
    {
        OneWhole = 0,
        TwoWhole = 1,
        ThreeWhole = 2,
        OneHalf = 3,
        TwoHalves = 4,
        ThreeHalves = 5,
        FourHalves = 6,
        TwoSlices = 7,
        FourSlices = 8,
        SixSlices = 9,
        EightSlices = 10
    }

    public enum BeverageChoice
    {
        CanSoda = 0,
        BottleSoda = 1,
        Sake = 2
    }
    
    // Start is called before the first frame update
    void Start()
    {
        lambChopOnMenu = Random.value > 0.5f;
        salmonChoice = (SalmonChoice)Random.Range(0, 5);
        melonChoice = (MelonChoice)Random.Range(0, 7);
        peachChoice = (PeachChoice)Random.Range(0, 11);
        beverageChoice = (BeverageChoice)Random.Range(0, 3);
        
        SetLambOnMenu();
        SetSalmonOnMenu();
        SetMelonOnMenu();
        SetPeachOnMenu();
        SetBeverageOnMenu();

        _judgmentZone.SetWinConditions();
    }

    private void SetLambOnMenu()
    {
        if (lambChopOnMenu)
        {
            _lambChopText.SetText("1x Lamb Chop, Cooked");
        }
        else
        {
            _lambChopText.SetText("");
        }
    }

    private void SetSalmonOnMenu()
    {
        switch (salmonChoice)
        {
            case SalmonChoice.WholeCooked:
                _salmonText.SetText("1x Whole Salmon, Cooked");
                break;
            case SalmonChoice.FilletCooked:
                _salmonText.SetText("1x Fillet Salmon, Cooked");
                break;
            case SalmonChoice.OneCutCooked:
                _salmonText.SetText("1x Small Cut of Salmon, Cooked");
                break;
            case SalmonChoice.TwoCutsCooked:
                _salmonText.SetText("2x Small Cuts of Salmon, Cooked");
                break;
            case SalmonChoice.ThreeCutsCooked:
                _salmonText.SetText("3x Small Cuts of Salmon, Cooked");
                break;
        }
    }

    private void SetMelonOnMenu()
    {
        switch (melonChoice)
        {
            case MelonChoice.Whole:
                _melonText.SetText("1x Whole Melon");
                break;
            case MelonChoice.OneHalf:
                _melonText.SetText("1x Half Melon");
                break;
            case MelonChoice.TwoHalves:
                _melonText.SetText("2x Halves Melon");
                break;
            case MelonChoice.OneSlice:
                _melonText.SetText("1x Slice Melon");
                break;
            case MelonChoice.TwoSlices:
                _melonText.SetText("2x Slices Melon");
                break;
            case MelonChoice.ThreeSlices:
                _melonText.SetText("3x Slices Melon");
                break;
            case MelonChoice.FourSlices:
                _melonText.SetText("4x Slices Melon");
                break;
        }
    }

    private void SetPeachOnMenu()
    {
        switch (peachChoice)
        {
            case PeachChoice.OneWhole:
                _peachText.SetText("1x Whole Peach");
                break;
            case PeachChoice.TwoWhole:
                _peachText.SetText("2x Whole Peaches");
                break;
            case PeachChoice.ThreeWhole:
                _peachText.SetText("3x Whole Peaches");
                break;
            case PeachChoice.OneHalf:
                _peachText.SetText("1x Half Peach");
                break;
            case PeachChoice.TwoHalves:
                _peachText.SetText("2x Halves Peach");
                break;
            case PeachChoice.ThreeHalves:
                _peachText.SetText("3x Halves Peach");
                break;
            case PeachChoice.FourHalves:
                _peachText.SetText("4x Halves Peach");
                break;
            case PeachChoice.TwoSlices:
                _peachText.SetText("2x Slices Peach");
                break;
            case PeachChoice.FourSlices:
                _peachText.SetText("4x Slices Peach");
                break;
            case PeachChoice.SixSlices:
                _peachText.SetText("6x Slices Peach");
                break;
            case PeachChoice.EightSlices:
                _peachText.SetText("8x Slices Peach");
                break;
        }
    }
    
    private void SetBeverageOnMenu()
    {
        switch (beverageChoice)
        {
            case BeverageChoice.CanSoda:
                _beverageText.SetText("1x Can of Soda");
                break;
            case BeverageChoice.BottleSoda:
                _beverageText.SetText("1x Bottle of Soda");
                break;
            case BeverageChoice.Sake:
                _beverageText.SetText("1x Carafe of Sake");
                break;
        }
    }
}
