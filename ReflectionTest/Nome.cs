namespace ReflectionTest
{
    [LimparCaracter]
    public class Nome
    {
        private static Nome _instance;
        private Nome()
        {
        }

        public static Nome GetInstance()
        {
            if (_instance == null)
                _instance = new Nome();
            return _instance;
        }

        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
    }
}

