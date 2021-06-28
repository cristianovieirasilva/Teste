using System;

namespace Classificados.Comum.Util
{
    public static class Senha
    {
        /// <summary>
        /// Metodo que criptografa a senha
        /// </summary>
        /// <param name="senha">retorna a senha criptografada</param>
        /// <returns></returns>
        public static string Criptografar(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }
        /// <summary>
        /// Verifica se a senha foi criptografada
        /// </summary>
        /// <param name="senha">retorna a senha</param>
        /// <param name="hashPassword">retorna a senha criptografada</param>
        /// <returns></returns>
        public static bool Validar(string senha, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hashPassword);
        }
        /// <summary>
        /// Gera uma senha
        /// </summary>
        /// <returns>Retorna a senha</returns>
        public static string Gerar()
        {
            string caracteres = "abcdefghjkmnpqrstuvwxyz023456789@!#$%&*";
            string senha = "";
            Random random = new Random();
            for (int f = 0; f < 8; f++)
            {
                senha = senha + caracteres.Substring(random.Next(0, caracteres.Length - 1), 1);
            }
            return senha;
        }
    }
}
