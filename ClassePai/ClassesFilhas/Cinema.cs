using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Cinema:Evento
    {
        public string[] Elenco { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }


        public Cinema()
        {
            
        }

        public Cinema(string Titulo, string Local, int Lotacao, string Duracao, string Classificacao, DateTime Data, string Diretor, string[] Elenco, string Genero)
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            base.Data = Data;
            this.Diretor = Diretor;
            this.Elenco = Elenco;
            this.Genero = Genero;
        }
        public override bool Cadastrar() //método para cadastrar o EVENTO
        {
            bool efetuado = false;
            StreamWriter arquivo = null;
            string Artistas = "";

            try
            {
                arquivo = new StreamWriter("Cinema.csv", true);

                for (int i = 0; i < Elenco.Length; i++)
                {
                    Artistas += Elenco[i] + "/";
                }

                arquivo.WriteLine(Titulo+";"+Local+";"+Lotacao+";"+Duracao+";"+Classificacao+";"+Diretor+";"+Artistas+";"+Genero+";"+Data);
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
                ler = new StreamReader("Cinema.csv", Encoding.Default); //Encoding.Default serve para utilizar a codificação padrão do sistema operacional
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
            string resultado = ("Título não encontrado");
            StreamReader ler = null;

            try
            {
                ler = new StreamReader("Cinema.csv", Encoding.Default);
                string linha = "";
                while((linha=ler.ReadLine())!=null)
                {
                    string[] dados = linha.Split(';');
                    if(dados[8] == Convert.ToString(Data))
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
    