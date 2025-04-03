using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.DTO.Cadastros
{
    public class LancamentoDTO
    {
        [Required]
        public int CodigoMaquina { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
