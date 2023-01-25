namespace Financiera_Futuro
{
    class Crono_control
    {
        public string AgregaCronoGrama(Crono_Encap an)
        {
            Crono_Encap modelo = new Crono_Encap();
            string respuesta = "";
            if (string.IsNullOrEmpty(an.Soci) || string.IsNullOrEmpty(an.NomS) || string.IsNullOrEmpty(an.Fech) || string.IsNullOrEmpty(an.Amor) || string.IsNullOrEmpty(an.Inte) || string.IsNullOrEmpty(an.Tota) || string.IsNullOrEmpty(an.Obse) || string.IsNullOrEmpty(an.Mult) || string.IsNullOrEmpty(an.Nodo) || string.IsNullOrEmpty(an.Cuot))
            {
                respuesta = "Debe llenar Todos los Registros";
            }
            else
            {
                modelo.Agregar(an);
            }
            return respuesta;
        }

        public string ModificaCronoGrama(Crono_Encap an)
        {
            Crono_Encap modelo = new Crono_Encap();
            string respuesta = "";
            if (string.IsNullOrEmpty(an.Soci) || string.IsNullOrEmpty(an.NomS) || string.IsNullOrEmpty(an.Fech) || string.IsNullOrEmpty(an.Amor) || string.IsNullOrEmpty(an.Inte) || string.IsNullOrEmpty(an.Tota) || string.IsNullOrEmpty(an.Obse) || string.IsNullOrEmpty(an.Mult) || string.IsNullOrEmpty(an.Cuot))
            {
                respuesta = "Seleccione el socio que desee Modificar";
            }
            else
            {
                modelo.Modificar(an);
            }
            return respuesta;
        }

        public string EliminaCronoGrama(Crono_Encap an)
        {
            Crono_Encap modelo = new Crono_Encap();
            string respuesta = "";
            if (string.IsNullOrEmpty(an.Codi))
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