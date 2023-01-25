namespace Financiera_Futuro.Datos_Personales
{
    class Date_Control
    {
        public string Agrega(Date_Encap dat, string tipo, byte[] bit)
        {
            Date_Metod modelo = new Date_Metod();
            string respuesta = "";
            if (string.IsNullOrEmpty(dat.Nom) || string.IsNullOrEmpty(dat.Pat) || string.IsNullOrEmpty(dat.Mat) || string.IsNullOrEmpty(dat.Dni) || string.IsNullOrEmpty(dat.Tel) || string.IsNullOrEmpty(dat.Ema))
            {
                respuesta = "Debe llenar los campos, en caso de no haber los datos suficientes, solo escriba ''none''";
            }
            else
            {
                modelo.Agregar(dat, tipo, bit);
            }
            return respuesta;
        }

        public string Modifica(Date_Encap dat, string tipo, byte[] bit)
        {
            Date_Metod modelo = new Date_Metod();
            string respuesta = "";
            if (string.IsNullOrEmpty(dat.Cod) || (string.IsNullOrEmpty(dat.Nom) || string.IsNullOrEmpty(dat.Pat) || string.IsNullOrEmpty(dat.Mat) || string.IsNullOrEmpty(dat.Dni) || string.IsNullOrEmpty(dat.Tel) || string.IsNullOrEmpty(dat.Ema)))
            {
                respuesta = "Llene los campos a modificar desee Modificar";
            }
            else
            {
                modelo.Modificar(dat, tipo, bit);
            }
            return respuesta;
        }

        public string Elimina(Date_Encap dat)
        {
            Date_Metod modelo = new Date_Metod();
            string respuesta = "";
            if (string.IsNullOrEmpty(dat.Cod))
            {
                respuesta = "Debe seleccionar una fila para eliminarla";
            }
            else
            {
                modelo.Eliminar(dat);
            }
            return respuesta;
        }
    }
}