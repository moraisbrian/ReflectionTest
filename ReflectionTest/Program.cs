using System;
using System.Linq;
using System.Reflection;

namespace ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var funcionario = ObterFuncionarioPorId(30);
            Limpar(funcionario);

            Console.ReadKey();
        }

        private static Funcionario ObterFuncionarioPorId(int id)
        {
            var funcionario = Funcionario.GetInstance();
            funcionario.Id = id;
            funcionario.Nome = Nome.GetInstance();
            funcionario.Nome.PrimeiroNome = "Fulano";
            funcionario.Nome.Sobrenome = "Ciclano";
            funcionario.Nascimento = DateTime.Now.AddYears(-30);
            funcionario.Cargo = Cargo.GetInstance();
            funcionario.Cargo.Id = 20;
            funcionario.Cargo.Identificacao = "Funileiro";
            funcionario.Cargo.Setor = Setor.GetInstance();
            funcionario.Cargo.Setor.Id = 2;
            funcionario.Cargo.Setor.Identificacao = "Funilaria";
            funcionario.Informacoes = "teste 123 testando de novo xpto!!!";
            funcionario.Cargo.Setor.Empresa = Empresa.GetInstance();
            funcionario.Cargo.Setor.Empresa.Id = 30;
            funcionario.Cargo.Setor.Empresa.Identificacao = "Empresa S.A.";
            
            return funcionario;
        }

        private static void Limpar(object obj)
        {
            var type = obj.GetType();
            
            foreach (var prop in type.GetProperties())
            {
                VerificarFilhos(prop, obj);
            }
        }

        private static void VerificarFilhos(PropertyInfo prop, object obj)
        {
            if (prop.PropertyType.GetCustomAttributes<LimparCaracterAttribute>().Any())
            {
                foreach (var child in prop.PropertyType.GetProperties())
                {
                    var instance = child.ReflectedType.GetMethod("GetInstance")
                        .Invoke(child.ReflectedType, new object[0]);
                    
                    VerificarFilhos(child, instance);
                }
            }
            else
            {
                var valor = prop.GetValue(obj, null);
                var novoValor = TrocarChar(valor);
                prop.SetValue(obj, novoValor);
                Console.WriteLine($"Tipo: {prop.ReflectedType.Name} - Propriedade: {prop.Name} - Valor: {prop.GetValue(obj, null)}");
            }
        }
        
        private static object TrocarChar(object obj)
        {
            if (obj.GetType() == typeof(string))
            {
                return obj.ToString()
                    .Replace(">", "&gt;")
                    .Replace("<", "&lt;")
                    .Replace("&", "&amp;")
                    .Replace("\"", "&quot;")
                    .Replace("\'", "&apos;");
            }

            return obj;
        }
    }
}
