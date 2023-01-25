namespace Financiera_Futuro
{
    class Asis_Control
    {
        public string AgregaAsistencia(Asis_Encap an)
        {
            Asis_Encap modelo = new Asis_Encap();
            string respuesta = "";
            if (string.IsNullOrEmpty(an.Dni) || string.IsNullOrEmpty(an.Nom) || string.IsNullOrEmpty(an.Pat) || string.IsNullOrEmpty(an.Mat) || string.IsNullOrEmpty(an.Fec))
            {
                respuesta = "Debe llenar Todos los Registros";
            }
            else
            {
                modelo.Agregar(an);
            }
            return respuesta;
        }

        public string ModificaAsistencia(Asis_Encap an)
        {
            Asis_Encap modelo = new Asis_Encap();
            string respuesta = "";
            if (string.IsNullOrEmpty(an.Dni) || string.IsNullOrEmpty(an.Nom) || string.IsNullOrEmpty(an.Pat) || string.IsNullOrEmpty(an.Mat) || string.IsNullOrEmpty(an.Fec))
            {
                respuesta = "Seleccione el socio que desee Modificar";
            }
            else
            {
                modelo.Modificar(an);
            }
            return respuesta;
        }

        public string EliminaAsistencia(Asis_Encap an)
        {
            Asis_Encap modelo = new Asis_Encap();
            string respuesta = "";
            if (string.IsNullOrEmpty(an.Cod ))
            {
                respuesta = "Debe seleccionar una fila para eliminarla";
            }
            else
            {
                modelo.Eliminar(an);
            }
            return respuesta;
        }
    }
}