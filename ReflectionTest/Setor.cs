namespace ReflectionTest
{
    [LimparCaracter]
    public class Setor
    {
        private static Setor _instance;

        private Setor()
        {
        }

        public static Setor GetInstance()
        {
            if (_instance == null)
                _instance = new Setor();
            return _instance;
        }

        public int Id { get; set; }
        public string Identificacao { get; set; }
        public Empresa Empresa { get; set; }
    }
}
