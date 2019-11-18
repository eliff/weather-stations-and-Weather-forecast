using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAVA1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, İSTASYON> istasyonlar = new Dictionary<int, İSTASYON>();


            StreamReader okuyucu;
            try
            {
                okuyucu = new StreamReader("istasyonlar.csv.csv");
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("Dosya bulunamadi: " + fnfe.FileName);
                Console.Read();
                return;
            }

            okuyucu.ReadLine(); // ilk satiri atla

            İSTASYON yeniIstasyon;

            string birsatir = okuyucu.ReadLine();
            while (birsatir != null)
            {
                string[] alanlar = birsatir.Split(';');
                if (alanlar[0] != "")
                {
                    yeniIstasyon = new İSTASYON(
                        int.Parse(alanlar[0]),
                        alanlar[1],
                        alanlar[2],
                        alanlar[3],
                        alanlar[4],
                        alanlar[5],
                        alanlar[6]
                        );

                    //Console.WriteLine(yeniIstasyon.ToString());
                    try
                    {
                        istasyonlar.Add(yeniIstasyon.IstasyonNo, yeniIstasyon);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(yeniIstasyon.IstasyonNo + "nolu istasyon bulunamadı");
                    }
                }
                birsatir = okuyucu.ReadLine();
            }
            okuyucu.Close();
            int istasyonno = 17430;
            try
            {
                İSTASYON ist = istasyonlar[istasyonno];
                Console.WriteLine(ist.ToString());
            }
            catch (KeyNotFoundException knfe)
            {
                Console.WriteLine(istasyonno + "nolu istasyon bulunamadı.");
            }
            SortedSet<string> şehirler = new SortedSet<string>();


            foreach (İSTASYON ist in istasyonlar.Values)
            {
                şehirler.Add(ist.İl1);
            }
            foreach (var item in şehirler)
            {
                Console.WriteLine(item);
            }
            HashSet<string> ICAO = new HashSet<string>();
            Console.WriteLine("\n----ICAO----\n");
            foreach (İSTASYON s in istasyonlar.Values)
            {
                ICAO.Add(s.ICAO1);
            }
            foreach (var item in ICAO)
            {
                Console.WriteLine(item);
            }

            HashSet<string> gözlemgrubu = new HashSet<string>();
            Console.WriteLine("\n----gözlemgrubu----\n");
            foreach (İSTASYON s in istasyonlar.Values)
            {
                gözlemgrubu.Add(s.Gözlemgrubu1);
            }
            foreach (var item in gözlemgrubu)
            {
                Console.WriteLine(item);
            }

            HashSet<string> gözlemtürü = new HashSet<string>();
            Console.WriteLine("\n----gözlemtürü----\n");
            foreach (İSTASYON s in istasyonlar.Values)
            {
                gözlemtürü.Add(s.Gözlemtürü1);
            }
            foreach (var item in gözlemtürü)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n--- İstanbul İlçeleri ---");
            HashSet<string> İlçeler = new HashSet<string>();
            foreach (İSTASYON ist in istasyonlar.Values)
            {
                if (ist.İl1 == "İSTANBUL")
                    İlçeler.Add(ist.İlçe1);
            }

            foreach (var item in İlçeler)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n--- Tokatın İstasyonları---");
            List<İSTASYON> ilİstasyonları = new List<İSTASYON>();
            foreach (İSTASYON ist in istasyonlar.Values)
            {
                if (ist.İl1 == "TOKAT")
                    ilİstasyonları.Add(ist);
            }
            ilİstasyonları.ForEach(ist => Console.WriteLine(ist.ToString()));
            Console.WriteLine("\n--- Ada Göre Sıralanmış İstasyonlar---");
            List<İSTASYON> istListe = new List<İSTASYON>();
            foreach (İSTASYON ist in istasyonlar.Values)
            {
                istListe.Add(ist);
            }

            istListe.Sort();


            foreach (İSTASYON ist in istListe)
            {
                Console.WriteLine(ist.ToString());
            }

            List<Durum> havadurumu = new List<Durum>();

            StreamReader okuyucu1;
            try
            {
                okuyucu1 = new StreamReader("istanbulhava.csv.csv");
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("Dosya bulunamadi: " + fnfe.FileName);
                Console.Read();
                return;
            }
            okuyucu1.ReadLine();

            Durum yenihavadurumu;
            int i = 0;
            DateTimeFormatInfo fmt = new CultureInfo("tr-tr").DateTimeFormat;

            string birsatır1 = okuyucu1.ReadLine();
            while (birsatır1 != null)
            {
                string[] alanlar = birsatır1.Split(';');
                try
                {
                    yenihavadurumu = new Durum()
                    {
                        Zaman = DateTime.Parse(alanlar[0], fmt),
                        T=Convert.ToDouble(alanlar[1]),
                        Po= Convert.ToDouble(alanlar[2]),
                        P = Convert.ToDouble(alanlar[3]),
                        Pa = Convert.ToDouble(alanlar[4]),
                        U = Convert.ToDouble(alanlar[5]),
                        Dd =alanlar[6]
                    };
                    havadurumu.Add(yenihavadurumu);
                }
                catch(FormatException fe)
                {
                    i++;
                    Console.WriteLine(i + ":" + fe.Message);
                }
                           
            }
            okuyucu1.Close();
            havadurumu.ForEach(h => Console.WriteLine(h.P));



            string zamanstr = "03.04.2019 03:00:00";
            DateTime zaman = DateTime.Parse(zamanstr,fmt);

            //Durum aranandurum = havadurumu.Find(Durum => Durum.Zaman == zaman);
            Durum aranandurum = null;
            foreach(var d in havadurumu)
            {
                if (d.Zaman == zaman)
                {
                    aranandurum = d;
                    break;
                }
            }
            if (aranandurum != null)
            {
                Console.WriteLine(aranandurum.Zaman.ToString(fmt) + "" + aranandurum.T + "" + aranandurum.Dd);
            }


            DateTime başlangıç = DateTime.Parse("15.02.2019 00:00:00", fmt);
            DateTime bitiş = DateTime.Parse("15.03.2019 00:00:00", fmt);

            List<Durum> filtrelenmişhavadurumu = new List<Durum>();

            foreach(var item in filtrelenmişhavadurumu)
            {
                Console.WriteLine(item.Zaman.ToString(fmt) + "" + item.T + "" + item.Dd);
            }

           

            Console.WriteLine("min t=" + havadurumu.Min(hd => hd.T));
            Console.WriteLine("min p=" + havadurumu.Min(hd => hd.P));

            List<double> İLİST = new List<double>();
            foreach(var hd in havadurumu)
            {
                İLİST.Add(hd.T);
            }
            Console.Read();
        }




    }
}
