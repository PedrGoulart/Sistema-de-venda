using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    // ESTRUTURAS
    struct Brinquedo
    {
        public string Nome;
        public int Quantidade;
        public double Preco;

        public override string ToString()
        {
            return Nome + " - Quantidade: " + Quantidade +
                   " - Preco: R$ " + Preco.ToString("F2");
        }
    }

    struct Roupa
    {
        public string Nome;
        public string Cor;
        public int Quantidade;
        public double Preco;

        public override string ToString()
        {
            return Nome + " " + Cor +
                   " - Quantidade: " + Quantidade +
                   " - Preco: R$ " + Preco.ToString("F2");
        }
    }

    struct Venda
    {
        public string Nome;
        public string Tipo;
        public int Quantidade;
        public double Preco;

        public override string ToString()
        {
            return Tipo + " - " + Nome +
                   " - Quantidade: " + Quantidade +
                   " - Preco: R$ " + Preco.ToString("F2");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Brinquedo> brinquedos = new List<Brinquedo>();
            List<Roupa> roupas = new List<Roupa>();
            List<Venda> vendas = new List<Venda>();

            int op = -1;

            // CARREGAR DADOS AO INICIAR
            CarregarDados(brinquedos, roupas, vendas);

            while (op != 0)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("==========================================");
                Console.WriteLine("           Pedro e Nicola Store");
                Console.WriteLine("==========================================");

                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Realizar Venda");
                Console.WriteLine("3 - Relatório de Vendas");
                Console.WriteLine("4 - Consultar Estoque");
                Console.WriteLine("5 - Excluir Produto");
                Console.WriteLine("0 - Sair");

                Console.Write("\nDigite uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out op))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDigite apenas números.");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                switch (op)
                {
                    case 1:
                        MenuCadastro(brinquedos, roupas);
                        break;

                    case 2:
                        RealizarVenda(vendas, roupas, brinquedos);
                        break;

                    case 3:
                        RelatorioVendas(vendas);
                        break;

                    case 4:
                        ConsultarEstoque(brinquedos, roupas);
                        break;

                    case 5:
                        ExcluirProduto(brinquedos, roupas);
                        break;

                    case 0:
                        Console.Clear();
                        Console.WriteLine("Sistema encerrado.");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção inválida!");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        // MENU DE CADASTRO
        static void MenuCadastro(
            List<Brinquedo> brinquedos,
            List<Roupa> roupas)
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("              CADASTRO");
            Console.WriteLine("==========================================");

            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar Brinquedo");
            Console.WriteLine("2 - Cadastrar Roupa");
            Console.WriteLine("0 - Voltar");

            Console.Write("\nEscolha: ");

            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                CadastrarBrinquedo(brinquedos);
            }
            else if (opcao == "2")
            {
                CadastrarRoupa(roupas);
            }
        }

        // CADASTRO DE BRINQUEDO
        static void CadastrarBrinquedo(
            List<Brinquedo> brinquedos)
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("         CADASTRO DE BRINQUEDO");
            Console.WriteLine("==========================================");
            Brinquedo brinquedo = new Brinquedo();
            Console.Write("\nNome do brinquedo: ");
            brinquedo.Nome = Console.ReadLine();
            Console.Write("Quantidade: ");

            if (!int.TryParse(Console.ReadLine(), out brinquedo.Quantidade) ||
                brinquedo.Quantidade < 0)
            {
                Console.WriteLine("\nQuantidade inválida.");
                Console.ReadKey();
                return;
            }
            Console.Write("Preço: ");
            if (!double.TryParse(Console.ReadLine(), out brinquedo.Preco) ||
                brinquedo.Preco < 0)
            {
                Console.WriteLine("\nPreço inválido.");
                Console.ReadKey();
                return;
            }
            brinquedos.Add(brinquedo);
            // Salva após cadastro
            SalvarBrinquedos(brinquedos);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nBrinquedo cadastrado com sucesso!");
            Console.ResetColor();
            Console.ReadKey();
        }

        // CADASTRO DE ROUPA
        static void CadastrarRoupa(
            List<Roupa> roupas)
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("           CADASTRO DE ROUPA");
            Console.WriteLine("==========================================");

            Roupa roupa = new Roupa();

            Console.Write("\nNome da roupa: ");
            roupa.Nome = Console.ReadLine();
            Console.Write("Cor: ");
            roupa.Cor = Console.ReadLine();
            Console.Write("Quantidade: ");

            if (!int.TryParse(Console.ReadLine(), out roupa.Quantidade) ||
                roupa.Quantidade < 0)
            {
                Console.WriteLine("\nQuantidade inválida.");
                Console.ReadKey();
                return;
            }
            Console.Write("Preço: ");

            if (!double.TryParse(Console.ReadLine(), out roupa.Preco) ||
                roupa.Preco < 0)
            {
                Console.WriteLine("\nPreço inválido.");
                Console.ReadKey();
                return;
            }
            roupas.Add(roupa);

            // Salva após cadastro
            SalvarRoupas(roupas);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRoupa cadastrada com sucesso!");
            Console.ResetColor();
            Console.ReadKey();
        }

        static void ExcluirProduto(List<Brinquedo> brinquedos,List<Roupa> roupas)
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("             EXCLUIR PRODUTO");
            Console.WriteLine("==========================================");

            Console.WriteLine("\n1 - Excluir Brinquedo");
            Console.WriteLine("2 - Excluir Roupa");
            Console.WriteLine("0 - Voltar");

            Console.Write("\nEscolha: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 0)
                return;

            // excluir brinquedo
            if (op == 1)
            {
                if (brinquedos.Count == 0)
                {
                    Console.WriteLine("\nNenhum brinquedo cadastrado.");
                    Console.ReadKey();
                    return;
                }

                Console.Clear();

                Console.WriteLine("==========================================");
                Console.WriteLine("          BRINQUEDOS CADASTRADOS");
                Console.WriteLine("==========================================\n");

                for (int i = 0; i < brinquedos.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1} - {brinquedos[i].Nome} | " +
                        $"Estoque: {brinquedos[i].Quantidade} | " +
                        $"Preço: R$ {brinquedos[i].Preco:F2}");
                }

                Console.Write("\nDigite o nome do brinquedo: ");
                string n = Console.ReadLine();

                int ind = -1;

                for (int i = 0; i < brinquedos.Count; i++)
                {
                    if (brinquedos[i].Nome.Equals(
                        n,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        ind = i;
                        break;
                    }
                }

                if (ind == -1)
                {
                    Console.WriteLine("\nBrinquedo não encontrado.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nProduto encontrado:");
                Console.WriteLine(brinquedos[ind]);

                Console.Write("\nDeseja realmente excluir? (S/N): ");
                string conf = Console.ReadLine();

                if (conf.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    brinquedos.RemoveAt(ind);

                    SalvarBrinquedos(brinquedos);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nBrinquedo excluído com sucesso!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("\nExclusão cancelada.");
                }

                Console.ReadKey();
            }

            // excluir roupa
            else if (op == 2)
            {
                if (roupas.Count == 0)
                {
                    Console.WriteLine("\nNenhuma roupa cadastrada.");
                    Console.ReadKey();
                    return;
                }

                Console.Clear();

                Console.WriteLine("==========================================");
                Console.WriteLine("            ROUPAS CADASTRADAS");
                Console.WriteLine("==========================================\n");

                for (int i = 0; i < roupas.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1} - {roupas[i].Nome} | " +
                        $"Cor: {roupas[i].Cor} | " +
                        $"Estoque: {roupas[i].Quantidade} | " +
                        $"Preço: R$ {roupas[i].Preco:F2}");
                }

                Console.Write("\nDigite o nome da roupa: ");
                string n2 = Console.ReadLine();

                int ind2 = -1;

                for (int i = 0; i < roupas.Count; i++)
                {
                    if (roupas[i].Nome.Equals(
                        n2,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        ind2 = i;
                        break;
                    }
                }

                if (ind2 == -1)
                {
                    Console.WriteLine("\nRoupa não encontrada.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nProduto encontrado:");
                Console.WriteLine(roupas[ind2]);

                Console.Write("\nDeseja realmente excluir? (S/N): ");
                string conf2 = Console.ReadLine();

                if (conf2.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    roupas.RemoveAt(ind2);

                    SalvarRoupas(roupas);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nRoupa excluída com sucesso!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("\nExclusão cancelada.");
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nOpção inválida.");
                Console.ReadKey();
            }
        }

        // REALIZAR VENDA
        static void RealizarVenda(
            List<Venda> vendas,
            List<Roupa> roupas,
            List<Brinquedo> brinquedos)
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("             REALIZAR VENDA");
            Console.WriteLine("==========================================");

            Console.WriteLine("\n1 - Brinquedo");
            Console.WriteLine("2 - Roupa");
            Console.WriteLine("0 - Voltar");

            Console.Write("\nEscolha o tipo do produto: ");

            if (!int.TryParse(Console.ReadLine(), out int op))
            {
                Console.WriteLine("\nOpção inválida.");
                Console.ReadKey();
                return;
            }
            if (op == 0)
                return;

            // VENDA DE BRINQUEDO
            if (op == 1)
            {
                if (brinquedos.Count == 0)
                {
                    Console.WriteLine("\nNenhum brinquedo cadastrado.");
                    Console.ReadKey();
                    return;
                }

                Console.Clear();

                Console.WriteLine("==========================================");
                Console.WriteLine("          BRINQUEDOS DISPONÍVEIS");
                Console.WriteLine("==========================================\n");

                for (int i = 0; i < brinquedos.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}° - {brinquedos[i].Nome} | " +
                        $"Estoque: {brinquedos[i].Quantidade} | " +
                        $"Preco: R$ {brinquedos[i].Preco:F2}"
                    );
                }

                Console.Write("\nDigite o nome do brinquedo: ");
                string nome = Console.ReadLine();

                int ind = -1;

                for (int i = 0; i < brinquedos.Count; i++)
                {
                    if (brinquedos[i].Nome.Equals(
                        nome,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        ind = i;
                        break;
                    }
                }

                if (ind == -1)
                {
                    Console.WriteLine("\nBrinquedo não encontrado.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Quantidade desejada: ");

                if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
                {
                    Console.WriteLine("\nQuantidade inválida.");
                    Console.ReadKey();
                    return;
                }
                if (quantidade > brinquedos[ind].Quantidade)
                {
                    Console.WriteLine(
                        "\nQuantidade maior que o estoque disponível.");
                    Console.ReadKey();
                    return;
                }
                double total =
                    brinquedos[ind].Preco * quantidade;

                Console.WriteLine(
                    $"\nProduto: {brinquedos[ind].Nome}");
                Console.WriteLine(
                    $"Quantidade: {quantidade}");
                Console.WriteLine(
                    $"Total: R$ {total:F2}");
                Console.WriteLine("\n1 - Confirmar compra");
                Console.WriteLine("2 - Cancelar");
                Console.Write("\nEscolha: ");

                string conf = Console.ReadLine();

                if (conf == "1")
                {
                    // Baixa no estoque
                    Brinquedo brinquedo = brinquedos[ind];
                    brinquedo.Quantidade -= quantidade;
                    brinquedos[ind] = brinquedo;

                    // Registra a venda
                    Venda venda = new Venda();
                    venda.Nome = brinquedo.Nome;
                    venda.Tipo = "Brinquedo";
                    venda.Quantidade = quantidade;
                    venda.Preco = total;
                    vendas.Add(venda);

                    // Salva os dados
                    SalvarBrinquedos(brinquedos);
                    SalvarVendas(vendas);
                    Console.ForegroundColor =
                        ConsoleColor.Green;
                    Console.WriteLine(
                        "\nVenda realizada com sucesso!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("\nVenda cancelada.");
                }
                Console.ReadKey();
            }

            // VENDA DE ROUPA
            else if (op == 2)
            {
                if (roupas.Count == 0)
                {
                    Console.WriteLine("\nNenhuma roupa cadastrada.");
                    Console.ReadKey();
                    return;
                }

                Console.Clear();

                Console.WriteLine("==========================================");
                Console.WriteLine("            ROUPAS DISPONÍVEIS");
                Console.WriteLine("==========================================\n");

                for (int i = 0; i < roupas.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1} - {roupas[i].Nome} | " +
                        $"Cor: {roupas[i].Cor} | " +
                        $"Estoque: {roupas[i].Quantidade} | " +
                        $"Preço: R$ {roupas[i].Preco:F2}");
                }

                Console.Write("\nDigite o nome da roupa: ");
                string nome = Console.ReadLine();

                int indice = -1;

                for (int i = 0; i < roupas.Count; i++)
                {
                    if (roupas[i].Nome.Equals(
                        nome,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        indice = i;
                        break;
                    }
                }

                if (indice == -1)
                {
                    Console.WriteLine("\nRoupa não encontrada.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Quantidade desejada: ");

                if (!int.TryParse(
                    Console.ReadLine(),
                    out int quantidade) ||
                    quantidade <= 0)
                {
                    Console.WriteLine("\nQuantidade inválida.");
                    Console.ReadKey();
                    return;
                }
                if (quantidade > roupas[indice].Quantidade)
                {
                    Console.WriteLine(
                        "\nQuantidade maior que o estoque disponível.");
                    Console.ReadKey();
                    return;
                }

                double total =
                    roupas[indice].Preco * quantidade;
                Console.WriteLine(
                    $"\nProduto: {roupas[indice].Nome}");
                Console.WriteLine(
                    $"Cor: {roupas[indice].Cor}");
                Console.WriteLine(
                    $"Quantidade: {quantidade}");
                Console.WriteLine(
                    $"Total: R$ {total:F2}");
                Console.WriteLine("\n1 - Confirmar compra");
                Console.WriteLine("2 - Cancelar");
                Console.Write("\nEscolha: ");
                string confirmar = Console.ReadLine();
                if (confirmar == "1")
                {
                    // Baixa no estoque
                    Roupa roupa = roupas[indice];
                    roupa.Quantidade -= quantidade;
                    roupas[indice] = roupa;

                    // Registra a venda
                    Venda venda = new Venda();
                    venda.Nome = roupa.Nome;
                    venda.Tipo = "Roupa";
                    venda.Quantidade = quantidade;
                    venda.Preco = total;
                    vendas.Add(venda);

                    // Salva os dados
                    SalvarRoupas(roupas);
                    SalvarVendas(vendas);
                    Console.ForegroundColor =
                        ConsoleColor.Green;
                    Console.WriteLine(
                        "\nVenda realizada com sucesso!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("\nVenda cancelada.");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nOpção inválida.");
                Console.ReadKey();
            }
        }

        // CONSULTAR ESTOQUE
        static void ConsultarEstoque(List<Brinquedo> brinquedos,List<Roupa> roupas)
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("             CONSULTAR ESTOQUE");
            Console.WriteLine("==========================================");
            Console.Write("\nDigite o nome do produto (ou todos pra listar o estoque inteiro): ");
            string nome = Console.ReadLine();
            bool encontrado = false;

            // Procura brinquedo
            for (int i = 0; i < brinquedos.Count; i++)
            {
                if (nome == "todos")
                {
                    foreach (Brinquedo p in brinquedos) {
                        Console.WriteLine("\nProduto encontrado:");
                        Console.WriteLine(p);
                    }
                    
                    encontrado = true;
                    break;
                }
                else if (brinquedos[i].Nome.Equals(nome,StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nProduto encontrado:");
                    Console.WriteLine(brinquedos[i]);
                    encontrado = true;
                    break;
                }
            }

            // Procura roupa
            
            for (int i = 0; i < roupas.Count; i++)
            {
                if (nome == "todos")
                {
                    foreach (Roupa r in roupas)
                    {
                        Console.WriteLine("\nProduto encontrado:");
                        Console.WriteLine(r);
                    }

                    encontrado = true;
                    break;
                }
               if (roupas[i].Nome.Equals(nome,StringComparison.OrdinalIgnoreCase))
               {
                    Console.WriteLine("\nProduto encontrado:");
                    Console.WriteLine(roupas[i]);
                    encontrado = true;
                    break;
               }
            }
            if (!encontrado)
            {
                Console.ForegroundColor =
                    ConsoleColor.Red;
                Console.WriteLine(
                    "\nProduto não encontrado.");
                Console.ResetColor();
            }
            Console.ReadKey();
        }

        // SALVAR BRINQUEDOS
        static void SalvarBrinquedos(
            List<Brinquedo> brinquedos)
        {
            using (StreamWriter arquivo =
                   new StreamWriter("brinquedos.txt"))
            {
                for (int i = 0; i < brinquedos.Count; i++)
                {
                    arquivo.WriteLine(
                        brinquedos[i].Nome + ";" +
                        brinquedos[i].Quantidade + ";" +
                        brinquedos[i].Preco);
                }
            }
        }

        // SALVAR ROUPAS
        static void SalvarRoupas(
            List<Roupa> roupas)
        {
            using (StreamWriter arquivo =
                   new StreamWriter("roupas.txt"))
            {
                for (int i = 0; i < roupas.Count; i++)
                {
                    arquivo.WriteLine(
                        roupas[i].Nome + ";" +
                        roupas[i].Cor + ";" +
                        roupas[i].Quantidade + ";" +
                        roupas[i].Preco);
                }
            }
        }

        // SALVAR VENDAS
        static void SalvarVendas(
            List<Venda> vendas)
        {
            using (StreamWriter arquivo =
                   new StreamWriter("vendas.txt"))
            {
                for (int i = 0; i < vendas.Count; i++)
                {
                    arquivo.WriteLine(
                        vendas[i].Nome + ";" +
                        vendas[i].Tipo + ";" +
                        vendas[i].Quantidade + ";" +
                        vendas[i].Preco);
                }
            }
        }

        // SALVAR TODOS OS DADOS
        static void SalvarDados(
            List<Brinquedo> brinquedos,
            List<Roupa> roupas,
            List<Venda> vendas)
        {
            SalvarBrinquedos(brinquedos);
            SalvarRoupas(roupas);
            SalvarVendas(vendas);
        }

        // CARREGAR DADOS
        static void CarregarDados(
            List<Brinquedo> brinquedos,
            List<Roupa> roupas,
            List<Venda> vendas)
        {
            // CARREGAR BRINQUEDOS
            if (File.Exists("brinquedos.txt"))
            {
                string[] linhas =
                    File.ReadAllLines("brinquedos.txt");
                for (int i = 0; i < linhas.Length; i++)
                {
                    string[] dados =
                        linhas[i].Split(';');
                    if (dados.Length == 3)
                    {
                        Brinquedo brinquedo =
                            new Brinquedo();
                        brinquedo.Nome = dados[0];
                        if (int.TryParse(
                            dados[1],
                            out int quantidade))
                        {
                            brinquedo.Quantidade =
                                quantidade;
                        }
                        if (double.TryParse(
                            dados[2],
                            out double preco))
                        {
                            brinquedo.Preco = preco;
                        }
                        brinquedos.Add(brinquedo);
                    }
                }
            }

            // CARREGAR ROUPAS
            if (File.Exists("roupas.txt"))
            {
                string[] linhas =
                    File.ReadAllLines("roupas.txt");
                for (int i = 0; i < linhas.Length; i++)
                {
                    string[] dados =
                        linhas[i].Split(';');
                    if (dados.Length == 4)
                    {
                        Roupa roupa = new Roupa();
                        roupa.Nome = dados[0];
                        roupa.Cor = dados[1];
                        if (int.TryParse(
                            dados[2],
                            out int quantidade))
                        {
                            roupa.Quantidade =
                                quantidade;
                        }
                        if (double.TryParse(
                            dados[3],
                            out double preco))
                        {
                            roupa.Preco = preco;
                        }
                        roupas.Add(roupa);
                    }
                }
            }

            // CARREGAR VENDAS
            if (File.Exists("vendas.txt"))
            {
                string[] linhas =
                    File.ReadAllLines("vendas.txt");
                for (int i = 0; i < linhas.Length; i++)
                {
                    string[] dados =
                        linhas[i].Split(';');
                    if (dados.Length == 4)
                    {
                        Venda venda = new Venda();
                        venda.Nome = dados[0];
                        venda.Tipo = dados[1];
                        if (int.TryParse(
                            dados[2],
                            out int quantidade))
                        {
                            venda.Quantidade =
                                quantidade;
                        }
                        if (double.TryParse(
                            dados[3],
                            out double preco))
                        {
                            venda.Preco = preco;
                        }
                        vendas.Add(venda);
                    }
                }
            }
        }

        // RELATÓRIO DE VENDAS
        static void RelatorioVendas(
            List<Venda> vendas)
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("             RELATÓRIO DE VENDAS");
            Console.WriteLine("==========================================");

            if (vendas.Count == 0)
            {
                Console.WriteLine(
                    "\nNenhuma venda realizada.");
                Console.ReadKey();
                return;
            }

            double totalBr = 0;
            double totalRp = 0;
            double total = 0;
            int quantBr = 0;
            int quantRp = 0;

            Console.WriteLine();
            for (int i = 0; i < vendas.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1} - {vendas[i]}");
                total += vendas[i].Preco;
                if (vendas[i].Tipo == "Brinquedo")
                {
                    totalBr += vendas[i].Preco;
                    quantBr += vendas[i].Quantidade;
                }
                else if (vendas[i].Tipo == "Roupa")
                {
                    totalRp += vendas[i].Preco;
                    quantRp += vendas[i].Quantidade;
                }
            }
            Console.WriteLine("\n==========================================");
            Console.WriteLine("              RESUMO DAS VENDAS");
            Console.WriteLine("==========================================");

            Console.WriteLine("\nBRINQUEDOS");
            Console.WriteLine($"Quantidade vendida: {quantBr}");
            Console.WriteLine($"Total: R$ {totalBr:F2}");

            Console.WriteLine("\nROUPAS");
            Console.WriteLine($"Quantidade vendida: {quantRp}");
            Console.WriteLine($"Total: R$ {totalRp:F2}");
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine($"TOTAL DE VENDAS: {vendas.Count}");
            Console.WriteLine($"FATURAMENTO TOTAL: R$ {total:F2}");
            Console.WriteLine("\n==========================================");
            Console.ReadKey();
        }
    }
}
