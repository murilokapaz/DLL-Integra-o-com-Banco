using System.Text;

namespace ConsoleApp1.Entities
{
    class Funcionario
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public int Quantidade { get; set; }
        public string Graduacao { get; set; }
        public string NomeDeGuerra { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Matrícula: {Matricula}");
            sb.AppendLine($"Quantidade: {Quantidade}");
            sb.AppendLine($"Graduação:{Graduacao}");
            sb.AppendLine($"Nome de Guerra:{NomeDeGuerra}");
            sb.AppendLine($"Nome:{Nome}");
            sb.AppendLine($"Ativo? {Ativo}");

            return sb.ToString();
        }
    }
}
