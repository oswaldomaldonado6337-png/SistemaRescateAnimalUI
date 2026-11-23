
using SistemaRescateAnimal.Models;
using SistemaRescateAnimalUI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    public partial class FrmVentas : Form
    {
        private readonly ProductoDAO _productoDAO = new ProductoDAO();
        private readonly List<DetallePedido> _carrito = new List<DetallePedido>();

        public FrmVentas()
        {
            InitializeComponent();
            CargarCatalogoInicial();
        }

        private void CargarCatalogoInicial()
        {
            try
            {
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = _productoDAO.BuscarPorNombreLike("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el catálogo inicial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Búsqueda con like en tiempo real
        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = _productoDAO.BuscarPorNombreLike(txtBuscarNombre.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en búsqueda dinámica: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Búsqueda  por ID
        private void btnBuscarId_Click(object sender, EventArgs e)
        {
            string id = txtBuscarId.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                CargarCatalogoInicial();
                return;
            }

            try
            {
                Producto prod = _productoDAO.BuscarPorId(id);
                if (prod != null)
                {
                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = new List<Producto> { prod };
                }
                else
                {
                    MessageBox.Show($"No se encontró ningún producto activo con el ID '{id}'.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar por ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Añadir al carrito con validación  de Stock
        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null || !(dgvProductos.CurrentRow.DataBoundItem is Producto productoSeleccionado))
            {
                MessageBox.Show("Seleccione un producto de la tabla de resultados.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidadSolicitada = (int)numCantidad.Value;
            if (cantidadSolicitada <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DetallePedido itemExistente = _carrito.FirstOrDefault(x => x.IdProducto == productoSeleccionado.IdProducto);
            int cantidadAcumulada = (itemExistente != null ? itemExistente.Cantidad : 0) + cantidadSolicitada;

            // Validación del stock disponible
            if (cantidadAcumulada > productoSeleccionado.Stock)
            {
                MessageBox.Show(
                    $"Stock insuficiente para '{productoSeleccionado.Nombre}'.\nDisponible en inventario: {productoSeleccionado.Stock}\nSolicitado total: {cantidadAcumulada}",
                    "Inventario Insuficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (itemExistente != null)
            {
                itemExistente.Cantidad = cantidadAcumulada;
            }
            else
            {
                _carrito.Add(new DetallePedido
                {
                    IdProducto = productoSeleccionado.IdProducto,
                    NombreProducto = productoSeleccionado.Nombre,
                    Cantidad = cantidadSolicitada,
                    PrecioUnitario = productoSeleccionado.Precio
                });
            }

            ActualizarVistaCarrito();
        }

        // Cálculo de subtotales y total general en tiempo real
        private void ActualizarVistaCarrito()
        {
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = _carrito.ToList();

            if (dgvCarrito.Columns["PrecioUnitario"] != null)
                dgvCarrito.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
            if (dgvCarrito.Columns["Subtotal"] != null)
                dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Format = "C2";

            decimal totalGeneral = 0m;
            foreach (var item in _carrito)
            {
                totalGeneral += item.Subtotal;
            }

            lblTotalVenta.Text = $"Total: {totalGeneral:C2}";
        }

        // Quitar producto seleccionado del carrito 
        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow != null && dgvCarrito.CurrentRow.DataBoundItem is DetallePedido item)
            {
                _carrito.Remove(item);
                ActualizarVistaCarrito();
            }
        }

        // Validación final antes de la  transaccion
        private void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            if (_carrito.Count == 0)
            {
                MessageBox.Show("El carrito de compras está vacío. Añada al menos un producto antes de confirmar.", "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Pedido validado correctamente ({_carrito.Count} partidas). Listo para persistencia transaccional.", "Confirmación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}