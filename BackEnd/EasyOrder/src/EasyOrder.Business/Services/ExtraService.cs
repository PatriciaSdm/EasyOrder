using EasyOrder.Business.Interfaces.INotifications;
using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Interfaces.Services;
using EasyOrder.Business.Models;
using EasyOrder.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Services
{
    public class ExtraService : Service, IExtraService
    {
        private readonly IExtraRepository _extraRepository;

        public ExtraService(IExtraRepository ExtraRepository,
                                 INotifier notifier) : base(notifier)
        {
            _extraRepository = ExtraRepository;
        }

        public async Task<bool> Adicionar(Extra Extra)
        {
            if (!ExecutarValidacao(new ExtraValidation(), Extra)) return false;

            if (_extraRepository.Find(f => f.Name.Equals(Extra.Name)).Result.Any())
            {
                Notify("Já existe um Extra com este nome informado.");
                return false;
            }

            await _extraRepository.Include(Extra);
            return true;
        }

        public async Task<bool> Atualizar(Extra Extra)
        {
            if (!ExecutarValidacao(new ExtraValidation(), Extra)) return false;

            if (_extraRepository.Find(f => f.Name.Equals(Extra.Name) && f.Id != Extra.Id).Result.Any())
            {
                Notify("Já existe um Extra com este documento infomado.");
                return false;
            }

            await _extraRepository.Update(Extra);
            return true;
        }

 

        public async Task<bool> Remover(Guid id)
        {
            //if (_extraRepository.GetCategoryWithExtra(id).Result.Produtos.Any())
            //{
            //    Notificar("O Extra possui produtos cadastrados!");
            //    return false;
            //}

            //var endereco = await _enderecoRepository.ObterEnderecoPorExtra(id);

            //if (endereco != null)
            //{
            //    await _enderecoRepository.Remover(endereco.Id);
            //}

            await _extraRepository.Delete(id);
            return true;
        }

        public void Dispose()
        {
            _extraRepository?.Dispose();
        }
    }
}
