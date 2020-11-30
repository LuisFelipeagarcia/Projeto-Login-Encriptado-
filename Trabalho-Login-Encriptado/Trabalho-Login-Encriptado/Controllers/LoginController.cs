using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Trabalho_Login_Encriptado.Context;
using Trabalho_Login_Encriptado.Models;

namespace Trabalho_Login_Encriptado.Controllers
{
    public class LoginController : Controller
    {
        private Contexto db = new Contexto();
        private static string AesIV256BD = @"%j?TmFP6$BbMnY$@";
        private static string AesKey256BD = @"rxmBUJy]&,;3jKwDTzf(cui$<nc2EQr)";
        // GET: Login

        #region Index
        public ActionResult Index(string? erro)
        {
            if (erro != null)
            {
                TempData["Error"] = erro;
            }
            return View();
        }
        #endregion

        #region Verificar
        [HttpPost]
        public ActionResult Verificar(UsuarioModel usuarioModel)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256BD);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256BD);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] src = Encoding.Unicode.GetBytes(usuarioModel.Email);
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                usuarioModel.Email = Convert.ToBase64String(dest);
            }

            UsuarioModel consulta = db.Usuarios.FirstOrDefault
                (u => u.Email == usuarioModel.Email);

            string erro = "Usuário ou Senha inválido";

            if (consulta == null)
            {
                return RedirectToAction(nameof(Index), new { @erro = erro });
            }

            if (BCrypt.Net.BCrypt.Verify(usuarioModel.Senha, consulta.Senha))
            {
                Session["Nome"] = consulta.Nome;
                Session["Nivel"] = consulta.Nivel;

                return RedirectToAction("Index", "Usuario");
            }
            return RedirectToAction(nameof(Index), new { @erro = erro });
        }
        #endregion
    }
}