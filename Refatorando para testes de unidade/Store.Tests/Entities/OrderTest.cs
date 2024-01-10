using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain;
using Store.Domain.Entities;
using Store.Domain.Enuns;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTTests
    {

        private readonly Customer _customer = new Customer("Gabriel Garcia", "gabriel@gmail.com");
        private readonly Product _product = new Product("Produto 1", 10, true);
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            var order = new Order(_customer, 0, null);
            Assert.AreEqual(8, order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            var order = new Order(_customer, 0, null);
            Assert.AreEqual(order.Status, EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            var order = new Order(_customer, 0, null);

            order.AddItem(_product, 1);
            order.Pay(10);

            Assert.AreEqual(order.Status, EOrderStatus.WaitingDelivery);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            var order = new Order(_customer, 0, null);

            order.Cancel();

            Assert.AreEqual(order.Status, EOrderStatus.Canceled);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_novo_item_sem_o_mesmo_nao_deve_ser_adicionado()
        {
            var order = new Order(_customer, 0, null);

            order.AddItem(null, 0);

            Assert.AreEqual(order.Items.Count, 0);
        }

        [DataTestMethod]
        [TestCategory("Domain")]
        [DataRow(-1)]
        [DataRow(0)]
        public void Dado_um_novo_item_com_quantidade_zerou_ou_menor_nao_deve_ser_adicionado(int quantity)
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_product, quantity);

            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_seu_total_deve_ser_50()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_product, 5);

            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_customer, 0, _discount);
            order.AddItem(_product, 7);

            Assert.AreEqual(order.Total(), 60);
        }
    }
}