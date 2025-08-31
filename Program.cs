using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=== Contador de Linhas e Palavras ===");

        Console.Write("Informe o caminho da pasta com arquivos .txt: ");
        string? pasta = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(pasta) || !Directory.Exists(pasta))
        {
            Console.WriteLine("Pasta inválida.");
            return;
        }

        var arquivos = Directory.GetFiles(pasta, "*.txt");

        if (arquivos.Length == 0)
        {
            Console.WriteLine("Nenhum arquivo .txt encontrado.");
            return;
        }

        Console.WriteLine("\nArquivos encontrados:");
        foreach (var arquivo in arquivos)
        {
            Console.WriteLine($" - {Path.GetFileName(arquivo)}");
        }

        Console.WriteLine("\nPressione ENTER para iniciar o processamento...");
        Console.ReadLine();

        // Pasta export na raiz do projeto
        string pastaRaiz = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
        string pastaExportRaiz = Path.Combine(pastaRaiz, "export");
        Directory.CreateDirectory(pastaExportRaiz);

        string relatorioPathRaiz = Path.Combine(pastaExportRaiz, "relatorio.txt");

        // Pasta export dentro de bin/Debug/net8.0
        string pastaExportBin = Path.Combine(AppContext.BaseDirectory, "export");
        Directory.CreateDirectory(pastaExportBin);

        string relatorioPathBin = Path.Combine(pastaExportBin, "relatorio.txt");

        var resultados = await ProcessarArquivosAsync(arquivos);

        // gera nos dois locais
        await GerarRelatorioAsync(resultados, relatorioPathRaiz);
        await GerarRelatorioAsync(resultados, relatorioPathBin);

        Console.WriteLine($"\n✅ Relatórios gerados em:");
        Console.WriteLine($"   - {relatorioPathRaiz}");
        Console.WriteLine($"   - {relatorioPathBin}");

        // resumo total
        int totalLinhas = resultados.Sum(r => r.linhas);
        int totalPalavras = resultados.Sum(r => r.palavras);
        Console.WriteLine($"\n📊 Totais: {totalLinhas} linhas - {totalPalavras} palavras");
    }

    static async Task<List<(string arquivo, int linhas, int palavras)>> ProcessarArquivosAsync(IEnumerable<string> arquivos)
    {
        var tasks = arquivos.Select(async arquivo =>
        {
            string nome = Path.GetFileName(arquivo);
            Console.WriteLine($"\nProcessando arquivo {nome}...");

            string[] linhas = await File.ReadAllLinesAsync(arquivo);
            int qtdLinhas = linhas.Length;
            int qtdPalavras = linhas.Sum(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length);

            Console.WriteLine($"✅ {nome} - {qtdLinhas} linhas - {qtdPalavras} palavras");

            return (nome, qtdLinhas, qtdPalavras);
        });

        return (await Task.WhenAll(tasks)).ToList();
    }

    static async Task GerarRelatorioAsync(List<(string arquivo, int linhas, int palavras)> resultados, string caminho)
    {
        var sb = new StringBuilder();

        foreach (var item in resultados)
        {
            sb.AppendLine($"{item.arquivo} - {item.linhas} linhas - {item.palavras} palavras");
        }

        await File.WriteAllTextAsync(caminho, sb.ToString(), Encoding.UTF8);
    }
}
