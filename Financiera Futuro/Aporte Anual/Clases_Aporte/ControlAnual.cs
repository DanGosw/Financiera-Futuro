
namespace Financiera_Futuro
{
    class ControlAnual
    {
        public string AgregaAporte(AnualEncap an, string socio, string esta)
        {
            Mod_Metodos modelo = new Mod_Metodos();
            string respuesta = "";

            if (string.IsNullOrEmpty(socio))
            {
                respuesta = "Debe llenar el codigo del Socio";
            }
            else
            {
                modelo.registro(an, socio, esta);
            }
            return respuesta;
        }

        public string ModificaAporte(AnualEncap an, string socio, string esta)
        {
            Mod_Metodos modelo = new Mod_Metodos();
            modelo.modificar(an, socio, esta);
            string respuesta = "";
            if (string.IsNullOrEmpty(socio))
            {
                respuesta = "Seleccione el socio que desee Modificar";
            }
            else
            {
                modelo.modificar(an, socio, esta);
            }
            return respuesta;
        }
        public string EliminaAporte(AnualEncap an)
        {
            Mod_Metodos modelo = new Mod_Metodos();
            string respuesta = "";

            if (string.IsNullOrEmpty(an.Codig))
            {
                respuesta = "Debe seleccionar una fila para eliminarla";
            }
            else
            {
                modelo.eliminar(an);
            }
            return respuesta;
        }
    }
}