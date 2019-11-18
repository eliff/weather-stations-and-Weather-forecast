using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAVA1
{
    class Durum
    {
        private DateTime zaman;
        private double t;
        private double po;
        private double p;
        private double u;//nem
        private double pa;
        private string dd;

        public Durum()
        {
        }

        public Durum(DateTime zaman, double t, double po, double p, double u,double pa, string dd)
        {
            this.zaman = zaman;
            this.t = t;
            this.po = po;
            this.p = p;
            this.u = u;
            this.dd = dd;
            this.pa = pa;
        }

        public DateTime Zaman { get => zaman; set => zaman = value; }
        public double T { get => t; set => t = value; }
        public double Po { get => po; set => po = value; }
        public double P { get => p; set => p = value; }
        public double U { get => u; set => u = value; }
        public string Dd { get => dd; set => dd = value; }
        public double Pa { get => pa; set => pa = value; }

        public override string ToString()
        {
            return zaman + "" + t + "" + po + "" + p + "" + u + "" + pa +""+ dd;

        }
    }
}
