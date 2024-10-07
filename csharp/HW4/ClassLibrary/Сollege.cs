namespace ClassLibrary;

public struct Contacts
{
    public string Address { get; }
    public string Okrug { get; }
    public string Rayon { get; }
    public string Telephone { get; }
    public string WebSite { get; }
    public string EMail { get; }
    
    public Contacts(string[] data)
    {
        Address = data[0];
        Okrug = data[1];
        Rayon = data[2];
        Telephone = data[3];
        WebSite = data[4];
        EMail = data[5];
    }
}

public class Сollege : IComparable<ClassLibrary.Сollege>
{
    public string Rownum { get; }
    public string Name { get; }
    public string FormOfIncorporation { get; }
    public string Submission { get; }
    public string TipUcherezhdeniya { get; }
    public string VidUcherezhdeniya { get; }
    public string X { get; }
    public string Y { get; }
    public string GlobalId { get; }

    public Contacts Contacts { get; }
    
    public Сollege(string[] info)
    {
        Rownum = info[0];
        Name = info[1];
        FormOfIncorporation = info[5];
        Submission = info[6];
        TipUcherezhdeniya = info[7];
        VidUcherezhdeniya = info[8];
        X = info[12];
        Y = info[13];
        GlobalId = info[14];
        Contacts = new Contacts(new string[] { info[2], info[3], info[4], info[9], info[10], info[11] });
    }

    public int CompareTo(Сollege? other)
    {
        // При сравнении не учитываем слово "район", т.к. в некоторых строках оно стоит перед названием района и путает сортировку.
        return String.Compare(Contacts.Rayon.Replace("район", "").Trim(),
            other.Contacts.Rayon.Replace("район", "").Trim(), StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return $"{Rownum};\"{Name}\";\"{Contacts.Address}\";\"{Contacts.Okrug}\";\"{Contacts.Rayon}\";\"{FormOfIncorporation}\";\""+
               $"{Submission}\";\"{TipUcherezhdeniya}\";\"{VidUcherezhdeniya}\";\"{Contacts.Telephone}\";\"{Contacts.WebSite}\";\""+
               $"{Contacts.EMail}\";\"{X}\";\"{Y}\";\"{GlobalId}\";";
    }
    public string ToString(string sep)
    {
        return $"{Rownum}{sep}{Name}{sep}{Contacts.Address}{sep}{Contacts.Okrug}{sep}{Contacts.Rayon}{sep}{FormOfIncorporation}{sep}"+
                $"{Submission}{sep}{TipUcherezhdeniya}{sep}{VidUcherezhdeniya}{sep}{Contacts.Telephone}{sep}{Contacts.WebSite}{sep}"+
                $"{Contacts.EMail}{sep}{X}{sep}{Y}{sep}{GlobalId}{sep}";
    }
}