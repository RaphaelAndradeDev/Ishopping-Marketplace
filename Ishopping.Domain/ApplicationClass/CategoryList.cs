using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.ApplicationClass
{

    public class BasicCategory
    {
        public int Id { get; private set; }
        public string Name { get; private set; }   

        public BasicCategory(int id, string name)
        {
            Id = id;
            Name = name;         
        }

        public override bool Equals(object obj)
        {
            return ((BasicCategory)obj).Id == Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public static class BasicCategoryList
    {        
        public static SortedList getCategoy()
        {
            SortedList category = new SortedList();
            category.Add(10, "Celulares e Telefones");
            category.Add(11, "Informática");
            category.Add(12, "Eletrônicos, Áudio e Vídeo");
            category.Add(13, "Acessórios para Veículos");
            category.Add(14, "Produtos de Beleza");
            category.Add(15, "Esporte e Lazer");
            category.Add(16, "Casa e Eletrodomésticos");
            category.Add(17, "Ferramentas E Indústria");
            category.Add(18, "Materiais de Construção");
            category.Add(19, "Brinquedos e Hobby");
            category.Add(20, "Moda Feminina");
            category.Add(21, "Moda Masculina");
            category.Add(22, "Moda Infantil");
            category.Add(23, "Livraria e Papelaria");
            category.Add(24, "Moveis");
            category.Add(25, "Outros");
            return category;
        }

        public static SortedList getImgCategoy()
        {
            SortedList imgCategory = new SortedList();
            imgCategory.Add(10, "imgCat10.jpg");
            imgCategory.Add(11, "imgCat11.jpg");
            imgCategory.Add(12, "imgCat12.jpg");
            imgCategory.Add(13, "imgCat13.jpg");
            imgCategory.Add(14, "imgCat14.jpg");
            imgCategory.Add(15, "imgCat15.jpg");
            imgCategory.Add(16, "imgCat16.jpg");
            imgCategory.Add(17, "imgCat17.jpg");
            imgCategory.Add(18, "imgCat18.jpg");
            imgCategory.Add(19, "imgCat19.jpg");
            imgCategory.Add(20, "imgCat20.jpg");
            imgCategory.Add(21, "imgCat21.jpg");
            imgCategory.Add(22, "imgCat22.jpg");
            imgCategory.Add(23, "imgCat23.jpg");
            imgCategory.Add(24, "imgCat24.jpg");
            imgCategory.Add(25, "imgCat25.jpg");
            return imgCategory;
        }

        public static SortedList getSubCategory()
        {
            SortedList subCategory = new SortedList();
            subCategory.Add(1001, "Acessórios para Celulares");
            subCategory.Add(1002, "Celulares e Smartphones");
            subCategory.Add(1003, "Peças para Celular");
            subCategory.Add(1004, "Telefones");
            subCategory.Add(1005, "Outros");
            subCategory.Add(1101, "Acessórios para PC");
            subCategory.Add(1102, "Acessórios para Notebook");
            subCategory.Add(1103, "Componentes para PC");
            subCategory.Add(1104, "Computadores Completos");
            subCategory.Add(1105, "Impressoras e Acessórios");
            subCategory.Add(1106, "Notebook");
            subCategory.Add(1107, "Programas e Jogos");
            subCategory.Add(1108, "Projetores e Acessórios");
            subCategory.Add(1109, "Redes e Wi-Fi");
            subCategory.Add(1100, "Tablets e Acessórios");
            subCategory.Add(1111, "Outros");
            subCategory.Add(1201, "Acessórios para Áudio e Vídeo");
            subCategory.Add(1202, "Áudio para Casa");
            subCategory.Add(1203, "Áudio Profissional");
            subCategory.Add(1204, "Áudio Portátil");
            subCategory.Add(1205, "Câmeras Fotográficas e Acessórios");
            subCategory.Add(1206, "Drones e Acessórios");
            subCategory.Add(1207, "Fones de Ouvido");
            subCategory.Add(1208, "Projetores e Telas");
            subCategory.Add(1209, "Peças e Componentes Elétricos");
            subCategory.Add(1210, "Segurança");
            subCategory.Add(1211, "TVs e Acessórios");
            subCategory.Add(1212, "Video Games e Acessórios");
            subCategory.Add(1213, "Outros");
            subCategory.Add(1301, "Acessórios para Carros");
            subCategory.Add(1302, "Acessórios para Motos");
            subCategory.Add(1303, "Peças para carros");
            subCategory.Add(1304, "Peças para motos");
            subCategory.Add(1305, "Pneus para Carros");
            subCategory.Add(1306, "Pneus para Motos");
            subCategory.Add(1307, "Som Automotivo");
            subCategory.Add(1308, "Veículos Pesados");
            subCategory.Add(1309, "Outros");
            subCategory.Add(1401, "Acessórios de Beleza");
            subCategory.Add(1402, "Cosméticos");
            subCategory.Add(1403, "Eletrodomésticos para Beleza");
            subCategory.Add(1404, "Esmaltes");
            subCategory.Add(1405, "Maquiagem");
            subCategory.Add(1406, "Perfumes");
            subCategory.Add(1407, "Produtos para Cabelo");
            subCategory.Add(1408, "Outros");
            subCategory.Add(1501, "Alpinismo");
            subCategory.Add(1502, "Camping");
            subCategory.Add(1503, "Caça");
            subCategory.Add(1504, "Ciclismo");
            subCategory.Add(1505, "Equipamentos em Geral");
            subCategory.Add(1506, "Esportes Aquáticos");
            subCategory.Add(1507, "Fitness e Musculação");
            subCategory.Add(1508, "Futebol");
            subCategory.Add(1509, "Patins e Skates");
            subCategory.Add(1510, "Pesca");
            subCategory.Add(1511, "Suplementos e Vitaminas");
            subCategory.Add(1512, "Outros");
            subCategory.Add(1601, "Ar e Ventilação");
            subCategory.Add(1602, "Bebedouros e Purificadores");
            subCategory.Add(1603, "Decoração");
            subCategory.Add(1604, "Eletroportáteis");
            subCategory.Add(1605, "Forno e Fogões");
            subCategory.Add(1606, "Geladeiras e Freezers");
            subCategory.Add(1607, "Iluminação Residencial");
            subCategory.Add(1608, "Lava Louças e Acessórios");
            subCategory.Add(1609, "Máquinas de Lavar");
            subCategory.Add(1610, "Para o Banheiro");
            subCategory.Add(1611, "Para a Cozinha");
            subCategory.Add(1612, "Para o Quarto");
            subCategory.Add(1613, "Para o Jardim");
            subCategory.Add(1614, "Peças e Acessórios");
            subCategory.Add(1615, "Outros");
            subCategory.Add(1701, "Acessórios para Ferramentas");
            subCategory.Add(1702, "Comércio");
            subCategory.Add(1703, "Ferramentas Elétricas");
            subCategory.Add(1704, "Ferramantas Manuais");
            subCategory.Add(1705, "Equipamento para Escritórios");
            subCategory.Add(1706, "Indústria Agrícola");
            subCategory.Add(1707, "Indústria Automotiva");
            subCategory.Add(1708, "Indústria Gastronômica");
            subCategory.Add(1709, "Indústria Gráfica e Impressão");
            subCategory.Add(1710, "Indústria Pesada");
            subCategory.Add(1711, "Indústria Plástica e Química");
            subCategory.Add(1712, "Indústria Têxtil e Confecção");
            subCategory.Add(1713, "Medições e Instrumentação");
            subCategory.Add(1714, "Outros");
            subCategory.Add(1801, "Ferragens");
            subCategory.Add(1802, "Iluminação");
            subCategory.Add(1803, "Marcenaria e Madeiras");
            subCategory.Add(1804, "Materiais Elétricos");
            subCategory.Add(1805, "Materiais Hidráulicos");
            subCategory.Add(1806, "Pisos e Revestimentos");
            subCategory.Add(1807, "Pintura");
            subCategory.Add(1808, "Portas, portões e Janelas");
            subCategory.Add(1809, "Segurança e Comunicação");
            subCategory.Add(1810, "Outros");
            subCategory.Add(1901, "Bonecas e Acessórios");
            subCategory.Add(1902, "Bonecos e Acessórios");
            subCategory.Add(1903, "Carrinho e veículo");
            subCategory.Add(1904, "Jogos");
            subCategory.Add(1905, "Mini Veículos e Bicicletas");
            subCategory.Add(1906, "Outros");
            subCategory.Add(2001, "Blusas e Camisetas");
            subCategory.Add(2002, "Bermudas");
            subCategory.Add(2003, "Bolsas");
            subCategory.Add(2004, "Calças");
            subCategory.Add(2005, "Casacos");
            subCategory.Add(2006, "Joias");
            subCategory.Add(2007, "Macacão");
            subCategory.Add(2008, "Meias");
            subCategory.Add(2009, "Mochilas");
            subCategory.Add(2010, "Moda Íntima");
            subCategory.Add(2011, "Moda Praia");
            subCategory.Add(2012, "Óculos de Sol");
            subCategory.Add(2013, "Relógios");
            subCategory.Add(2014, "Saias");
            subCategory.Add(2015, "Sapatos");
            subCategory.Add(2016, "Sandálias");
            subCategory.Add(2017, "Tênis");
            subCategory.Add(2018, "Ternos");
            subCategory.Add(2019, "Vestidos");
            subCategory.Add(2020, "Outros");
            subCategory.Add(2101, "Blusas e Camisetas");
            subCategory.Add(2102, "Bermudas");
            subCategory.Add(2103, "Pastas");
            subCategory.Add(2104, "Calças");
            subCategory.Add(2105, "Casacos");
            subCategory.Add(2106, "Joias");
            subCategory.Add(2107, "Macacão");
            subCategory.Add(2108, "Meias");
            subCategory.Add(2109, "Mochilas");
            subCategory.Add(2110, "Moda Praia");
            subCategory.Add(2111, "Moda Íntima");
            subCategory.Add(2112, "Óculos de Sol");
            subCategory.Add(2113, "Relógios");
            subCategory.Add(2114, "Sapatos");
            subCategory.Add(2115, "Sandálias");
            subCategory.Add(2116, "Tênis");
            subCategory.Add(2117, "Ternos");
            subCategory.Add(2118, "Shorts");
            subCategory.Add(2119, "Outros");
            subCategory.Add(2201, "Acessórios para Bebês");
            subCategory.Add(2202, "Blusas e Camisetas");
            subCategory.Add(2203, "Bermudas");
            subCategory.Add(2204, "Calças");
            subCategory.Add(2205, "Casacos");
            subCategory.Add(2206, "Macacão");
            subCategory.Add(2207, "Meias");
            subCategory.Add(2208, "Mochilas");
            subCategory.Add(2209, "Moda Praia");
            subCategory.Add(2210, "Moda Íntima");
            subCategory.Add(2211, "Óculos de Sol");
            subCategory.Add(2212, "Relógios");
            subCategory.Add(2213, "Roupa para Bebês");
            subCategory.Add(2214, "Sapatos");
            subCategory.Add(2215, "Tênis");
            subCategory.Add(2216, "Ternos");
            subCategory.Add(2217, "Saias");
            subCategory.Add(2218, "Sandálias");
            subCategory.Add(2219, "Shorts");
            subCategory.Add(2220, "Vestidos");
            subCategory.Add(2221, "Outros");
            subCategory.Add(2301, "Agendas");
            subCategory.Add(2302, "Apontadores");
            subCategory.Add(2303, "Borrachas");
            subCategory.Add(2304, "Cadernos");
            subCategory.Add(2305, "Canetas");
            subCategory.Add(2306, "Estojos");
            subCategory.Add(2307, "Lapiseiras");
            subCategory.Add(2308, "Lápis");
            subCategory.Add(2309, "Livros");
            subCategory.Add(2310, "Mochilas");
            subCategory.Add(2311, "Papel");
            subCategory.Add(2312, "Réguas");
            subCategory.Add(2313, "Tesouras");
            subCategory.Add(2314, "Outros");
            subCategory.Add(2401, "Armários");
            subCategory.Add(2402, "Armários para Cozinha");
            subCategory.Add(2403, "Armários para Banheiro");
            subCategory.Add(2404, "Cadeiras");
            subCategory.Add(2405, "Camas");
            subCategory.Add(2406, "Escrivaninha");
            subCategory.Add(2407, "Estantes");
            subCategory.Add(2408, "Moveis para Escritório");
            subCategory.Add(2409, "Guarda-roupas");
            subCategory.Add(2410, "Mesas");
            subCategory.Add(2411, "Mesas para Computador");
            subCategory.Add(2412, "Nichos");
            subCategory.Add(2413, "Paines para TV");
            subCategory.Add(2414, "Penteadeiras");
            subCategory.Add(2415, "Poltronas");
            subCategory.Add(2416, "Prateleiras");
            subCategory.Add(2417, "Outros");
            subCategory.Add(2501, "Acessórios para Viagens");
            subCategory.Add(2502, "Artesanato");
            return subCategory;
        }

        public static string getCategoryByKey(int key)
        {
            return getCategoy().GetByIndex(
                getCategoy().IndexOfKey(key)).ToString();
        }

        public static int getCategoryByValue(string value)
        {
            return Convert.ToInt32(
                getCategoy().GetByIndex(getCategoy().IndexOfValue(value)));
        }

        public static string getImgCategoryByKey(int key)
        {
            return getImgCategoy().GetByIndex(
                getImgCategoy().IndexOfKey(key)).ToString();
        }

        public static int getImgCategoryByValue(string value)
        {
            return Convert.ToInt32(
                getImgCategoy().GetByIndex(getImgCategoy().IndexOfValue(value)));
        }

        public static string getSubCategoryByKey(int key)
        {
            return getSubCategory().GetByIndex(
                getSubCategory().IndexOfKey(key)).ToString();
        }

        public static int getSubCategoryByValue(string value)
        {
            return Convert.ToInt32(
                getSubCategory().GetByIndex(getSubCategory().IndexOfValue(value)));
        }
    }

    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<SubCategory> SubCategory { get; private set; }

        public Category(int id, string name, ICollection<SubCategory> subCategory)
        {
            Id = id;
            Name = name;
            SubCategory = subCategory;
        }
    }

    public class SubCategory
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public SubCategory(int id ,string name)
        {
            Id = id;
            Name = name;            
        }
    }
    
    public class CategoryList
    {
        public List<Category> Category { get; private set; }

        public CategoryList()
        {
            Category = new List<Category> {
                    new Category(10, "Celulares e Telefones",
                         new List<SubCategory> {
                             new SubCategory (1001, "Acessórios para Celulares"),
                             new SubCategory (1002, "Celulares e Smartphones"),
                             new SubCategory (1003, "Peças para Celular"),
                             new SubCategory (1004, "Telefones"),
                             new SubCategory (1005, "Outros")
                    }),
                    new Category(11, "Informática",
                        new List<SubCategory> {
                            new SubCategory (1101, "Acessórios para PC"),
                            new SubCategory (1102, "Acessórios para Notebook"),
                            new SubCategory (1103, "Componentes para PC"),
                            new SubCategory (1104, "Computadores Completos"),
                            new SubCategory (1105, "Impressoras e Acessórios"),
                            new SubCategory (1106, "Notebook"),
                            new SubCategory (1107, "Programas e Jogos"),
                            new SubCategory (1108, "Projetores e Acessórios"),
                            new SubCategory (1109, "Redes e Wi-Fi"),
                            new SubCategory (1100, "Tablets e Acessórios"),
                            new SubCategory (1111, "Outros")
                        }),
                   new Category(12, "Eletrônicos, Áudio e Vídeo",
                        new List<SubCategory> {
                            new SubCategory (1201, "Acessórios para Áudio e Vídeo"),
                            new SubCategory (1202, "Áudio para Casa"),
                            new SubCategory (1203, "Áudio Profissional"),
                            new SubCategory (1204, "Áudio Portátil"),
                            new SubCategory (1205, "Câmeras Fotográficas e Acessórios"),
                            new SubCategory (1206, "Drones e Acessórios"),
                            new SubCategory (1207, "Fones de Ouvido"),
                            new SubCategory (1208, "Projetores e Telas"),
                            new SubCategory (1209, "Peças e Componentes Elétricos"),
                            new SubCategory (1210, "Segurança"),
                            new SubCategory (1211, "TVs e Acessórios"),
                            new SubCategory (1212, "Video Games e Acessórios"),
                            new SubCategory (1213, "Outros")
                    }),
                   new Category(13, "Acessórios para Veículos",
                        new List<SubCategory> {
                            new SubCategory (1301, "Acessórios para Carros"),
                            new SubCategory (1302, "Acessórios para Motos"),
                            new SubCategory (1303, "Peças para carros"),
                            new SubCategory (1304, "Peças para motos"),
                            new SubCategory (1305, "Pneus para Carros"),
                            new SubCategory (1306, "Pneus para Motos"),
                            new SubCategory (1307, "Som Automotivo"),
                            new SubCategory (1308, "Veículos Pesados"),
                            new SubCategory (1309, "Outros")
                    }),
                   new Category(14, "Produtos de Beleza",
                        new List<SubCategory> {
                            new SubCategory (1401, "Acessórios de Beleza"),
                            new SubCategory (1402, "Cosméticos"),
                            new SubCategory (1403, "Eletrodomésticos para Beleza"),
                            new SubCategory (1404, "Esmaltes"),
                            new SubCategory (1405, "Maquiagem"),
                            new SubCategory (1406, "Perfumes"),
                            new SubCategory (1407, "Produtos para Cabelo"),
                            new SubCategory (1408, "Outros")
                    }),
                   new Category(15, "Esporte e Lazer",
                        new List<SubCategory> {
                            new SubCategory (1501, "Alpinismo"),
                            new SubCategory (1502, "Camping"),
                            new SubCategory (1503, "Caça"),
                            new SubCategory (1504, "Ciclismo"),
                            new SubCategory (1505, "Equipamentos em Geral"),
                            new SubCategory (1506, "Esportes Aquáticos"),
                            new SubCategory (1507, "Fitness e Musculação"),
                            new SubCategory (1508, "Futebol"),
                            new SubCategory (1509, "Patins e Skates"),
                            new SubCategory (1510, "Pesca"),
                            new SubCategory (1511, "Suplementos e Vitaminas"),
                            new SubCategory (1512, "Outros")
                    }),
                   new Category(16, "Casa e Eletrodomésticos",
                        new List<SubCategory> {
                            new SubCategory (1601, "Ar e Ventilação"),
                            new SubCategory (1602, "Bebedouros e Purificadores"),
                            new SubCategory (1603, "Decoração"),
                            new SubCategory (1604, "Eletroportáteis"),
                            new SubCategory (1605, "Forno e Fogões"),
                            new SubCategory (1606, "Geladeiras e Freezers"),
                            new SubCategory (1607, "Iluminação Residencial"),
                            new SubCategory (1608, "Lava Louças e Acessórios"),
                            new SubCategory (1609, "Máquinas de Lavar"),
                            new SubCategory (1610, "Para o Banheiro"),
                            new SubCategory (1611, "Para a Cozinha"),
                            new SubCategory (1612, "Para o Quarto"),
                            new SubCategory (1613, "Para o Jardim"),
                            new SubCategory (1614, "Peças e Acessórios"),
                            new SubCategory (1615, "Outros")
                    }),
                   new Category(17, "Ferramentas E Indústria",
                        new List<SubCategory> {
                            new SubCategory (1701, "Acessórios para Ferramentas"),
                            new SubCategory (1702, "Comércio"),
                            new SubCategory (1703, "Ferramentas Elétricas"),
                            new SubCategory (1704, "Ferramantas Manuais"),
                            new SubCategory (1705, "Equipamento para Escritórios"),
                            new SubCategory (1706, "Indústria Agrícola"),
                            new SubCategory (1707, "Indústria Automotiva"),
                            new SubCategory (1708, "Indústria Gastronômica"),
                            new SubCategory (1709, "Indústria Gráfica e Impressão"),
                            new SubCategory (1710, "Indústria Pesada"),
                            new SubCategory (1711, "Indústria Plástica e Química"),
                            new SubCategory (1712, "Indústria Têxtil e Confecção"),
                            new SubCategory (1713, "Medições e Instrumentação"),
                            new SubCategory (1714, "Outros")
                    }),
                   new Category(18, "Materiais de Construção",
                        new List<SubCategory> {
                            new SubCategory (1801, "Ferragens"),
                            new SubCategory (1802, "Iluminação"),
                            new SubCategory (1803, "Marcenaria e Madeiras"),
                            new SubCategory (1804, "Materiais Elétricos"),
                            new SubCategory (1805, "Materiais Hidráulicos"),
                            new SubCategory (1806, "Pisos e Revestimentos"),
                            new SubCategory (1807, "Pintura"),
                            new SubCategory (1808, "Portas, portões e Janelas"),
                            new SubCategory (1809, "Segurança e Comunicação"),
                            new SubCategory (1810, "Outros")
                    }),
                   new Category(19, "Brinquedos e Hobby",
                        new List<SubCategory> {
                            new SubCategory (1901, "Bonecas e Acessórios"),
                            new SubCategory (1902, "Bonecos e Acessórios"),
                            new SubCategory (1903, "Carrinho e veículo"),
                            new SubCategory (1904, "Jogos"),
                            new SubCategory (1905, "Mini Veículos e Bicicletas"),
                            new SubCategory (1906, "Outros")
                    }),
                   new Category(20, "Moda Feminina",
                        new List<SubCategory> {
                            new SubCategory (2001, "Blusas e Camisetas"),
                            new SubCategory (2002, "Bermudas"),
                            new SubCategory (2003, "Bolsas"),
                            new SubCategory (2004, "Calças"),
                            new SubCategory (2005, "Casacos"),
                            new SubCategory (2006, "Joias"),
                            new SubCategory (2007, "Macacão"),
                            new SubCategory (2008, "Meias"),
                            new SubCategory (2009, "Mochilas"),
                            new SubCategory (2010, "Moda Íntima"),
                            new SubCategory (2011, "Moda Praia"),
                            new SubCategory (2012, "Óculos de Sol"),
                            new SubCategory (2013, "Relógios"),
                            new SubCategory (2014, "Saias"),
                            new SubCategory (2015, "Sapatos"),
                            new SubCategory (2016, "Sandálias"),
                            new SubCategory (2017, "Tênis"),
                            new SubCategory (2018, "Ternos"),
                            new SubCategory (2019, "Vestidos"),
                            new SubCategory (2020, "Outros")
                    }),
                   new Category(21, "Moda Masculina",
                        new List<SubCategory> {
                            new SubCategory (2101, "Blusas e Camisetas"),
                            new SubCategory (2102, "Bermudas"),
                            new SubCategory (2103, "Pastas"),
                            new SubCategory (2104, "Calças"),
                            new SubCategory (2105, "Casacos"),
                            new SubCategory (2106, "Joias"),
                            new SubCategory (2107, "Macacão"),
                            new SubCategory (2108, "Meias"),
                            new SubCategory (2109, "Mochilas"),
                            new SubCategory (2110, "Moda Praia"),
                            new SubCategory (2111, "Moda Íntima"),
                            new SubCategory (2112, "Óculos de Sol"),
                            new SubCategory (2113, "Relógios"),
                            new SubCategory (2114, "Sapatos"),
                            new SubCategory (2115, "Sandálias"),
                            new SubCategory (2116, "Tênis"),
                            new SubCategory (2117, "Ternos"),
                            new SubCategory (2118, "Shorts"),
                            new SubCategory (2119, "Outros")
                    }),
                   new Category(22, "Moda Infantil",
                        new List<SubCategory> {
                            new SubCategory (2201, "Acessórios para Bebês"),
                            new SubCategory (2202, "Blusas e Camisetas"),
                            new SubCategory (2203, "Bermudas"),
                            new SubCategory (2204, "Calças"),
                            new SubCategory (2205, "Casacos"),
                            new SubCategory (2206, "Macacão"),
                            new SubCategory (2207, "Meias"),
                            new SubCategory (2208, "Mochilas"),
                            new SubCategory (2209, "Moda Praia"),
                            new SubCategory (2210, "Moda Íntima"),
                            new SubCategory (2211, "Óculos de Sol"),
                            new SubCategory (2212, "Relógios"),
                            new SubCategory (2213, "Roupa para Bebês"),
                            new SubCategory (2214, "Sapatos"),
                            new SubCategory (2215, "Tênis"),
                            new SubCategory (2216, "Ternos"),
                            new SubCategory (2217, "Saias"),
                            new SubCategory (2218, "Sandálias"),
                            new SubCategory (2219, "Shorts"),
                            new SubCategory (2220, "Vestidos"),
                            new SubCategory (2221, "Outros")
                    }),
                   new Category(23, "Livraria e Papelaria",
                        new List<SubCategory> {
                            new SubCategory (2301, "Agendas"),
                            new SubCategory (2302, "Apontadores"),
                            new SubCategory (2303, "Borrachas"),
                            new SubCategory (2304, "Cadernos"),
                            new SubCategory (2305, "Canetas"),
                            new SubCategory (2306, "Estojos"),
                            new SubCategory (2307, "Lapiseiras"),
                            new SubCategory (2308, "Lápis"),
                            new SubCategory (2309, "Livros"),
                            new SubCategory (2310, "Mochilas"),
                            new SubCategory (2311, "Papel"),
                            new SubCategory (2312, "Réguas"),
                            new SubCategory (2313, "Tesouras"),
                            new SubCategory (2314, "Outros")
                    }),
                   new Category(24, "Moveis",
                        new List<SubCategory> {
                            new SubCategory (2401, "Armários"),
                            new SubCategory (2402, "Armários para Cozinha"),
                            new SubCategory (2403, "Armários para Banheiro"),
                            new SubCategory (2404, "Cadeiras"),
                            new SubCategory (2405, "Camas"),
                            new SubCategory (2406, "Escrivaninha"),
                            new SubCategory (2407, "Estantes"),
                            new SubCategory (2408, "Moveis para Escritório"),
                            new SubCategory (2409, "Guarda-roupas"),
                            new SubCategory (2410, "Mesas"),
                            new SubCategory (2411, "Mesas para Computador"),
                            new SubCategory (2412, "Nichos"),
                            new SubCategory (2413, "Paines para TV"),
                            new SubCategory (2414, "Penteadeiras"),
                            new SubCategory (2415, "Poltronas"),
                            new SubCategory (2416, "Prateleiras"),
                            new SubCategory (2417, "Outros")
                    }),
                   new Category(25, "Outros",
                        new List<SubCategory> {
                            new SubCategory (2501, "Acessórios para Viagens"),
                            new SubCategory (2502, "Artesanato")
                    })
            };
        }
    }


}
