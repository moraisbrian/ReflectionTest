using System;

namespace ReflectionTest
{
    [LimparCaracter]
    public class Funcionario
    {
        private static Funcionario _instance;
        private Funcionario()
        {
        }

        public static Funcionario GetInstance()
        {
            if (_instance == null)
                _instance = new Funcionario();
            return _instance;
        }

        public int Id { get; set; }
        public Nome Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public Cargo Cargo { get; set; }
        public string Informacoes { get; set; }
    }
}
