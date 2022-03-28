using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;

namespace LanchesMac.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _apDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext apDbContext, CarrinhoCompra carrinhoCompra)
        {
            _apDbContext = apDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            //criação do pedido (id do pedido), para utlizar na criação do pedidodetalhe logo abaixo
            pedido.PedidoEnviado = DateTime.Now;
            _apDbContext.Pedidos.Add(pedido);
            _apDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            //montando itens do pedidodetalhe
            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                //cria objeto do pedidodetalhe
                var pedidoDetail = new PedidoDetalhe
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Lanche.Preco
                };
                _apDbContext.PedidoDetalhes.Add(pedidoDetail);
            }
            _apDbContext.SaveChanges();
        }
    }
}
