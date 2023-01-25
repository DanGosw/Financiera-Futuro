
namespace Financiera_Futuro
{
    class Presta_Control
    {
        public string AgregaPrestamo(Presta_Encap an)
        {
            Presta_Encap modelo = new Presta_Encap();
            string respuesta = "";

            if (string.IsNullOrWhiteSpace(an.Socio) || string.IsNullOrWhiteSpace(an.Datso) || string.IsNullOrWhiteSpace(an.Fecap) 
             || string.IsNullOrWhiteSpace(an.Amort) || string.IsNullOrWhiteSpace(an.Nrota) || string.IsNullOrWhiteSpace(an.Aport)
             || string.IsNullOrWhiteSpace(an.Preot) || string.IsNullOrWhiteSpace(an.Cuota) || string.IsNullOrWhiteSpace(an.Intge) 
             || string.IsNullOrWhiteSpace(an.Cuoex) || string.IsNullOrWhiteSpace(an.Ndocs))
            {
                respuesta = "Debe llenar Todos los Registros";
            }
            else
            {
                modelo.Agregar(an);
            }
            return respuesta;
        }
    }
}