using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{
    public int number1; /*sayı */        public Text numberText11, numberText22, resultText, numberText3, numberTextZero, number4;
    double result; //sonuc
    public string myNumber3 = string.Empty;
    public string myNumber2 = string.Empty;
    public string myNumber1 = string.Empty;
    public Text multiplyText; public Text interestText;
    public Text plentyText; public Text gatherTextt; public Text PercentText;
    public string processText;
    public string MyStr2Change;
    public bool isFirstNumber = true;
    public bool isTrueNumber = true;
    public bool isTreeNumber = false;
    public void Start()
    {
        SymbolText();
        isTreeNumber = false;
    }
    public void SymbolText()
    {
        multiplyText.enabled = false;
        plentyText.enabled = false;
        interestText.enabled = false;
        gatherTextt.enabled = false;
        PercentText.enabled = false;
        
    }
    public void Test(int number) //Sayı Girme
    {
        
        result = number;
        numberTextZero.enabled = false;
        numberText11.text = numberText11.text + number;
        myNumber2 = string.Concat(myNumber2, number);
        if (isFirstNumber )
        {
            myNumber1 = string.Concat(myNumber1, number);
        }
        if (isTreeNumber)
        {
            myNumber3 = string.Concat(myNumber3, number);
        }
    }
    public void Islem(int islemNumarasi)
    {
        isFirstNumber = false;
        isTreeNumber = false;
        
        myNumber2 = string.Empty;
        switch (islemNumarasi)
        {
            case 1:
                
                processText = "+";
                numberText3.text = myNumber1.ToString();
                gatherTextt.enabled = true;
                interestText.enabled = false;
                multiplyText.enabled = false;
                plentyText.enabled = false;
                PercentText.enabled = false;
                numberTextZero.enabled = false;
                ResultClose();

                Debug.Log("İşlem Toplamaya Başladı");
                UpTop();
              
                break;
            case 2:
                processText = "-";
                numberText3.text = myNumber1.ToString();
                interestText.enabled = true;
                multiplyText.enabled = false;
                plentyText.enabled = false;
                PercentText.enabled = false;
                numberTextZero.enabled = false;
                ResultClose();
                Debug.Log("İşlem Çıkartmaya Başladı");
                UpTop();
               
                break;
            case 3:
                processText = "x";
                numberText3.text = myNumber1.ToString();
                multiplyText.enabled = true;
                plentyText.enabled = false;
                gatherTextt.enabled = false;
                interestText.enabled = false;
                PercentText.enabled = false;
                numberTextZero.enabled = false;
                ResultClose();
                UpTop();
                Debug.Log("İşlem Çarpmaya Başladı");
                
                break;
            case 4:
                processText = "/";
                numberText3.text = myNumber1.ToString();
                plentyText.enabled = true;
                gatherTextt.enabled = false;
                interestText.enabled = false;
                multiplyText.enabled = false;
                PercentText.enabled = false;
                numberTextZero.enabled = false;
                ResultClose();
                Debug.Log("İşlem Bölmeye Başladı");
                UpTop();
              
                break;
            case 5:
                processText = "%";
                numberText3.text = myNumber1.ToString();
                plentyText.enabled = false;
                PercentText.enabled = true;
                gatherTextt.enabled = false;
                interestText.enabled = false;
                multiplyText.enabled = false;
                numberTextZero.enabled = false;
                ResultClose();

                Debug.Log("İşlem Bölmeye Başladı");
                UpTop();
                break;
            default:
                break;
        }

    }
     
    public void Equals()
    {
        
        SymbolText();
        int number2 = int.Parse(myNumber2);
        int number3 = int.Parse(myNumber1);
        

        if (processText.Equals("+"))
        {
            int number = number2 + number3 ;
            resultText.text = number.ToString();
            numberTextZero.enabled = false;
            StartCoroutine(ResultCoroutine());
            StartCoroutine(ZeroTimer());
            StartCoroutine(NumberrControl());
            TextOFF();
            Debug.Log("Cevap" + number3 + number2);
            Clear();

        }
        if (processText.Equals("-"))
        {   
            int number = number2 - number3;
            resultText.text = number.ToString();
            Debug.Log("Cevap" + number3);
            StartCoroutine(ResultCoroutine());
            StartCoroutine(ZeroTimer());
            StartCoroutine(NumberrControl());
            TextOFF();
            Clear();
            numberTextZero.enabled = false;
        }
        if (processText.Equals("x"))
        {
            int number = number2 * number3;
            resultText.text = number.ToString();
            Debug.Log("Cevap" + number3);
            StartCoroutine(ResultCoroutine());
            StartCoroutine(ZeroTimer());
            StartCoroutine(NumberrControl());
            TextOFF();
            Clear();
            numberTextZero.enabled = false;
        }
        if (processText.Equals("/"))
        {
            int number = number2 / number3;
            resultText.text = number.ToString();
            Debug.Log("Cevap" + number3);
            StartCoroutine(ResultCoroutine());
            StartCoroutine(ZeroTimer());
            StartCoroutine(NumberrControl());
            TextOFF();
            Clear();
            numberTextZero.enabled = false;
        }
        if (processText.Equals("%"))
        {
            int number = (number2 * number3) / 100;
            resultText.text = number.ToString();
            Debug.Log("Cevap" + number3);
            StartCoroutine(ResultCoroutine());          
            StartCoroutine(ZeroTimer());
            StartCoroutine(NumberrControl());
            TextOFF();
            Clear();
            numberTextZero.enabled = false;
        }
        myNumber1 = string.Empty;
        processText = string.Empty;
        Clear();
    }
    public IEnumerator ResultCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        resultText.text = string.Empty;
        Debug.Log("Result Text Silindi");
    }
    public IEnumerator ZeroTimer()
    {
        yield return new WaitForSeconds(1.5f);
        numberTextZero.enabled = true;
        isTrueNumber = true;
        isFirstNumber = true;
    }

    public IEnumerator NumberrControl()
    {
        yield return new WaitForSeconds(0.1f);
        
      // isTrueNumber = false;
       //isFirstNumber = false;
    }
    public void UpTop()
    {
        numberText11.text = numberText22.text;
        numberText22.text = MyStr2Change;  
    }
    public void Result()
    {
        //resultText.text = number.ToString();
    }
    public void Clear()
    {
        isFirstNumber = true;
        myNumber2 = string.Empty;
        myNumber1 = string.Empty;
        numberText11.text = string.Empty;
        numberText22.text = string.Empty;
        numberText3.text = string.Empty;
        numberTextZero.enabled = false;
        PercentText.text = string.Empty;
        SymbolText();
    }
    public void ResultClose()
    {
        resultText.text = string.Empty;
    }
    public void zeroTimer()
    {
        numberTextZero.enabled = false;
    }

    public void TextOFF()
    {
        isTrueNumber = false;
        isFirstNumber = false;
    }
}