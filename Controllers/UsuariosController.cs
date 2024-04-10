using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteProjetoLojaAPI.Data;
using TesteProjetoLojaAPI.Models;

namespace TesteProjetoLojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("BuscarUsuario/{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // POST: api/Usuarios
        [HttpPost("AdicionarUsuario")]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut("AtualizarUsuario/{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("ExcluirUsuario/{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
        // POST: api/Usuarios/Login
        [HttpPost("Login")]
        public async Task<ActionResult<Usuario>> Login(LoginRequest loginRequest)
        {
            // Encontre o usuário pelo email (suponha que o email é único)
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            // Verifique se a senha está correta
            if (!VerifyPassword(usuario, loginRequest.Senha))
            {
                return Unauthorized("Credenciais inválidas");
            }

            // Usuário autenticado com sucesso
            return Ok(usuario);
        }

        // Método auxiliar para verificar a senha
        private bool VerifyPassword(Usuario usuario, string senha)
        {
            // Implemente a lógica de verificação da senha aqui
            // Por exemplo, compare a senha fornecida com a senha armazenada
            return usuario.Senha == senha;
        }
    }
}

