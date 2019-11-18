using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAVA1
{

    class İSTASYON :IComparable
    {
        private int istasyonNo;
        private string ICAO;
        private string İl;
        private string İlçe;
        private string İstasyonadı;
        private string Gözlemgrubu;
        private string Gözlemtürü;
        

        public İSTASYON(int istasyonNo, string ıCAO, string il, string ilçe, string istasyonadı, string gözlemgrubu, string gözlemtürü)
        {
            this.istasyonNo = istasyonNo;
            ICAO = ıCAO;
            this.İl = il;
            this.İlçe = ilçe;
            this.İstasyonadı = istasyonadı;
            this.Gözlemgrubu = gözlemgrubu;
            this.Gözlemtürü = gözlemtürü;
           
        }

        public int IstasyonNo { get => istasyonNo; set => istasyonNo = value; }
        public string ICAO1 { get => ICAO; set => ICAO = value; }
        public string İl1 { get => İl; set => İl = value; }
        public string İlçe1 { get => İlçe; set => İlçe = value; }
        public string İstasyonadı1 { get => İstasyonadı; set => İstasyonadı = value; }
        public string Gözlemgrubu1 { get => Gözlemgrubu; set => Gözlemgrubu = value; }
        public string Gözlemtürü1 { get => Gözlemtürü; set => Gözlemtürü = value; }

        
        public int CompareTo(object obj)
        {
            İSTASYON ist = (İSTASYON)obj;
            return this.İstasyonadı.CompareTo(ist.İstasyonadı);
        }

        public override string ToString()
        {
            return istasyonNo + "" + İstasyonadı + "" + ICAO + "" + İl + "" + İlçe + "" + Gözlemgrubu + "" + Gözlemtürü;
        }
      

    }
    
        

    
} 
