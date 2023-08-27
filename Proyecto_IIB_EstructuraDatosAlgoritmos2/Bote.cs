using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    public class Bote
    {
        public int NumeroEmbarcadero { get; }
        public int PosicionOriginalLeft { get; }
        public int PosicionOriginalTop { get; }
        public PictureBox PBBote { get; }

        public Bote(int numeroEmbarcadero, int posicionOriginalLeft, int posicionOriginalTop, PictureBox pbBote)
        {
            NumeroEmbarcadero = numeroEmbarcadero;
            PosicionOriginalLeft = posicionOriginalLeft;
            PosicionOriginalTop = posicionOriginalTop;
            PBBote = pbBote;
        }

        public void RestaurarPosicion()
        {
            PBBote.Left = PosicionOriginalLeft;
            PBBote.Top = PosicionOriginalTop;
        }
    }
}
