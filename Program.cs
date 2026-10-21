using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return Nome +" "+Cor+" - Quantidade: " + Quantidade +
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
            int op;

            while (op!=0)
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
                Console.WriteLine("0 - Sair");

                Console.Write("\nDigite uma opção: ");

                op = int.Parse(Console.ReadLine());
                switch (op) { 
                    case 1:
                        MenuCadastro(brinquedos, roupas);
                        break;
                    case 2:
                        RealizarVenda(vendas, roupas, brinquedos);
                        break;
                    case 3:
                        RelatorioVendas(vendas);
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

                brinquedo.Quantidade = int.Parse(
                    Console.ReadLine()
                );


                Console.Write("Preço: ");

                brinquedo.Preco = double.Parse(
                    Console.ReadLine()
                );


                brinquedos.Add(brinquedo);


                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\nBrinquedo cadastrado com sucesso!");

                Console.ResetColor();

                Console.ReadKey();
            }

        static void CadastrarRoupa(
                List<Roupa> roupas)
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("          CADASTRO DE Roupas");
            Console.WriteLine("==========================================");


            Roupa roupa = new Roupa();


            Console.Write("\nNome do brinquedo: ");

            roupa.Nome = Console.ReadLine();

            Console.Write("Cor: ");

            roupa.Cor = Console.ReadLine();

            Console.Write("Quantidade: ");

            roupa.Quantidade = int.Parse(
                Console.ReadLine()
            );


            Console.Write("Preço: ");

            roupa.Preco = double.Parse(
                Console.ReadLine()
            );


            roupas.Add(roupa);


            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nRoupa cadastrado com sucesso!");

            Console.ResetColor();

            Console.ReadKey();
        }




        // FUNÇÕES QUE AINDA PRECISAM SER FEITAS
        // Excluir produto
        static void ExcluirProduto()
            {
                // TODO:
                // Procurar produto
                // Pedir confirmação
                // Remover da lista
            }



        static void RealizarVenda(List<Venda> vendas, List<Roupa> roupas, List<Brinquedo> brinquedos)
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("             REALIZAR VENDA");
            Console.WriteLine("==========================================");

            Console.WriteLine("\n1 - Brinquedo");
            Console.WriteLine("2 - Roupa");
            Console.WriteLine("0 - Voltar");

            Console.Write("\nEscolha o tipo do produto: ");
            int op = int.Parse(Console.ReadLine());

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
                    if (brinquedos[i].Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
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

                if (!int.TryParse(Console.ReadLine(), out int quantidade) ||
                    quantidade <= 0)
                {
                    Console.WriteLine("\nQuantidade invalida.");
                    Console.ReadKey();
                    return;
                }

                if (quantidade > brinquedos[ind].Quantidade)
                {
                    Console.WriteLine("\nQuantidade maior que o estoque disponivel.");
                    Console.ReadKey();
                    return;
                }

                double total = brinquedos[ind].Preco * quantidade;

                Console.WriteLine($"\nProduto: {brinquedos[ind].Nome}");
                Console.WriteLine($"Quantidade: {quantidade}");
                Console.WriteLine($"Total: R$ {total:F2}");

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

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nVenda realizada com sucesso!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("\nVenda cancelada.");
                }

                Console.ReadKey();
                
                // VENDA DE ROUPA
            else if (opcao == "2")
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
                    if (roupas[i].Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
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

                if (!int.TryParse(Console.ReadLine(), out int quantidade) ||
                    quantidade <= 0)
                {
                    Console.WriteLine("\nQuantidade inválida.");
                    Console.ReadKey();
                    return;
                }

                if (quantidade > roupas[indice].Quantidade)
                {
                    Console.WriteLine("\nQuantidade maior que o estoque disponível.");
                    Console.ReadKey();
                    return;
                }

                double total = roupas[indice].Preco * quantidade;

                Console.WriteLine($"\nProduto: {roupas[indice].Nome}");
                Console.WriteLine($"Cor: {roupas[indice].Cor}");
                Console.WriteLine($"Quantidade: {quantidade}");
                Console.WriteLine($"Total: R$ {total:F2}");

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

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nVenda realizada com sucesso!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("\nVenda cancelada.");
                    }
                    Console.ReadKey();
            }else
             {
                Console.WriteLine("\nOpção inválida.");
                Console.ReadKey();
             }
        }


            // Salvar dados

            static void SalvarDados()
            {
                // TODO:
                // Criar arquivos .txt
                // Salvar produtos e vendas
            }


            // Carregar dados

            static void CarregarDados()
            {
                // TODO:
                // Ler os arquivos quando o programa iniciar
            }


        // Relatório

        static void RelatorioVendas(List<Venda> vendas)
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("             RELATÓRIO DE VENDAS");
            Console.WriteLine("==========================================");

            if (vendas.Count == 0)
            {
                Console.WriteLine("\nNenhuma venda realizada.");
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
                Console.WriteLine($"{i + 1} - {vendas[i]}");

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
