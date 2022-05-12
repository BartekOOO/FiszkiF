using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SQLite;
using System.IO;

namespace FiszkiF
{
    public class Tabelka_dodanych_slow
    {
        public string slowo_grid { get; set; }
        public string tlumaczenie_grid { get; set; }
        public Tabelka_dodanych_slow(string a, string b)
        {
            this.slowo_grid = a;
            this.tlumaczenie_grid = b;
        }

    }

    public class Tabelka_dodanych_zestawow
    {
        public string id { get; set; }
        public string nazwa_zestawu { get; set; }
        public Tabelka_dodanych_zestawow(string a, string b)
        {
            this.id = a;
            this.nazwa_zestawu = b;
        }

    }

    [Table("Zestaw")]
    public class Zestaw
    {
        [PrimaryKey, AutoIncrement]
        public int Id_zes { get; set; }

        [MaxLength(100)]
        public string Nazwa_zes { get; set; }
    }
    [Table("Fiszka")]
    public class Fiszka
    {
        [PrimaryKey, AutoIncrement]
        public int Id_fiszki { get; set; }

        [MaxLength(100)]
        public string Id_zestawu { get; set; }

        [MaxLength(100)]
        public string Slowo_fiszka { get; set; }

        [MaxLength(100)]
        public string Tlumaczenie_fiszka { get; set; }

    }


    


    class Zmienna
    {
        private static string globalne_id;

        public static string Id
        {
            get { return globalne_id; }
            set { globalne_id = value; }
        }

        private static ObservableCollection<Tabelka_dodanych_slow> fisz;
        public static ObservableCollection<Tabelka_dodanych_slow> Globalny_zestaw_fiszek
        {
            get { return fisz; }
            set { fisz = value; }
        }


    }
}

    
