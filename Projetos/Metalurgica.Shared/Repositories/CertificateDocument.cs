using Metalurgica.Entities.Common;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Metalurgica.Shared.Repositories
{
    public class CertificateDocument : IDocument
    {
        public CertificateData Data { get; }
        public CertificateDocument(CertificateData data) => Data = data;

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(9));
                page.Size(PageSizes.A4);
                page.Margin(30);

                page.Header().Row(row =>
                {
                    //TODO: Adicionar imagem da logo de alguma forma

                    //row.ConstantItem(100)
                    //   .AlignMiddle()
                    //   .PaddingVertical(10)
                    //   .Image(Data.LogoPath)
                    //   .FitWidth();

                    row.RelativeItem()
                       .AlignMiddle()
                       .AlignCenter()
                       .PaddingVertical(10)
                       .Text($"CERTIFICADO DA QUALIDADE Nº {Data.NumeroCertificado}")
                       .SemiBold().FontSize(12);
                });

                page.Content().Column(col =>
                {
                    col.Spacing(6);

                    col.Item().LineHorizontal(1).LineColor(Colors.Black);

                    col.Item().Row(row =>
                    {
                        row.RelativeItem().Column(prod =>
                        {
                            prod.Spacing(2);
                            prod.Item().PaddingBottom(8).Text("PRODUTO").SemiBold().FontSize(10);
                            prod.Item().Table(table =>
                            {
                                table.ColumnsDefinition(def =>
                                {
                                    def.ConstantColumn(80);
                                    def.RelativeColumn();
                                });

                                void F(string label, string value)
                                {
                                    table.Cell().Text(label).SemiBold();
                                    table.Cell().Text(value);
                                }

                                F("Produto:", Data.Produto);
                                F("Fabricação:", Data.DataFabricacao);
                                F("Validade:", Data.DataValidade);
                                F("Emissão:", Data.DataEmissao);
                                F("Lote:", Data.Lote);
                            });
                        });


                        // Coluna CLIENTE
                        row.RelativeItem().Column(cli =>
                        {
                            cli.Spacing(2);
                            cli.Item().PaddingBottom(8).Text("CLIENTE").SemiBold().FontSize(10);
                            cli.Item().Table(table =>
                            {
                                table.ColumnsDefinition(def =>
                                {
                                    def.ConstantColumn(80);
                                    def.RelativeColumn();
                                });

                                void G(string label, string value)
                                {
                                    table.Cell().Text(label).SemiBold();
                                    table.Cell().Text(value);
                                }

                                G("Cliente:", Data.Cliente);
                                G("Peso (kg):", Data.Peso);
                                G("Nota Fiscal:", Data.NotaFiscal);
                            });
                        });
                    });

                    col.Spacing(10);
                    col.Item().LineHorizontal(1).LineColor(Colors.Black);

                    col.Item().Text("PROPRIEDADES FÍSICAS").SemiBold().FontSize(10);
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(def =>
                        {
                            def.ConstantColumn(100);
                            def.ConstantColumn(50);
                            def.ConstantColumn(80);
                            def.ConstantColumn(80);
                            def.RelativeColumn();
                        });

                        foreach (var h in new[] { "Descrição", "Unidade", "Ensaio", "Mínimo", "Resultado" })
                            table.Cell().Text(h).SemiBold();

                        foreach (var row in Data.PropriedadesFisicas)
                        {
                            table.Cell().Text(row.Descricao);
                            table.Cell().Text(row.Unidade);
                            table.Cell().Text(row.Ensaio);
                            table.Cell().Text(row.Minimo);
                            table.Cell().Text(row.Resultado);
                        }
                    });

                    // === Composição Química ===
                    col.Spacing(8);
                    col.Item().LineHorizontal(1).LineColor(Colors.Black);
                    col.Item().Text("COMPOSIÇÃO QUÍMICA").SemiBold().FontSize(10);
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(def =>
                        {
                            def.ConstantColumn(100);
                            def.ConstantColumn(50);
                            def.ConstantColumn(80);
                            def.ConstantColumn(80);
                            def.RelativeColumn();
                        });

                        foreach (var h in new[] { "Descrição", "Unidade", "Ensaio", "Mínimo", "Resultado" })
                            table.Cell().Text(h).SemiBold();

                        foreach (var row in Data.ComposicaoQuimica)
                        {
                            table.Cell().Text(row.Descricao);
                            table.Cell().Text(row.Unidade);
                            table.Cell().Text(row.Ensaio);
                            table.Cell().Text(row.Minimo);
                            table.Cell().Text(row.Resultado);
                        }
                    });

                    // === Granulometria ===
                    col.Spacing(8);
                    col.Item().LineHorizontal(1).LineColor(Colors.Black);
                    col.Item().Text("GRANULOMETRIA").SemiBold().FontSize(10);
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(def =>
                        {
                            def.ConstantColumn(150);
                            def.ConstantColumn(50);
                            def.ConstantColumn(80);
                            def.ConstantColumn(80);
                            def.RelativeColumn();
                        });

                        foreach (var h in new[] { "Descrição", "Unidade", "Ensaio", "Mínimo", "Resultado" })
                            table.Cell().Text(h).SemiBold();

                        foreach (var row in Data.Granulometria)
                        {
                            table.Cell().Text(row.Descricao);
                            table.Cell().Text(row.Unidade);
                            table.Cell().Text(row.Ensaio);
                            table.Cell().Text(row.Minimo);
                            table.Cell().Text(row.Resultado);
                        }
                    });

                    // === Observações ===
                    col.Spacing(8);
                    col.Item().LineHorizontal(1).LineColor(Colors.Black);
                    col.Item().Text("OBSERVAÇÃO:").SemiBold();
                    col.Item().Text(Data.Observacao);
                    col.Item().PaddingTop(4).Text("CONDIÇÕES ESPECIAIS:").SemiBold();
                    col.Item().Text(Data.CondicoesEspeciais);

                    // separador antes do rodapé
                    col.Spacing(10);
                    col.Item().LineHorizontal(1).LineColor(Colors.Black);
                });

                // Rodapé (assinatura)
                page.Footer().Row(r =>
                {
                    r.RelativeItem().Text($"APROVADO POR {Data.AprovadoPor}").FontSize(8);
                    r.RelativeItem().AlignRight().Text(Data.Depto).FontSize(8);
                });
            });
        }
    }

}
