using Loja.Domain.Entites;
using Loja.Domain.Repositories;
using Loja.Domain.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Loja.Domain.Entites.Request.Produto;

namespace Loja.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProdutoService(IProdutoRepository produtoRepository, IWebHostEnvironment web)
        {
            _produtoRepository = produtoRepository;
            webHostEnvironment = web;
        }
        public async Task Add(AddProduto entity)
        {
            var aux = new Produto
            {
                Id = entity.Id,
                Valor = entity.Valor,
                Descricao = entity.Descricao
            };
            aux.Foto = UploadedFile(entity.File);
            await _produtoRepository.Add(aux);
        }

        public async Task<ICollection<Produto>> GetAll()
        {
            return await _produtoRepository.GetAll();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _produtoRepository.GetById(id);
        }

        public async Task Remove(int id)
        {
            await _produtoRepository.Remove(id);
        }

        private string UploadedFile(IFormFile foto)
        {
            string nomeUnicoArquivo = null;
            if (foto != null)
            {
                string pastaFotos = Path.Combine("~/Imagens", "Produtos");
                if (!Directory.Exists(pastaFotos))
                    Directory.CreateDirectory(pastaFotos);

                nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + foto.FileName;
                string caminhoArquivo = Path.Combine(pastaFotos, nomeUnicoArquivo);
                using var fileStream = new FileStream(caminhoArquivo, FileMode.Create);
                foto.CopyTo(fileStream);
            }
            return nomeUnicoArquivo;
        }
    }
}
