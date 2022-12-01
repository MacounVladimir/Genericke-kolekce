// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");

var mujSeznam = new SpojovySeznam<int>();

mujSeznam.VlozNaKonec(1);
mujSeznam.VlozNaKonec(1);
mujSeznam.VlozNaKonec(1);
mujSeznam.VlozNaKonec(2);
mujSeznam.VlozNaKonec(3);
mujSeznam.VlozNaKonec(4);
mujSeznam.VlozNaKonec(5);
Console.WriteLine(mujSeznam.ToString());
mujSeznam.odeberIndex(2);
Console.WriteLine(mujSeznam.ToString());

Console.WriteLine($"Pocet prvku v kolekci: {mujSeznam.Pocet()}");
Console.WriteLine($"Pocet prvku v kolekci: {mujSeznam.Count}");
Console.WriteLine($"Kolikrat se objevuje zadany prvek: {mujSeznam.pocetPrvku(1)}");

class SpojovySeznam<T> //LinkedList
{
    Uzel zacatek;
    public int Count { get; set; }
    
    public void Vloz(T vstup)
    {
        Uzel novy = new Uzel(vstup, zacatek); //sel by pouzit i var
        zacatek = novy; //nejdulezitejsi cast prace se spojovymi seznamy
        Count++;
    }

    public void VlozNaKonec(T vstup)
    {
        Uzel novy = new Uzel(vstup, null); //sel by pouzit i var
        var temp = zacatek;
        if (temp == null)
        {
            zacatek = novy;
        }
        else
        {
            while (temp.dalsi != null)
            {
                temp = temp.dalsi;
            }
            temp.dalsi = novy;
        }
        Count++;
    }

    public T odeberPrvni()
    {
        var temp = zacatek;

        if (temp == null)
        {
            throw new InvalidOperationException("Seznam je prazdny");
        }
        
        zacatek = zacatek.dalsi;
        Count--;
        return temp.hodn;
    }

    public T odeberPosledni()
    {
        var temp = zacatek;
        if (temp == null)
        {
            throw new InvalidOperationException("Seznam je prazdny");
        }
        if (temp.dalsi == null)
        {
            zacatek = null;
            return temp.hodn;
        }
        while (temp.dalsi.dalsi != null)
        {
            temp = temp.dalsi;
        }
        var temp2 = temp.dalsi;
        temp.dalsi = null;
        Count--;
        return temp2.hodn;
    }

    public T odeberIndex(int index)
    {
        var temp = zacatek;
        if (temp == null)
        {
            throw new InvalidOperationException("Seznam je prazdny");
        }
        if (index == 0)
        {
            zacatek = zacatek.dalsi;
            return temp.hodn;
        }
        for (int i = 0; i < index - 1; i++)
        {
            temp = temp.dalsi;
        }
        var temp2 = temp.dalsi;
        temp.dalsi = temp.dalsi.dalsi;
        Count--;
        return temp2.hodn;
    }
    
    public int Pocet()
    {
        var temp = zacatek;
        int pocet = 0;
        while (temp != null)
        {
            pocet++;
            temp = temp.dalsi;
        }
        return pocet;
    }

    public int pocetPrvku(T prvek)
    {
        var temp = zacatek;
        int pocet = 0;
        while (temp != null)
        {
            if (temp.hodn.Equals(prvek))
            {
                pocet++;
            }
            temp = temp.dalsi;
        }
        return pocet;
    }

    //DÚ:
    //Count počítadlo
    //Zjištění kolikrát se nějaký prvek vyskytuje v seznamu

    public override string ToString()
    {
        string vystup = "";
        Uzel temp = zacatek;
        while (temp != null)
        {
            vystup += temp.hodn + " ";
            temp = temp.dalsi; //nejdulezitejsi cast prace se spojovymi seznamy
        }
        return vystup;
    }

    public SpojovySeznam()
    {
        zacatek = null;
    }

    internal class Uzel //Node
    {
        public T hodn { get; set; }
        public Uzel dalsi { get; set; }

        public Uzel(T h, SpojovySeznam<T>.Uzel d)
        {
            hodn = h;
            dalsi = d;
        }
    }
}