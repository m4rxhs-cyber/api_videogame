using Microsoft.AspNetCore.Mvc;
using projetoProva.Models;
using System;


namespace projetoProva.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class VideogameController : ControllerBase
    {
        private BDContexto contexto;
        public VideogameController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }
        
        [HttpGet]
         public List<Videogame> Listar()
        {
            return contexto.Videogames.ToList(); 
        }

        [HttpGet]
        public List<Videogame> ListarPorFabricante(string fabricante)
        {
            return contexto.Videogames.Where(p => p.Fabricante == fabricante).Select
            (
                p => new Videogame
                {
                    Id = p.Id,
                    Nome= p.Nome,
                    Fabricante = p.Fabricante,
                    Geracao = p.Geracao,
                    Ano = p.Ano
                }
            ).ToList();
        }


        [HttpGet]
        public List<Videogame> Visualizar(int id)
        {
            return contexto.Videogames.Where(p => p.Id == id).Select
            (
                p => new Videogame
                {
                    Id = p.Id,
                    Nome= p.Nome,
                    Fabricante = p.Fabricante,
                    Geracao = p.Geracao,
                    Ano = p.Ano
                }
            ).ToList();
        }

        [HttpPost]
        public string Cadastrar([FromBody]Videogame novoVideogame)
        {
            try
            {
                contexto.Add(novoVideogame);
                contexto.SaveChanges();
                return "Videogame cadastrado com sucesso!";
            }
            catch (System.Exception e)
            {
               return "Erro ao cadastrar: " + e.Message; 
            }

        }

        [HttpDelete]
        public string Excluir([FromBody]int id)
        {
            Videogame? dados = contexto.Videogames.FirstOrDefault(p => p.Id == id);
            if (dados == null) 
            {
                return "Id inexistente!";
            }
            else 
            {
                try
                {
                    contexto.Remove(dados);
                    contexto.SaveChanges();
                    return "Videogame removido!";
                }
                catch (System.Exception e)
                {
                    return "Erro ao fazer a exclusão! \n Erro: " + e.Message;   
                }
            }       
        }
        
    }
}