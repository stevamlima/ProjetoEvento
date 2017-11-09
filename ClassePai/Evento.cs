using System;
namespace ProjetoEvento.ClassePai
{
    public abstract class Evento
    {
        public string Local { get; set; }
        public int Lotacao { get; set; }
        public DateTime Data { get; set; }
        public string Duracao { get; set; }
        public string Classificacao { get; set; }
        public string Titulo { get; set; }




        public virtual bool Cadastrar()
        {
            return false;
        }
        public virtual string Pesquisar(DateTime DataEvento)
        {
            return null;
        }
        public virtual string Pesquisar(string TituloEvento)
        {
            return null;
        }
    }
}