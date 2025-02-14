using DAL.Repositorys;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UserBLL
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<User> GetUsuarioConPsicologo(int id)
        {
            return _usuarioRepository.GetByIdAsync(id);
        }
    }
}
