using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Alquiler
    {
        int nit;
        string placa;
        DateTime fAlquiler;
        DateTime fDevolucion;
        int kilometrosRe;
        int totalPago;

        public int Nit { get => nit; set => nit = value; }
        public string Placa { get => placa; set => placa = value; }
        public DateTime FAlquiler { get => fAlquiler; set => fAlquiler = value; }
        public DateTime FDevolucion { get => fDevolucion; set => fDevolucion = value; }
        public int KilometrosRe { get => kilometrosRe; set => kilometrosRe = value; }
        public int TotalPago { get => totalPago; set => totalPago = value; }
    }
}
