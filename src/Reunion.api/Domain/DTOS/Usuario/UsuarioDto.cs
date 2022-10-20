namespace Reunion.api.Domain.DTOS.Usuario
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }

        public static explicit operator UsuarioDto(Entities.Usuario usuarioEntity)
        {
            return new UsuarioDto
            {
                Id = usuarioEntity.Id,
                Email = usuarioEntity.Email,
                Nome = usuarioEntity.Nome,
                Sobrenome = usuarioEntity.Nome,
            };
        }
    }
}