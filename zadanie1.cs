using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

/*
class EAN
{
    static void checkDigitEAN(long EANnumber) {

        string EANstring = EANnumber.ToString();
        int sum = 0, checkDigit;
        char lastCharEAN = EANstring[EANstring.Length - 1];
        int lastDigitEAN = Convert.ToInt32(lastCharEAN.ToString());

       
            if (EANstring.Length == 13)// tu zmiana EANnumber.ToString().Length == 13
            {

                for (int i = 0; i < EANstring.Length - 1; i++)
                {
                    int digit = Convert.ToInt32(EANstring[i].ToString());

                    if (i % 2 == 0)
                    {
                        sum += digit * 1;
                    }
                    else
                    {
                        sum += digit * 3;
                    }
                }

                double roundedSum = Math.Round((double)sum / 10) * 10;

                checkDigit = (int)roundedSum - (int)sum;

                if (Math.Abs(checkDigit) == lastDigitEAN)
                {
                    Console.WriteLine("Liczba kontrolna jest poprawna!!");
                }
                else
                {
                    Console.WriteLine("Liczba kontrolna jest niepoprawna.");
                }
            }
            else
            {
                Console.WriteLine("Podaj 13 cyfrowy numer EAN");
            }
        
    }

    static void Main(){
        long EANnumber;
        bool correctType;
        Console.WriteLine("Podaj 13 cyfrowy numer EAN");
        
        correctType = long.TryParse(Console.ReadLine(), out EANnumber);

        if (correctType)
        {
            checkDigitEAN(EANnumber);
        }
        else {
            Console.WriteLine("Podaj liczbę!");
        }
        
    
    }


}
*/


long EANnumber;
bool correcType;

Console.WriteLine("Podaj 13 cyfrowy numer EAN");
correcType = long.TryParse(Console.ReadLine(), out EANnumber);


string EANstring = EANnumber.ToString();
int sum = 0, checkDigit;
char lastCharEAN = EANstring[EANstring.Length - 1];
int lastDigitEAN = Convert.ToInt32(lastCharEAN.ToString());

if (correcType)
{
    if (EANstring.Length == 13)
    {

        for (int i = 0; i < EANstring.Length - 1; i++)
        {
            int digit = Convert.ToInt32(EANstring[i].ToString());

            if (i % 2 == 0)
            {
                sum += digit * 1;
            }
            else
            {
                sum += digit * 3;
            }
        }

        double roundedSum = Math.Round((double)sum / 10) * 10;
      
        checkDigit = (int)roundedSum - (int)sum;

        if (Math.Abs(checkDigit) == lastDigitEAN)
        {
            Console.WriteLine("Liczba kontrolna jest poprawna!!");
        }
        else
        {
            Console.WriteLine("Liczba kontrolna jest niepoprawna.");
        }
    }
    else
    {
        Console.WriteLine("Podaj 13 cyfrowy numer EAN");
    }
}
else
{
    Console.WriteLine("Podaj Cyfry");
}
