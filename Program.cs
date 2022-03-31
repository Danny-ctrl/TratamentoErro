using System;

namespace TratamentoErro
{

  class Program
  {

    static void Main(string[] args)
    {
      var arr = new int[3];

      try
      {
        for (var index = 0; index < 10; index++)
        {
          System.Console.WriteLine(arr[index]);
        }
        Cadastrar("");
      }

      catch (IndexOutOfRangeException ex)
      {
        System.Console.WriteLine(ex.InnerException);
        System.Console.WriteLine(ex.Message);
        System.Console.WriteLine("Não encontrei o índice na lista");
      }

      catch (ArgumentNullException ex)
      {
        System.Console.WriteLine(ex.InnerException);
        System.Console.WriteLine(ex.Message);
        System.Console.WriteLine("Falha ao cadastrar o texto");
      }

      catch (MinhaException ex)
      {

        System.Console.WriteLine(ex.InnerException);
        System.Console.WriteLine(ex.Message);
        System.Console.WriteLine(ex.QuandoAconteceu);
        System.Console.WriteLine("Excessão Customizada");
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex.InnerException);
        System.Console.WriteLine(ex.Message);
        System.Console.WriteLine("Ops,algo deu errado");
      }
      finally
      {
        System.Console.WriteLine("Chegou ao fim");
      }
    }
    private static void Cadastrar(string texto)
    {
      if (string.IsNullOrEmpty(texto))
        throw new MinhaException(DateTime.Now);
    }
    public class MinhaException : Exception
    {
      public MinhaException(DateTime date)
      {
        QuandoAconteceu = date;
      }
      public DateTime QuandoAconteceu { get; set; }

    }
  }
}
