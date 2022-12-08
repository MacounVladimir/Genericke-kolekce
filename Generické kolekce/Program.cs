#region Genericky spojovy seznam
Console.WriteLine("Genericky spojovy seznam");

var mujSeznam = new SpojovySeznam<int>();

mujSeznam.VlozNaKonec(1);
mujSeznam.VlozNaKonec(1);
mujSeznam.VlozNaKonec(1);
mujSeznam.VlozNaKonec(2);
mujSeznam.VlozNaKonec(3);
mujSeznam.VlozNaKonec(4);
mujSeznam.VlozNaKonec(5);

Console.WriteLine("Linked list: " + mujSeznam.ToString());

//úkol číslo 1
Console.WriteLine("indexPrvku (3): " + mujSeznam.indexPrvku(3)); 

//mujSeznam.odeberIndex(2);
//Console.WriteLine(mujSeznam.ToString());

//úkol číslo 2
Console.WriteLine($"Pocet prvku v kolekci (metoda): {mujSeznam.Pocet()}");
Console.WriteLine($"Pocet prvku v kolekci (property): {mujSeznam.Count}");

Console.WriteLine($"Kolikrat se objevuje zadany prvek (1): {mujSeznam.pocetPrvku(1)}");

//úkol číslo 3
//metoda, která obrátí pořadí prvků v kolekci
mujSeznam.Obrat();
Console.WriteLine("Obraceny seznam: " + mujSeznam.ToString());

//úkol číslo 4
mujSeznam.odstranVetsiPrvky(3);
Console.WriteLine("Odstraneni prvku vetsich nez (3): " + mujSeznam.ToString());

//úkol číslo 5
// :(

//úkol číslo 6 - :/
var mujSeznam2 = new SpojovySeznam<int>();
mujSeznam2.VlozNaKonec(1);
mujSeznam2.VlozNaKonec(2);
mujSeznam2.VlozNaKonec(3);
Console.WriteLine("Druhy seznam: " + mujSeznam2.ToString());

var miscClass = new Misc();
var mujSeznam3 = miscClass.ConnectTwoLinkedLists(mujSeznam, mujSeznam2);
Console.WriteLine("Spojeni dvou seznamu: " + mujSeznam3.ToString());

//Console.WriteLine("Pocet prvku v seznamu: " + mujSeznam3.Count); //pocet prvku v seznamu, pro overeni funkcnosti 👍

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
genericBinaryTree.Vloz(1);
genericBinaryTree.Vloz(7);
genericBinaryTree.Vloz(7);
genericBinaryTree.Vloz(2);
genericBinaryTree.Vloz(4);

Console.WriteLine(genericBinaryTree.ToString());
//Úkol 7
Console.WriteLine($"Pocet prvku v kolekci (metoda): {genericBinaryTree.Pocet()}");
//Úkol 8
Console.WriteLine($"Pocet vyskytu prvku v kolekci (7): {genericBinaryTree.PocetPrvku(7)}");
//Úkol 9 - podiférní
Console.WriteLine($"Pocet uzlu s danym poctem nasledniku (1): {genericBinaryTree.NodesWithChildCount(1)}");
//Úkol 10
Console.WriteLine($"Vyvážený?: {genericBinaryTree.isBalanced()}");
#endregion


class SpojovySeznam<T> where T : IComparable //LinkedList
{
    public Uzel zacatek;
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

    public int indexPrvku(T prvek)
    {
        var temp = zacatek;
        int index = 0;
        while (temp != null)
        {
            if (temp.hodn.Equals(prvek))
            {
                return index;
            }
            temp = temp.dalsi;
            index++;
        }
        return -1;
    }

    public void odstranVetsiPrvky(T prvek)
    {
        var temp = zacatek;
        if (temp == null)
        {
            throw new InvalidOperationException("Seznam je prazdny");
        }
        while (temp.hodn.CompareTo(prvek) > 0)
        {
            zacatek = zacatek.dalsi;
            temp = zacatek;
        }
        while (temp.dalsi != null)
        {
            if (temp.dalsi.hodn.CompareTo(prvek) > 0)
            {
                temp.dalsi = temp.dalsi.dalsi;
            }
            else
            {
                temp = temp.dalsi;
            }
        }
    }

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

    public void Obrat()
    {
        Uzel temp = zacatek;
        Uzel temp2 = null;
        Uzel temp3 = null;
        while (temp != null)
        {
            temp3 = temp2;
            temp2 = temp;
            temp = temp.dalsi;
            temp2.dalsi = temp3;
        }
        zacatek = temp2;
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

    public int PocetPrvku(T vstup)
    {
        return PocetPrvkuRekurzivne(koren, vstup);
    }

    private int PocetPrvkuRekurzivne(Uzel koren, T vstup)
    {
        if (koren == null)
        {
            return 0;
        }
        else
        {
            if (koren.hodn.CompareTo(vstup) == 0)
            {
                return 1 + PocetPrvkuRekurzivne(koren.levy, vstup) + PocetPrvkuRekurzivne(koren.pravy, vstup);
            }
            else
            {
                return PocetPrvkuRekurzivne(koren.levy, vstup) + PocetPrvkuRekurzivne(koren.pravy, vstup);
            }
        }
    }

    public int NodesWithChildCount(T childcount)
    {
        return NodesWithChildCountRekurzivne(koren, childcount);
    }

    private int NodesWithChildCountRekurzivne(Uzel koren, T childcount)
    {
        int pocet = 0;
        if (koren == null)
        {
            return 0;
        }
        else
        {
            if (koren.levy != null && koren.pravy != null)
            {
                pocet++;
            }
            return pocet + NodesWithChildCountRekurzivne(koren.levy, childcount) + NodesWithChildCountRekurzivne(koren.pravy, childcount);
        }
    }

    public bool isBalanced()
    {
        return isBalancedRekurzivne(koren);
    }

    private bool isBalancedRekurzivne(Uzel koren)
    {
        if (koren == null)
        {
            return true;
        }
        else
        {
            if (Math.Abs(PocetRekurzivne(koren.levy) - PocetRekurzivne(koren.pravy)) <= 1)
            {
                return isBalancedRekurzivne(koren.levy) && isBalancedRekurzivne(koren.pravy);
            }
            else
            {
                return false;
            }
        }
    }
}

//Úkol 11 - jak jsou implementované třídy
//a) Stack (LIFO)
//Jako array, lze i pomoci linked listu. LL je vhodnejsi. Operace pop a push (+ isempty), promenne - ukazatel na vrchol zasobniku a velikost zasobniku
//b) Queue (FIFO)
//Jako array nebo LL, operace enqueue a dequeue, promenne - ukazatel na prvni a posledni prvek fronty a velikost fronty
//c) Dictionary
//Jako array nebo LL, operace add, remove, contains. Props keys, values, count (+ comparer)

class Misc
{
    public SpojovySeznam<int> ConnectTwoLinkedLists(SpojovySeznam<int> list1, SpojovySeznam<int> list2)
    {
        //neserazeny :/
        SpojovySeznam<int> spojeny = new SpojovySeznam<int>();

        SpojovySeznam<int>.Uzel temp = list1.zacatek;
        while (temp != null)
        {
            spojeny.VlozNaKonec(temp.hodn);
            temp = temp.dalsi;
        }
        temp = list2.zacatek;
        while (temp != null)
        {
            spojeny.VlozNaKonec(temp.hodn);
            temp = temp.dalsi;
        }

        return spojeny;
    }
}