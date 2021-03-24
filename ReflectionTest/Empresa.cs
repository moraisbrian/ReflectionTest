namespace ReflectionTest
{
    [LimparCaracter]
    public class Empresa
    {
        private static Empresa _instance;

        private Empresa()
        {
        }

        public static Empresa GetInstance()
        {
            if (_instance == null)
                _instance = new Empresa();
            return _instance;
        }

        public int Id { get; set; }
        public string Identificacao { get; set; }
    }
}
