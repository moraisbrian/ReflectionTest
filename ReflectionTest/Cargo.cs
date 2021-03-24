namespace ReflectionTest
{
    [LimparCaracter]
    public class Cargo
    {
        private static Cargo _instance;

        private Cargo()
        {
        }

        public static Cargo GetInstance()
        {
            if (_instance == null)
                _instance = new Cargo();
            return _instance;
        }

        public int Id { get; set; }
        public string Identificacao { get; set; }
        public Setor Setor { get; set; }
    }
}
