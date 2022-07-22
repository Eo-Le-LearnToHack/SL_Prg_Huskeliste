using System.Text;

while (true)
{
    Console.Clear();
    string[] huskeliste = new string[5]; //Brugernes huskeliste gemmes heri.

    for (int i = 0; i < 5; i++)
    {
        string instruktion = $"Indtast ting nr. {i + 1} på huskelisten\t:";
        string fejlBesked = $"Prøv igen\t:";
        huskeliste[i] = DinHuskeliste(instruktion, fejlBesked) ; //Mindst 1 karakter og må ikke være tom.
    }

    Console.WriteLine();
    do
    {
        string instruktion = $"Hvad har du pakket? Indtast fra 1-5\t:";
        string fejlBesked = $"Prøv igen\t:";
        int dinTing = DinPakkeliste(instruktion, fejlBesked, 1, 5) - 1; //Skal være int tal mellem 1 til 5. Minus 1 til sidst for at få det rigtige array index.
        huskeliste[dinTing] = ""; //Ting som er pakket bliver fjernet fra huskelisten ved at erstatte med tom tekst.
        Console.WriteLine("Du mangler at pakke:");
        int counter = 1;
        foreach (string item in huskeliste)
        {
            if (String.IsNullOrWhiteSpace(item))
            { counter++; }
            else
            {
                Console.WriteLine($"{counter}: {item}"); //Udskriv kun de ting på huskelisten som ikke er tom.
                counter++;
            }
        }
        Console.ReadLine();
    } while (!DuHarPakketAlleDineTing(huskeliste)); //Værdierne i huskelisten sammensættes til en samlet tekst. Hvis teksten er tom, er alle varerne pakket.

    Console.WriteLine("Du har pakket alle dine ting.".ToUpper());
    Console.ReadLine();
}
    




///////////////////////////////////////////////////
//HERUNDER FINDES METODERNE
string DinHuskeliste(string instruction, string erroMessage)
{
    string? userInput = null;
    char[] charsToTrim = { '*', ' ', '\'', '*', '?', '@', '#', '"', '%' }; //Disse karakterer bliver trimmet væk ved brug af Trim() funktionen.
    do
    {
        Console.Write(instruction);
        userInput = Console.ReadLine();
        string temp = userInput.Trim(charsToTrim);
        if (String.IsNullOrEmpty(temp) || String.IsNullOrWhiteSpace(temp) || userInput.Length < 2)
        {
            Console.WriteLine(erroMessage);
            userInput = null;
        }
    } while (userInput == null);
    return userInput;
}



int DinPakkeliste(string instruction, string erroMessage, int minNum, int maxNum)
{
    string? userInput = null;
    int output;
    do
    {
        Console.Write(instruction);
        userInput = Console.ReadLine();
        
        if (int.TryParse(userInput, out output) && output >= minNum && output <= maxNum)
        { userInput = "OK"; }
        else
        { 
            Console.WriteLine(erroMessage);
            userInput = null;
        }
    } while (userInput == null);
    return output;
}


bool DuHarPakketAlleDineTing(string[] strArray)
{
    bool bol = false;
    StringBuilder sb = new();
    foreach (string item in strArray)
    { sb.Append(item); }
    string text = sb.ToString();
    if (String.IsNullOrWhiteSpace(text))
    { bol = true; }
    return bol;  
}
