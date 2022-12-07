#region Spojovy seznam
//Console.WriteLine("Spojovy seznam");

//var mujSeznam = new SpojovySeznam<int>();

//mujSeznam.VlozNaKonec(1);
//mujSeznam.VlozNaKonec(1);
//mujSeznam.VlozNaKonec(1);
//mujSeznam.VlozNaKonec(2);
//mujSeznam.VlozNaKonec(3);
//mujSeznam.VlozNaKonec(4);
//mujSeznam.VlozNaKonec(5);
//Console.WriteLine(mujSeznam.ToString());
//mujSeznam.odeberIndex(2);
//Console.WriteLine(mujSeznam.ToString());

//Console.WriteLine($"Pocet prvku v kolekci: {mujSeznam.Pocet()}");
//Console.WriteLine($"Pocet prvku v kolekci: {mujSeznam.Count}");
//Console.WriteLine($"Kolikrat se objevuje zadany prvek: {mujSeznam.pocetPrvku(1)}");

#endregion

#region Binary tree
//Console.WriteLine("\nBinarni strom");

//var binaryTree = new BinarniStrom();

//binaryTree.Vloz(3);
//binaryTree.Vloz(5);
//binaryTree.Vloz(1);
//binaryTree.Vloz(7);
//binaryTree.Vloz(2);
//binaryTree.Vloz(4);

//Console.WriteLine(binaryTree.ToString());
#endregion

#region Generic binary tree
Console.WriteLine("\nGenericky binarni strom");

var genericBinaryTree = new GenerickyBinarniStrom<int>();

genericBinaryTree.Vloz(3);
genericBinaryTree.Vloz(5);
genericBinaryTree.Vloz(1);
genericBinaryTree.Vloz(7);
genericBinaryTree.Vloz(2);
genericBinaryTree.Vloz(4);

Console.WriteLine(genericBinaryTree.ToString());
//Console.WriteLine($"Pocet prvku v kolekci: {genericBinaryTree.Count}");
Console.WriteLine($"Pocet prvku v kolekci: {genericBinaryTree.Pocet()}");
#endregion


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

class BinarniStrom
{
    Uzel koren;
    public int Count { get; set; }

    public void Vloz(int vstup)
    {
        //checkuju existenci korene
        if (koren == null)
        {
            koren = new Uzel(vstup);
            return;
        }
        
        VlozRekurzivne(koren, vstup);
    }

    void VlozRekurzivne(Uzel koren, int novy)
    {
        if (novy <= koren.hodn) //mensi a stejny prvky doleva
        {
            if (koren.levy == null)
            {
                koren.levy = new Uzel(novy);
            }
            else
            {
                VlozRekurzivne(koren.levy, novy);
            }
        }
        else
        {
            if (koren.pravy == null)
            {
                koren.pravy = new Uzel(novy);
            }
            else
            {
                VlozRekurzivne(koren.pravy, novy);
            }
        }
    }

    //public bool odeber(int vstup)
    //{
    //    if (koren == null)
    //    {
    //        throw new InvalidOperationException("Seznam je prazdny");
    //    }
    //    return odeberRekurzivne(koren, vstup);
    //}

    //bool odeberRekurzivne(Uzel koren, int vstup)
    //{
    //    if (koren.hodn == vstup)
    //    {
    //        /*
    //         * 1) nemam zadneho potomka, u predchudce zmenim na null
    //         * 2) mam jednoho potomka, u predchudce nahradim sebe potomkem
    //         * 3) mam oba nasledniky, u predchudce nahradim sebe jednim naslednikem a podstrom druheho nalsednika, zaradim do prvniho naslednika
    //         */
    //    }
    //    else if (vstup <= koren.hodn) //pujdu doleva
    //    {
    //        if (koren.levy == null)
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            return odeberRekurzivne(koren.levy, vstup);
    //        }
    //    }
    //    else //pujdu doprava
    //    {
    //        if (koren.pravy == null)
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            return odeberRekurzivne(koren.pravy, vstup);
    //        }
    //    }
    //}

    string vystup = "";

    public override string ToString()
    {
        Uzel temp = koren;

        if (temp != null)
        {
            VypisRekurzivne(koren);
        }
        
        return vystup;
    }

    private void VypisRekurzivne(Uzel koren)
    {
        if (koren != null)
        {
            if (koren.levy != null)
            {
                VypisRekurzivne(koren.levy);
            }
            
            vystup += koren.hodn + " ";
            
            if (koren.pravy != null)
            {
                VypisRekurzivne(koren.pravy);
            }
        }
    }

    public BinarniStrom()
    {
        koren = null;
    }

    internal class Uzel //Node
    {
        public int hodn;
        public Uzel levy, pravy;

        public Uzel(int h)
        {
            hodn = h;
            levy = pravy = null;
        }
    }

    /*
     * DÚ: count jako vlastnost, která se bude počítat
     * Negenerický strom (nebo generický???)
     */
    
}


class GenerickyBinarniStrom<T> where T : IComparable<T>
{
    Uzel koren;
    public int Count { get; set; }

    public void Vloz(T vstup)
    {
        //checkuju existenci korene
        if (koren == null)
        {
            koren = new Uzel(vstup);
            return;
        }
        VlozRekurzivne(koren, vstup);
    }

    void VlozRekurzivne(Uzel koren, T novy)
    {
        if (novy.CompareTo(koren.hodn) <= 0) //mensi a stejny prvky doleva
        {
            if (koren.levy == null)
            {
                koren.levy = new Uzel(novy);
            }
            else
            {
                VlozRekurzivne(koren.levy, novy);
            }
        }
        else
        {
            if (koren.pravy == null)
            {
                koren.pravy = new Uzel(novy);
            }
            else
            {
                VlozRekurzivne(koren.pravy, novy);
            }
        }
    }

    string vystup = "";

    public override string ToString()
    {
        Uzel temp = koren;

        if (temp != null)
        {
            VypisRekurzivne(koren);
        }

        return vystup;
    }

    private void VypisRekurzivne(Uzel koren)
    {
        if (koren != null)
        {
            if (koren.levy != null)
            {
                VypisRekurzivne(koren.levy);
            }

            vystup += koren.hodn + " ";

            if (koren.pravy != null)
            {
                VypisRekurzivne(koren.pravy);
            }
        }
    }

    public GenerickyBinarniStrom()
    {
        koren = null;
    }

    internal class Uzel //Node
    {
        public T hodn;
        public Uzel levy, pravy;

        public Uzel(T h)
        {
            hodn = h;
            levy = pravy = null;
        }
    }
    
    public int Pocet()
    {
        return PocetRekurzivne(koren);
    }

    private int PocetRekurzivne(Uzel koren)
    {
        if (koren == null)
        {
            return 0;
        }
        else
        {
            return 1 + PocetRekurzivne(koren.levy) + PocetRekurzivne(koren.pravy);
        }
    }
}