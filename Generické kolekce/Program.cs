// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");

var mujSeznam = new SpojovySeznam<int>();

mujSeznam.VlozNaKonec(1);
mujSeznam.VlozNaKonec(2);
mujSeznam.VlozNaKonec(3);
mujSeznam.VlozNaKonec(4);
mujSeznam.VlozNaKonec(5);
Console.WriteLine(mujSeznam.ToString());
mujSeznam.odeberIndex(2);
Console.WriteLine(mujSeznam.ToString());

class SpojovySeznam<T> //LinkedList
{
    Uzel zacatek;
    int Count { get; set; }
    
    public void Vloz(T vstup)
    {
        Uzel novy = new Uzel(vstup, zacatek); //sel by pouzit i var
        zacatek = novy; //nejdulezitejsi cast prace se spojovymi seznamy
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
    }

    public T odeberPrvni()
    {
        var temp = zacatek;

        if (temp == null)
        {
            throw new InvalidOperationException("Seznam je prazdny");
        }
        
        zacatek = zacatek.dalsi;
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
        return temp2.hodn;
    }

    public T odeberIndex(int index)
    {
        var temp = zacatek;

        if (index < 0 || temp == null)
        {
            throw new InvalidOperationException("Seznam je prazdny");
        }

        if (index == 0)
        {
            zacatek = zacatek.dalsi;
            return temp.hodn;
        }
        else
        {
            Uzel pomocny = temp;
            for (int i = 0; i < index; i++)
            {
                pomocny = temp;
                temp = temp.dalsi;
            }

            pomocny = temp.dalsi;
        }

        return temp.hodn;
        
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