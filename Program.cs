using System;
using System.IO;
using System.Linq;

namespace SistemaLoginTxt
{
    public class Program
    {
        public static void Main()
        {
            string opcao = "";
            string caminhoArquivo = "usuarios.txt";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL ===\n");
                Console.WriteLine("[1] Login");
                Console.WriteLine("[2] Cadastrar");
                Console.WriteLine("[3] Sair");
                Console.Write("\nEscolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FazerLogin(caminhoArquivo);
                        break;
                    case "2":
                        CadastrarUsuario(caminhoArquivo);
                        break;
                    case "3":
                        Console.WriteLine("\nEncerrando o sistema...");
                        Console.WriteLine("Pressione qualquer tecla para sair.");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("\n❌ Opção inválida! Pressione qualquer tecla.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void CadastrarUsuario(string caminho)
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRO DE USUÁRIO ===\n");

            Console.Write("Nome do novo usuário: ");
            string user = Console.ReadLine();

            Console.Write("Senha do novo usuário: ");
            string senha = Console.ReadLine();

            // Verifica se o usuário já existe
            if (File.Exists(caminho))
            {
                var linhas = File.ReadAllLines(caminho);
                if (linhas.Any(l => l.Split('|')[0] == user))
                {
                    Console.WriteLine("\n⚠️ Usuário já cadastrado!");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                    return;
                }
            }

            // Salva no arquivo no formato: usuario|senha
            File.AppendAllText(caminho, $"{user}|{senha}\n");
            Console.WriteLine("\n✅ Usuário cadastrado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }

        static void FazerLogin(string caminho)
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN ===\n");

            Console.Write("Usuário: ");
            string user = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            if (!File.Exists(caminho))
            {
                Console.WriteLine("\n⚠️ Nenhum usuário cadastrado ainda.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                Console.ReadKey();
                return;
            }

            var linhas = File.ReadAllLines(caminho);
            bool encontrado = linhas.Any(l =>
            {
                var partes = l.Split('|');
                return partes[0] == user && partes[1] == senha;
            });

            if (encontrado)
            {
                Console.WriteLine("\n✅ Login bem-sucedido!");
            }
            else
            {
                Console.WriteLine("\n❌ Usuário ou senha incorretos.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");

            Console.ReadKey();
        }
    }
}
