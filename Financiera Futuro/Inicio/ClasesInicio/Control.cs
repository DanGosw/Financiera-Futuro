using System.Security.Cryptography;
using System.Text;

namespace Financiera_Futuro
{
    class Control
    {
        public string ctrlRegistro(Usuarios usuario, byte[] aByte)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.Nom) || string.IsNullOrEmpty(usuario.Ema) || string.IsNullOrEmpty(usuario.Pas))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                if (usuario.Pas == usuario.Pas)
                {
                    if (modelo.existeUsuario(usuario.Nom))
                    {
                        respuesta = "El usuario ya existe";
                    }
                    else
                    {
                        usuario.Pas = generarSHA1(usuario.Pas);
                        modelo.registro(usuario, aByte);
                    }
                }
            }
            return respuesta;
        }

        public string modificarusuarios(Usuarios usuario, byte[] im)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.Nom) || string.IsNullOrEmpty(usuario.Ema) || string.IsNullOrEmpty(usuario.Pas))
            {
                respuesta = "Debe llenar todos los campos";
            }
                if (usuario.Pas == usuario.Pas)
                {
                    usuario.Pas = generarSHA1(usuario.Pas);
                    modelo.modificar(usuario,im);
                }
                else
                {
                    respuesta = "Las contraseña no coinciden";
                }
            return respuesta;
        }

        public string ctrlLogin(string usuario,string email, string password)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            Usuarios datosUsuario = null;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                datosUsuario = modelo.porUsuario(usuario);

                if (datosUsuario == null)
                {
                    respuesta = "El usuario no existe";
                }
                else
                {
                    if (datosUsuario.Pas != generarSHA1(password))
                    {
                        respuesta = "El usuario y/o contraseña no coinciden";                     
                    }
                    else
                    {
                        Session.cod = datosUsuario.Cod;                        
                        Session.usuario = usuario;
                        Session.email = datosUsuario.Ema;
                        Session.tipo = datosUsuario.Tip;
                    }
                }
            }
            return respuesta;
         }

        private string generarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString();
        }
    }
}