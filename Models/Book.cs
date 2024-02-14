using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoLivros.Models
{
    internal class Book
    {
        private int _id;
        private string _titulo;
        private string _autor;
        private int _anoPublicacao;
        
        public Book(string titulo, string autor, int anoPublicacao) { 
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
        }

        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Autor { get => _autor; set => _autor = value; }
        public int AnoPublicacao { get => _anoPublicacao; set => _anoPublicacao = value; }


        public new string ToString()
        {
            return $"Id: {Id} - Título: {Titulo} - Autor: {Autor} - Ano de publicação: {AnoPublicacao}";
        }
    }
}
