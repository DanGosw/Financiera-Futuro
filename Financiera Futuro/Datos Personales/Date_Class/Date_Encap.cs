using System.Drawing;

namespace Financiera_Futuro.Datos_Personales
{
    class Date_Encap
    {
        string cod, nom, pat, mat, dni, dir, tel, ema, tip;
        Image img;

        public string Cod { get => cod; set => cod = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Pat { get => pat; set => pat = value; }
        public string Mat { get => mat; set => mat = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Dir { get => dir; set => dir = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Ema { get => ema; set => ema = value; }
        public string Tip { get => tip; set => tip = value; }
        public Image Imge { get => img; set => img = value; }
    }
}
