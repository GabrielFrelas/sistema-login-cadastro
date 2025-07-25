using System;
using System.ComponentModel.Design;
using System.Linq;

namespace Cadastro;

public class Program
{
    public static void Main()
    {
        string option = "";

        while (true)
        {
            Console.Clear();
            
            Console.WriteLine("=== Menu Principal ===");
            Console.WriteLine("[1] Login");
            Console.WriteLine("[2] Cadastrar");
            Console.WriteLine("[3] Sair");
            Console.Write("\nEscolha uma opção: ");

            option = Console.ReadLine();


            switch (option)
            {
                case "1":
                    FazerLogin();
                    break;

                case "2":
                    CadastrarUsuario();
                    break;

                case "3":
                    Console.WriteLine("\nEncerrando o Sitema.");
                    Console.WriteLine("\nPressione qualquer tecla para fechar");
                    Console.ReadKey();
                    return;

                default:
                    Console.WriteLine("\nOpção Inválida. Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    break;

            }
        }

        static void FazerLogin()
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN ===\n");
            
            Console.Write("Usuário: ");
            string user = Console.ReadLine();
            
            Console.Write("Senha: ");
            string password = Console.ReadLine();

            if (user == "admin" && password == "123")
            {
                Console.WriteLine("\nLogin Bem-sucedido!");
            }

            else
            {
                Console.WriteLine("\nUsuário ou Senha Incorretos.");
                
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        static void CadastrarUsuario()
        {
            Console.Clear();
            Console.WriteLine("\n=== CADASTRO DE USUÁRIO ===\n");
            
            Console.Write("Nome do novo usuário: ");
            string newUser = Console.ReadLine();
            
            
            Console.Write("Senha do novo usuário: ");
            string novaSenha = Console.ReadLine();
            
            Console.WriteLine($"\nUsuário '{newUser}' Cadastrado com sucesso!");
            
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();




        }
    }
}