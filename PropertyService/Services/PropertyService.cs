using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyService.Data;
using PropertyService.Models;

namespace PropertyService.Services
{
    public class PropertyService
    {
        private readonly PropertyDbContext _context;

        public PropertyService(PropertyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Property>> GetPropertiesAsync()
        {
            var properties = await _context.Properties.OrderByDescending(p => p.Id).ToListAsync();

            if (properties.Count == 0)
            {
                var sampleProperties = new List<Property>
                {
                    new Property { 
                        Name = "Moradia independente à venda rua Dr Manuel Simões Barreiro", 
                        Type = "T3 130 m² área bruta", 
                        Location = "Figueiró dos Vinhos e Bairradas, Figueiró dos Vinhos", 
                        Price = 195000, 
                        Description = "Moradia com 3 quartos, localizada em zona calma, rodeada de espaços verdes com vista para a serra, que lhe proporcionará um descanso tranquilo.<br>Próximo de praias fluviais e das fragas de São Simão, Foz de Alge, Praia fluvial de Aldeia Ana de Avis para momentos em família únicos e memoráveis.<br>Localização e envolvente Esta moradia localiza-se em Enchecamas/ Figueiró dos Vinhos, zona nordeste do distrito de Leiria."
                    },

                    new Property { 
                        Name = "Moradia independente à venda na rua Santo António", 
                        Type = "T3 252 m² área bruta", 
                        Location = "Figueiró dos Vinhos e Bairradas, Figueiró dos Vinhos", 
                        Price = 250000, 
                        Description = "Moradia T3 com uma área total de 136 m2, situado no concelho de Figueiró dos Vinhos, distrito de Leiria. <br>Zona com razoáveis acessibilidades, com proximidade às principais vias rodoviárias (a 1 min da N237, a 6 min da IC8 e a 11 min da A13).<br>O imóvel está localizado próximo à zona de comércio, serviços e escolas.<br>Fica a 3 minutos do centro de Figueiró dos Vinhos, a 3 minutos da Câmara Municipal, fica a 1 minuto da Escola Secundaria de Figueiró dos Vinhos e a 14 min do Hospital Fundação Nossa Senhora da Guia."
                    },

                    new Property { 
                        Name = "Moradia Geminada em Aguda", 
                        Type = "T4 173 m² área bruta", 
                        Location = "Bairro Industrial 3260-031 Aguda, Figueiró dos Vinhos", 
                        Price = 450000, 
                        Description = "MORADIA V2 GEMINADA 3 PISOS NO CENTRO DA CIDADE <br>O R/C é composto por:<br> Sala com lareira, Cozinha, Varanda, Despensa No 1º andar, 2 quartos, 1 casa de banho completa<br><br>Localizada à 1:40h do Aeroporto de Lisboa, 1h da cidade de Leiria, 40minutos de Coimbra e 1:45 do Porto."
                    },

                    new Property {
                        Name = "Moradia geminada à venda em Figueiró dos Vinhos",
                        Type = "T3+1 373 m² área bruta",
                        Location = "Bairro Industrial 3260-031 Aguda, Figueiró dos Vinhos",
                        Price = 230000,
                        Description = "Moradia T3+1, Figueiró dos Vinhos, Leiria<br>Venha conhecer a moradia dos seus sonhos!<br>Composta por três pisos, RCH, Cave e Sótão.<br>Jardim na frente da moradia.<br>Tem um excelente logradouro com churrasqueira e forno.<br>Parqueamento exterior para vários carros."
                    },

                    new Property {
                        Name = "Casa ou moradia senhorial em Figueiró dos Vinhos",
                        Type = "T5 431 m² área bruta",
                        Location = "Centro da vila de Figueiró dos Vinhos",
                        Price = 91150,
                        Description = "Descubra esta majestosa casa senhorial em Figueiró dos Vinhos: um tesouro oculto que aguarda para ser restaurado e trazer à vida toda a sua grandiosidade.<br>Localizada no coração da encantadora vila de Figueiró dos Vinhos, esta magnífica propriedade histórica é uma oportunidade única para os amantes de património e arquitetura: esta moradia é um verdadeiro testemunho de uma época passada, trazendo consigo a nostalgia e o esplendor de tempos antigos."
                    }
                };

                await _context.Properties.AddRangeAsync(sampleProperties);
                await _context.SaveChangesAsync();

                properties = await _context.Properties.OrderByDescending(p => p.Id).ToListAsync();
            }

            return properties;
        }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties.FindAsync(id);
        }

        public async Task CreatePropertyAsync(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            _context.Entry(property).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePropertyAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property != null)
            {
                _context.Properties.Remove(property);
                await _context.SaveChangesAsync();
            }
        }
    }
}
