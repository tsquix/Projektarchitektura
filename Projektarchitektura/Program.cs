class Rejestry
{

    static Dictionary<string, string> regexe()
    {
        Dictionary<string, string> R = new Dictionary<string, string>();
        R.Add("AL", "0");
        R.Add("AH", "0");
        R.Add("BL", "0");
        R.Add("BH", "0");
        R.Add("CL", "0");
        R.Add("CH", "0");
        R.Add("DL", "0");
        R.Add("DH", "0");
        return R;
    }

    static void regwrite(Dictionary<string, string> Rej)
    {
        Console.WriteLine("Stan rejestrów :");
        foreach (KeyValuePair<string, string> entry in Rej)
        {
            Console.WriteLine(entry.Key+" "+entry.Value);
        }
    }

    static Dictionary<string, string> regload(Dictionary<string, string> Rej) //wczytanie rejestrow
    {
        string[] rej = new string[] { "AL", "AH", "BL", "BH", "CL", "CH", "DL", "DH" }; //nazwy rejestrow
        Rej.Clear(); //czyszczenie slownika
        for (int i = 0; i<8; i++)
        {
            Console.Write("Podaj wartość do zapisania w rejestrze "+rej[i]+":"); //wczytuje 
            int liczba = int.Parse(Console.ReadLine()); 
            Rej.Add(rej[i], liczba.ToString("X")); 
        }
        return Rej;
    }

    static bool correct(Dictionary<string, string> Rej)
    {
        string[] rej = new string[] { "AL", "AH", "BL", "BH", "CL", "CH", "DL", "DH" };
        bool odp = true;
        for (int i = 0; i<8 && odp; i++)
        {
            int liczba = Convert.ToInt32(Rej[rej[i]], 16); 
            if (liczba>255) odp=false; 
        }
        return odp;
    }

    static Dictionary<string, string> MOV(Dictionary<string, string> Rej, string a, string b)
    { 
        Rej[a]=Rej[b];
        return Rej;
    }

    static Dictionary<string, string> XCHG(Dictionary<string, string> Rej, string a, string b)
    {
        string temp; 
        temp=Rej[a]; 
        Rej[a]=Rej[b]; 
        Rej[b]=temp; 
        return Rej;
    }

    static Dictionary<string, string> NOT(Dictionary<string, string> Rej, string a)
    {
        int temp; 
        temp=Convert.ToInt32(Rej[a], 16); 
        temp=255-temp; 
        Rej[a]=temp.ToString("X"); 
        return Rej;
    }

    static Dictionary<string, string> INC(Dictionary<string, string> Rej, string a)
    { 
        int temp; 
        temp=Convert.ToInt32(Rej[a], 16);
        temp=temp+1; 
        Rej[a]=temp.ToString("X");
        return Rej;
    }

    static Dictionary<string, string> DEC(Dictionary<string, string> Rej, string a)
    {
        int temp;
        temp=Convert.ToInt32(Rej[a], 16);
        temp=temp-1;
        Rej[a]=temp.ToString("X");
        return Rej;
    }

    static Dictionary<string, string> AND(Dictionary<string, string> Rej, string a, string b)
    {
        int temp1, temp2;
        temp1=Convert.ToInt32(Rej[a], 16);
        temp2=Convert.ToInt32(Rej[b], 16);
        temp1=temp1 & temp2;
        Rej[a]=temp1.ToString("X");
        return Rej;
    }

    static Dictionary<string, string> OR(Dictionary<string, string> Rej, string a, string b)
    {
        int temp1, temp2;
        temp1=Convert.ToInt32(Rej[a], 16);
        temp2=Convert.ToInt32(Rej[b], 16);
        temp1=temp1 | temp2;
        Rej[a]=temp1.ToString("X");
        return Rej;
    }

    static Dictionary<string, string> XOR(Dictionary<string, string> Rej, string a, string b)
    {
        int temp1, temp2;
        temp1=Convert.ToInt32(Rej[a], 16);
        temp2=Convert.ToInt32(Rej[b], 16);
        temp1=temp1 ^ temp2;
        Rej[a]=temp1.ToString("X");
        return Rej;
    }

    static Dictionary<string, string> ADD(Dictionary<string, string> Rej, string a, string b)
    {
        int temp1, temp2;
        temp1=Convert.ToInt32(Rej[a], 16);
        temp2=Convert.ToInt32(Rej[b], 16);
        temp1=temp1 + temp2;
        Rej[a]=temp1.ToString("X");
        return Rej;
    }

    static Dictionary<string, string> SUB(Dictionary<string, string> Rej, string a, string b)
    {
        int temp1, temp2;
        temp1=Convert.ToInt32(Rej[a], 16);
        temp2=Convert.ToInt32(Rej[b], 16);
        temp1=temp1 - temp2;
        Rej[a]=temp1.ToString("X");
        return Rej;
    }


    static void Main()
    {
        int wyboryy, instrukcja;  
        string rej1, rej2; 
        bool popr; 
        Dictionary<string, string> Rejestry = regexe(); 
        do
        {
            regwrite(Rejestry);
            Console.WriteLine("");
            Console.WriteLine("/////////////////////////////////////");
            Console.WriteLine("Podaj numer operacji do wykonania:"); //menu
            Console.WriteLine("1:  Zmiana zawartosci rejestrow");
            Console.WriteLine("2:  Operacje rejestrów");
            Console.WriteLine("3:  Zamknij program");
            Console.WriteLine("/////////////////////////////////////");
            wyboryy=int.Parse(Console.ReadLine()); //wczytuje
            switch (wyboryy)
            {
                case 1: //jezeli bedzie zmiana rejestrow
                    do
                    {
                        Rejestry=regload(Rejestry); //wczytuje 
                        popr=correct(Rejestry); //sprawdza
                        if (!popr) Console.WriteLine("Wczytanie nie jest 8 bitowe"); 
                    } while (!popr);
                    break;
                case 2:
                    Console.WriteLine("Podaj numer instrukcji do wykonania:");
                    Console.WriteLine("1 - MOV");
                    Console.WriteLine("2 - XCHG");
                    Console.WriteLine("3 - NOT");
                    Console.WriteLine("4 - INC");
                    Console.WriteLine("5 - DEC");
                    Console.WriteLine("6 - AND");
                    Console.WriteLine("7 - OR");
                    Console.WriteLine("8 - XOR");
                    Console.WriteLine("9 - ADD");
                    Console.WriteLine("10 - SUB");
                    instrukcja=int.Parse(Console.ReadLine());
                    switch (instrukcja)
                    {
                        case 1:
                            Console.WriteLine("Dostepne rejestry: AL AH BL BH CL CH DL DH"); //wypisuje
                            Console.Write("Podaj zawartosc pierwszego rejestru dla instrukcji MOV:");
                            rej1=Console.ReadLine(); //wczytuje 
                            rej1=rej1.ToUpper();
                            Console.Write("Podaj zawartosc drugiego rejestru dla instrukcji MOV:");
                            rej2=Console.ReadLine(); 
                            rej2=rej2.ToUpper();
                            if (Rejestry.ContainsKey(rej1) && Rejestry.ContainsKey(rej2)) //ifcorrect
                            {
                                Rejestry=MOV(Rejestry, rej1, rej2);
                            }
                            else Console.WriteLine("Bledny rejestr");
                            break;
                        case 2: //pozostale identyczne dzialanie
                            Console.WriteLine("Dostepne rejestry: AL AH BL BH CL CH DL DH");
                            Console.Write("Podaj zawartosc pierwszego rejestru dla instrukcji XCHG:");
                            rej1=Console.ReadLine();
                            rej1=rej1.ToUpper();
                            Console.Write("Podaj zawartosc drugiego rejestru dla instrukcji XCHG:");
                            rej2=Console.ReadLine();
                            rej2=rej2.ToUpper();
                            if (Rejestry.ContainsKey(rej1) && Rejestry.ContainsKey(rej2))
                            {
                                Rejestry=XCHG(Rejestry, rej1, rej2);
                            }
                            else Console.WriteLine("Bledny rejestr");
                            break;
                        case 3:
                            Console.WriteLine("Dostepne rejestry: AL AH BL BH CL CH DL DH");
                            Console.Write("Podaj zawartosc rejestru dla instrukcji NOT:");
                            rej1=Console.ReadLine();
                            rej1=rej1.ToUpper();
                            if (Rejestry.ContainsKey(rej1))
                            {
                                Rejestry=NOT(Rejestry, rej1);
                            }
                            else Console.WriteLine("Bledny rejestr");
                            break;
                        case 4:
                            Console.WriteLine("Dostepne rejestry: AL AH BL BH CL CH DL DH");
                            Console.Write("Podaj zawartosc rejestru dla instrukcji INC:");
                            rej1=Console.ReadLine();
                            rej1=rej1.ToUpper();
                            if (Rejestry.ContainsKey(rej1))
                            {
                                Rejestry=INC(Rejestry, rej1);
                            }
                            else Console.WriteLine("Bledny rejestr");
                            break;
                        case 5:
                            Console.WriteLine("Dostepne rejestry: AL AH BL BH CL CH DL DH");
                            Console.Write("Podaj zawartosc rejestru dla instrukcji DEC:");
                            rej1=Console.ReadLine();
                            rej1=rej1.ToUpper();
                            if (Rejestry.ContainsKey(rej1))
                            {
                                Rejestry=DEC(Rejestry, rej1);
                            }
                            else Console.WriteLine("Bledny rejestr");
                            break;
                        case 6:
                            Console.WriteLine("Dostepne rejestry: AL AH BL BH CL CH DL DH");
                            Console.Write("Podaj zawartosc pierwszego rejestru dla instrukcji AND:");
                            rej1=Console.ReadLine();
                            rej1=rej1.ToUpper();
                            Console.Write("Podaj zawartosc drugiego rejestru dla instrukcji AND:");
                            rej2=Console.ReadLine();
                            rej2=rej2.ToUpper();
                            if (Rejestry.ContainsKey(rej1) && Rejestry.ContainsKey(rej2))
                            {
                                Rejestry=AND(Rejestry, rej1, rej2);
                            }
                            else Console.WriteLine("Bledny rejestr");
                            break;
                        case 7:
                            Console.WriteLine("Dostepne rejestry: AL AH BL BH CL CH DL DH");
                            Console.Write("Podaj zawartosc pierwszego rejestru dla instrukcji OR:");
                            rej1=Console.ReadLine();
                            rej1=rej1.ToUpper();
                            Console.Write("Podaj zawartosc drugiego rejestru dla instrukcji OR:");
                            rej2=Console.ReadLine();
                            rej2=rej2.ToUpper();
                            if (Rejestry.ContainsKey(rej1) && Rejestry.ContainsKey(rej2))
                            {
                                Rejestry=OR(Rejestry, rej1, rej2);
                            }
                            else Console.WriteLine("Bledny rejestr");
                            break;
                        case 8:
                            Console.WriteLine("Dostepne rejestry: AL AH BL BH CL CH DL DH");
                            Console.Write("Podaj zawartosc pierwszego rejestru dla instrukcji XOR:");
                            rej1=Console.ReadLine();
                            rej1=rej1.ToUpper();
                            Console.Write("Podaj zawartosc drugiego rejestru dla instrukcji XOR:");
                            rej2=Console.ReadLine();
                            rej2=rej2.ToUpper();
                            if (Rejestry.ContainsKey(rej1) && Rejestry.ContainsKey(rej2))
                            {
                                Rejestry=XOR(Rejestry, rej1, rej2);
                            }
                            else Console.WriteLine("Bledny rejestr");
                            break;
                        case 9:
                            Console.WriteLine("Dostepne rejestry: AL AH BL BH CL CH DL DH");
                            Console.Write("Podaj zawartosc pierwszego rejestru dla instrukcji ADD:");
                            rej1=Console.ReadLine();
                            rej1=rej1.ToUpper();
                            Console.Write("Podaj zawartosc drugiego rejestru dla instrukcji ADD:");
                            rej2=Console.ReadLine();
                            rej2=rej2.ToUpper();
                            if (Rejestry.ContainsKey(rej1) && Rejestry.ContainsKey(rej2))
                            {
                                Rejestry=ADD(Rejestry, rej1, rej2);
                            }
                            else Console.WriteLine("Bledny rejestr");
                            break;
                        case 10:
                            Console.WriteLine("Rejestry: AL AH BL BH CL CH DL DH");
                            Console.Write("Podaj zawartosc pierwszego rejestru dla instrukcji SUB:");
                            rej1=Console.ReadLine();
                            rej1=rej1.ToUpper();
                            Console.Write("Podaj zawartosc drugiego rejestru dla instrukcji SUB:");
                            rej2=Console.ReadLine();
                            rej2=rej2.ToUpper();
                            if (Rejestry.ContainsKey(rej1) && Rejestry.ContainsKey(rej2))
                            {
                                Rejestry=SUB(Rejestry, rej1, rej2);
                            }
                            else Console.WriteLine("Bledny rejestr");
                            break;
                        default:
                            Console.WriteLine("Bledna instrukcja");
                            break;
                    }
                    break;
            }
        } while (wyboryy!=3);
    }
}