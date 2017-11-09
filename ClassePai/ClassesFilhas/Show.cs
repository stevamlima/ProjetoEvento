using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Show:Evento //faz herança com a classe pai(chamada Evento)
    {
        public string Artista { get; set; }
        public string GeneroMusical { get; set; }


        public Show()
        {
            
        }

        public Show(string Titulo, string Local, int Lotacao, string Duracao, string Classificacao, DateTime Data, string Artista, string GeneroMusical)
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            base.Data = Data;
            this.Artista = Artista;
            this.GeneroMusical = GeneroMusical;
            
        }

        public override bool Cadastrar() //método para cadastrar o EVENTO
        {
            bool efetuado = false;
            StreamWriter arquivo = null;

            try
            {
                arquivo = new StreamWriter("Show.csv", true); 
                arquivo.WriteLine(Titulo+";"+Local+";"+Lotacao+";"+Duracao+";"+Classificacao+";"+Artista+";"+GeneroMusical+";"+Data);
                efetuado = true;
            }
            
            catch(Exception ex)
            {
                throw new Exception("Erro ao tentar gravar o arquivo!"+ex.Message); //exibe uma mensagem avisando que não foi possível gravar no arquivo
            }
            finally //fecha o arquivo após o TRY/CATCH
            {
                arquivo.Close();
            }
            return efetuado;
        }

        public override string Pesquisar(string Titulo) //método para pesquisar o EVENTO por TÍTULO
        {
            string resultado = ("Titulo não encontrado");
            StreamReader ler = null;

            try
            {
                ler = new StreamReader("Show.csv", Encoding.Default); //Encoding.Default serve para utilizar
                string linha = "";
                while((linha=ler.ReadLine())!=null)
                {
                    string[] dados = linha.Split(';');
                    if(dados[0] == Titulo)
                    {
                        resultado = linha;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                resultado = ("Erro ao tentar ler o arquivo!"+ex.Message);
            }
            finally
            {
                ler.Close();
            }

            return resultado;
        }

        public override string Pesquisar(DateTime Data) //método para pesquisar o EVENTO por DATA
        {
            string resultado = ("Titulo não encontrado");
            StreamReader ler = null;

            try
            {
                ler = new StreamReader("Show.csv", Encoding.Default);
                string linha = "";
                while((linha=ler.ReadLine())!=null)
                {
                    string[] dados = linha.Split(';');
                    if(dados[7] == Convert.ToString(Data))
                    {
                        resultado = linha;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                resultado = ("Erro ao tentar ler o arquivo!"+ex.Message);
            }
            finally
            {
                ler.Close();
            }

            return resultado;
        }

    }
}