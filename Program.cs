using System;
using System.Diagnostics;

namespace HeapVsStackCSsharp;

public class Program()
{
    static void Main(string[] args)
    {
        int numeroDeOperacoes = 100_000;
        Console.WriteLine("Comparando Performance entre Tipo de Valor e Tipo de Referência...\n");

        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < numeroDeOperacoes; i++)
        {
            var tipoDeValor = new TipoDeValorStruct() { x = i, y = i };
            ProcessarTipoValor(tipoDeValor);
        }

        stopwatch.Stop();

        Console.WriteLine($"Tempo com Tipo de Valor(struct): {stopwatch.ElapsedMilliseconds}");

        stopwatch.Restart();

        for (int i = 0; i < numeroDeOperacoes; i++)
        {
            var tipoDeReferenciaClass = new TipoDeReferenciaClass() { x = i, y = i};
            ProcessarTipoDeReferencia(tipoDeReferenciaClass);
        }

        stopwatch.Stop();

        Console.WriteLine($"Tempo com Tipo de Referência(class): {stopwatch.ElapsedMilliseconds}");
    }

    static void ProcessarTipoValor(TipoDeValorStruct tipoDeValor)
    {
        int operacaoSimples = tipoDeValor.x * tipoDeValor.y;
    }

    static void ProcessarTipoDeReferencia(TipoDeReferenciaClass tipoDeReferenciaClass)
    {
        int operacaoSimples = tipoDeReferenciaClass.x * tipoDeReferenciaClass.y;
    }
}

struct TipoDeValorStruct
{
    public int x { get; set; }
    public int y { get; set; }
}

class TipoDeReferenciaClass
{
    public int x { get; set; }
    public int y { get; set; }
}

