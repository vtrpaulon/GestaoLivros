using GestaoLivros.Services;

namespace GestaoLivros.Menu;

public static class MenuHandler
{
   private static bool _sair;
    public static void Start()
    {
        
        while (!_sair)
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Buscar Autores");
            Console.WriteLine("2. Buscar Autor");
            Console.WriteLine("3. Adicionar Autor");
            Console.WriteLine("4. Excluir Autor");
            Console.WriteLine("\n-----------------------------------------------------\n");
            Console.WriteLine("5. Buscar Livros");
            Console.WriteLine("6. Buscar Livro");
            Console.WriteLine("7. Adicionar Livro");
            Console.WriteLine("8. Excluir Livro");
            Console.WriteLine("9. Sair");
            Console.Write("\nDigite sua opção: ");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    GetAuthors();
                    break;
                case "2":
                    GetAuthorById();
                    break;
                case "3":
                    AddAuthor();
                    break;
                case "4":
                    DeleteAuthor();
                    break;
                case "5":
                    GetBooks();
                    break;
                case "6":
                    GetBookById();
                    break;
                case "7":
                    AddBook();
                    break;
                case "8":
                    GetBooks();
                    break;
                case "9":
                    _sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    private static void GetAuthors()
    {
        AuthorsService.GetAuthors();
    }

    private static void GetAuthorById()
    {
        
        Console.Write("Insira o código do autor: ");
        var authorCode = Console.ReadLine();
        
        if (int.TryParse(authorCode,out int numericCode))
        {
            AuthorsService.GetAuthorById(numericCode);
            return;
        }


        GetAuthors();
    }

    private static void AddAuthor()
    {
        Console.Write("Insira o nome do autor: ");
        var name = Console.ReadLine();
        
        
        AuthorsService.AddAuthor(name);
        
        AuthorsService.GetAuthors();
    }

    private static void DeleteAuthor()
    {
        Console.Write("Insira o código do autor: ");
        var id = Console.ReadLine();
        
        if (int.TryParse(id,out int numericId))
        {
            AuthorsService.DeleteAuthor(numericId);
        }
        
        GetAuthors();
    }

    private static void GetBooks()
    {
        BooksService.GetBooks();
    }

    private static void GetBookById()
    {
        Console.Write("Insira o código do livro: ");
        var id = Console.ReadLine();
        
        if (int.TryParse(id,out int numericId))
        {
            BooksService.GetBookById(numericId);
        }
    }

    private static void AddBook()
    {
        Console.Write("Insira o código do Autor do livro: ");
        var id = Console.ReadLine();
        
        if (int.TryParse(id,out int numericId))
        {
            Console.Write("Insira o título do livro: ");
            var title = Console.ReadLine();
            
            Console.Write("Insira o ano de publicação do livro: ");
            var year = Console.ReadLine();

            if (int.TryParse(year, out int numericYear))
            {
                BooksService.AddBook(numericId, title, numericYear );
                
                GetBooks();
            }
        }
    }
}