using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unify.Budgets.Application.DTOs;
using Unify.Budgets.Domain.Entities;

namespace Unify.Budgets.Application.Services
{
    public class LoginService
    {
        //private readonly CrudService<Usuario> _usuario;
        //public LoginService(CrudService<Usuario> usuario)
        //{
        //    _usuario = usuario;
        //}

        //public ResultDTO<Usuario> Login(string email, string senha)
        //{
        //    var user = _usuario.Query().FirstOrDefault(x => x.Email == email);

        //    if (user == null)
        //        return new ResultDTO<Usuario>() { Success = false, Mensagem = "Usuário ou senha inválidos!" };


        //    var result = SecurityService.ValidarSenha(senha, user.SenhaHash, user.SenhaSalt);

        //    if (!result)
        //        return new ResultDTO<Usuario>() { Success = false, Mensagem = "Usuário ou senha inválidos!" };

        //    return new ResultDTO<Usuario>() { Success = true, Data = user };
        //}
    }
}
