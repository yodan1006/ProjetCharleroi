using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaluletteMono : MonoBehaviour
{
    public float numberOne;
    public float numberTwo;
    public float addition;
    public float soustraction;
    public float multiplication;
    public float division;
    public float modulo;
    public float hypothenuse;

    private void OnValidate()
    {
        addition = numberOne + numberTwo;
        soustraction = numberOne - numberTwo;
        multiplication = numberOne * numberTwo;
        division = numberOne / numberTwo;
        modulo = numberOne % numberTwo;
        hypothenuse = Mathf.Sqrt(Mathf.Pow(numberOne,2)+Mathf.Pow(numberTwo,2));
    }
}
