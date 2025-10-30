using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using SistemaVentas.Models;

namespace SistemaVentas.Forms
{
    public partial class FormProductos : Form
    {
        private VentasContext _context;
        private bool _modoEdicion = false;
        private int _productoIdEdicion = 0;

        public FormProductos()
        {
            InitializeComponent();
            _context = new VentasContext();
        }

        private async void FormProductos_Load(object sender, EventArgs e)
        {
            try
            {
                InicializarComboOrdenamiento();
                await CargarCategoriasDinamicas();
                MostrarVistaCategorias(); // Mostrar categorías en lugar de productos
                cmbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar formulario de productos: {ex.Message}\n\nDetalle: {ex.StackTrace}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarComboOrdenamiento()
        {
            var opciones = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Por nombre (A-Z)", "nombre"),
                new KeyValuePair<string, string>("Más nuevos primero", "fecha_nuevo"),
                new KeyValuePair<string, string>("Más viejos primero", "fecha_viejo")
            };

            cmbOrdenamiento.DisplayMember = "Key";
            cmbOrdenamiento.ValueMember = "Value";
            cmbOrdenamiento.DataSource = opciones;
            cmbOrdenamiento.SelectedIndex = 0;
        }

        private async void CargarProductos(string filtro = "", string ordenamiento = "nombre")
        {
            await CargarProductosFiltrados(filtro, ordenamiento, "", false);
        }

        private async Task CargarProductosFiltrados(string filtro = "", string ordenamiento = "nombre", string categoria = "", bool soloStockBajo = false)
        {
            try
            {
                var query = _context.Productos.Where(p => p.Activo);

                if (!string.IsNullOrEmpty(filtro))
                {
                    query = query.Where(p => p.Codigo.Contains(filtro) || 
                                           p.Nombre.Contains(filtro) ||
                                           p.Categoria.Contains(filtro));
                }

                // Filtro por categoría
                if (!string.IsNullOrEmpty(categoria))
                {
                    query = query.Where(p => p.Categoria == categoria);
                }

                // Filtro por stock bajo (menos de 10 unidades)
                if (soloStockBajo)
                {
                    query = query.Where(p => p.Stock < 10);
                }

                // Aplicar ordenamiento según la opción seleccionada
                query = ordenamiento switch
                {
                    "fecha_nuevo" => query.OrderByDescending(p => p.FechaCreacion),
                    "fecha_viejo" => query.OrderBy(p => p.FechaCreacion),
                    "nombre" => query.OrderBy(p => p.Nombre),
                    _ => query.OrderBy(p => p.Nombre)
                };

                var productos = await query.ToListAsync();

                dgvProductos.DataSource = productos.Select(p => new
                {
                    p.Id,
                    Código = p.Codigo,
                    Nombre = p.Nombre,
                    Descripción = p.Descripcion,
                    Precio = p.Precio.ToString("C"),
                    Stock = p.Stock,
                    Categoría = p.Categoria,
                    ValorStock = p.ValorStock.ToString("C"),
                    FechaCreación = p.FechaCreacion.ToString("dd/MM/yyyy"),
                    EstadoStock = p.Stock < 5 ? "CRÍTICO" : p.Stock < 10 ? "BAJO" : "NORMAL"
                }).ToList();

                // Ocultar columna ID
                if (dgvProductos.Columns.Contains("Id"))
                    dgvProductos.Columns["Id"].Visible = false;

                // Colorear filas según el stock
                ColorearFilasSegunStock();

                // Actualizar título con información del filtro
                ActualizarTituloConFiltros(productos.Count, categoria, soloStockBajo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorearFilasSegunStock()
        {
            try
            {
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (row.Cells["Stock"].Value != null)
                    {
                        int stock = Convert.ToInt32(row.Cells["Stock"].Value);
                        
                        if (stock < 5)
                        {
                            // Stock crítico - rojo
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(183, 28, 28);
                        }
                        else if (stock < 10)
                        {
                            // Stock bajo - amarillo
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 181);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(251, 140, 0);
                        }
                        else
                        {
                            // Stock normal - blanco
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error coloreando filas: {ex.Message}");
            }
        }

        private void ActualizarTituloConFiltros(int cantidadProductos, string categoria, bool soloStockBajo)
        {
            string titulo = "Gestión de Productos";
            
            if (!string.IsNullOrEmpty(categoria))
            {
                titulo += $" - Categoría: {categoria}";
            }
            else if (soloStockBajo)
            {
                titulo += " - ⚠️ Stock Bajo";
            }

            titulo += $" ({cantidadProductos} productos)";
            this.Text = titulo;
        }

        private async void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && (string.IsNullOrEmpty(_categoriaSeleccionada) && !_mostrarStockBajo))
                {
                    // Estamos en vista de categorías, obtener la categoría seleccionada
                    var row = dgvProductos.Rows[e.RowIndex];
                    if (row.Cells["Categoría"]?.Value != null)
                    {
                        string categoria = row.Cells["Categoría"].Value.ToString() ?? "";
                        if (!string.IsNullOrEmpty(categoria))
                        {
                            await SeleccionarCategoria(categoria);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar categoría: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private string ObtenerOrdenamiento()
        {
            if (cmbOrdenamiento?.SelectedValue != null)
            {
                return cmbOrdenamiento.SelectedValue.ToString() ?? "nombre";
            }
            return "nombre";
        }

        private void cmbOrdenamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void rbCodigoAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCodigoAutomatico.Checked)
            {
                txtCodigo.Text = "Se generará automáticamente";
                txtCodigo.Enabled = false;
                txtCodigo.BackColor = Color.LightGray;
            }
        }

        private void rbCodigoManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCodigoManual.Checked)
            {
                txtCodigo.Text = "";
                txtCodigo.Enabled = true;
                txtCodigo.BackColor = Color.White;
                txtCodigo.PlaceholderText = "Ingrese el código del producto...";
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarFormulario("Nuevo Producto");
            LimpiarFormulario();
            _modoEdicion = false;
            
            // Configurar opciones de código para nuevo producto
            rbCodigoAutomatico.Checked = true;
            rbCodigoManual.Checked = false;
            txtCodigo.Text = "Se generará automáticamente";
            txtCodigo.Enabled = false;
            txtCodigo.BackColor = Color.LightGray;
            pnlCodigoOpciones.Visible = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para modificar.", 
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var productoId = (int)dgvProductos.CurrentRow.Cells["Id"].Value;
            CargarProductoEnFormulario(productoId);
            MostrarFormulario("Modificar Producto");
            _modoEdicion = true;
            _productoIdEdicion = productoId;
            
            // En modo edición, ocultar opciones y permitir edición directa
            pnlCodigoOpciones.Visible = false;
            txtCodigo.Enabled = true;
            txtCodigo.BackColor = Color.White;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", 
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resultado = MessageBox.Show("¿Está seguro de eliminar este producto?", 
                                          "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    var productoId = (int)dgvProductos.CurrentRow.Cells["Id"].Value;
                    var producto = await _context.Productos.FindAsync(productoId);

                    if (producto != null)
                    {
                        // Eliminación lógica
                        producto.Activo = false;
                        await _context.SaveChangesAsync();
                        
                        MessageBox.Show("Producto eliminado correctamente.", 
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar producto: {ex.Message}", 
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                if (_modoEdicion)
                {
                    var producto = await _context.Productos.FindAsync(_productoIdEdicion);
                    if (producto != null)
                    {
                        ActualizarProductoDesdeFormulario(producto);
                    }
                }
                else
                {
                    var producto = new Producto();
                    ActualizarProductoDesdeFormulario(producto);
                    _context.Productos.Add(producto);
                }

                await _context.SaveChangesAsync();
                
                MessageBox.Show("Producto guardado correctamente.", 
                              "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                OcultarFormulario();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar producto: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OcultarFormulario();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            btnModificar.Enabled = dgvProductos.CurrentRow != null;
            btnEliminar.Enabled = dgvProductos.CurrentRow != null;
        }

        private void MostrarFormulario(string titulo)
        {
            lblTitulo.Text = titulo;
            panelFormulario.Visible = true;
            txtCodigo.Focus();
        }

        private void OcultarFormulario()
        {
            panelFormulario.Visible = false;
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            numPrecio.Value = 0.01m;
            numStock.Value = 0;
            cmbCategoria.SelectedIndex = 0;
        }

        private async void CargarProductoEnFormulario(int productoId)
        {
            var producto = await _context.Productos.FindAsync(productoId);
            if (producto != null)
            {
                txtCodigo.Text = producto.Codigo;
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;
                numPrecio.Value = producto.Precio;
                numStock.Value = producto.Stock;
                cmbCategoria.Text = producto.Categoria;
            }
        }

        private void ActualizarProductoDesdeFormulario(Producto producto)
        {
            // En modo edición, usar el código del textbox
            if (_modoEdicion)
            {
                producto.Codigo = txtCodigo.Text.Trim();
            }
            else
            {
                // En modo nuevo, usar automático o manual según la opción elegida
                if (rbCodigoAutomatico.Checked)
                {
                    producto.Codigo = GenerarCodigoProducto();
                }
                else if (rbCodigoManual.Checked)
                {
                    producto.Codigo = txtCodigo.Text.Trim();
                }
            }
            
            producto.Nombre = txtNombre.Text.Trim();
            producto.Descripcion = txtDescripcion.Text.Trim();
            producto.Precio = numPrecio.Value;
            producto.Stock = (int)numStock.Value;
            producto.Categoria = cmbCategoria.Text;

            if (!_modoEdicion)
            {
                producto.FechaCreacion = DateTime.Now;
                producto.Activo = true;
            }
        }

        private string GenerarCodigoProducto()
        {
            try
            {
                // Obtener el último producto para generar el siguiente código
                var ultimoProducto = _context.Productos
                    .OrderByDescending(p => p.Id)
                    .FirstOrDefault();

                int siguienteNumero = 1;
                if (ultimoProducto != null)
                {
                    // Extraer el número del código (ej: PROD001 -> 1)
                    var codigoActual = ultimoProducto.Codigo;
                    if (codigoActual.StartsWith("PROD") && codigoActual.Length >= 7)
                    {
                        var numeroStr = codigoActual.Substring(4);
                        if (int.TryParse(numeroStr, out int numero))
                        {
                            siguienteNumero = numero + 1;
                        }
                    }
                    else
                    {
                        // Si no sigue el patrón, usar el ID + 1
                        siguienteNumero = ultimoProducto.Id + 1;
                    }
                }

                // Generar código con formato PROD001, PROD002, etc.
                return $"PROD{siguienteNumero:D3}";
            }
            catch
            {
                // En caso de error, generar un código con timestamp
                return $"PROD{DateTime.Now:yyyyMMddHHmmss}";
            }
        }

        private bool ValidarFormulario()
        {
            // Validaciones para nuevo producto
            if (!_modoEdicion)
            {
                // Validar que se haya elegido una opción de código
                if (!rbCodigoAutomatico.Checked && !rbCodigoManual.Checked)
                {
                    MessageBox.Show("Debe seleccionar una opción para el código del producto.", 
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Si eligió código manual, validar que no esté vacío
                if (rbCodigoManual.Checked && string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("Debe ingresar el código del producto.", 
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigo.Focus();
                    return false;
                }

                // Si eligió código manual, validar que no exista ya
                if (rbCodigoManual.Checked)
                {
                    var codigoExiste = _context.Productos.Any(p => p.Codigo == txtCodigo.Text && p.Activo);
                    if (codigoExiste)
                    {
                        MessageBox.Show("Ya existe un producto con ese código.", 
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCodigo.Focus();
                        return false;
                    }
                }
            }
            
            // Validaciones para modo edición
            if (_modoEdicion && string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código es requerido.", "Validación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido.", "Validación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (numPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0.", "Validación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrecio.Focus();
                return false;
            }

            if (cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return false;
            }

            return true;
        }

        private string _categoriaSeleccionada = "";
        private bool _mostrarStockBajo = false;

        private void btnTodasCategorias_Click(object sender, EventArgs e)
        {
            _categoriaSeleccionada = "";
            _mostrarStockBajo = false;
            ActualizarBotonCategorias();
            
            // Ocultar DataGridView y mostrar vista de categorías
            dgvProductos.Visible = false;
            MostrarVistaCategorias();
        }

        private async void btnStockBajo_Click(object sender, EventArgs e)
        {
            _mostrarStockBajo = !_mostrarStockBajo;
            _categoriaSeleccionada = "";
            ActualizarBotonCategorias();
            
            if (_mostrarStockBajo)
            {
                // Mostrar DataGridView con productos de stock bajo
                if (panelVistaCards != null)
                    panelVistaCards.Visible = false;
                dgvProductos.Visible = true;
                
                await CargarProductosFiltrados(txtBuscar.Text, ObtenerOrdenamiento(), "", true);
            }
            else
            {
                // Volver a vista de categorías
                dgvProductos.Visible = false;
                MostrarVistaCategorias();
            }
        }

        private void ActualizarBotonCategorias()
        {
            // Los botones ahora se manejan dinámicamente en AgregarBotonesControl()
            // Esta función se mantiene para compatibilidad pero ya no es necesaria
        }

        private void btnVolverCategorias_Click(object sender, EventArgs e)
        {
            _categoriaSeleccionada = "";
            _mostrarStockBajo = false;
            ActualizarBotonCategorias();
            this.Text = "Gestión de Productos - Vista de Categorías";
            MostrarVistaCategorias();
        }

        private async Task SeleccionarCategoria(string categoria)
        {
            _categoriaSeleccionada = categoria;
            _mostrarStockBajo = false;
            ActualizarBotonCategorias();
            await CargarCategoriasDinamicas();
            
            // Ocultar panel de tarjetas y mostrar DataGrid
            panelTarjetasCategorias.Visible = false;
            dgvProductos.Visible = true;
            
            // Actualizar título para mostrar la categoría seleccionada
            this.Text = $"Gestión de Productos - Categoría: {categoria}";
            
            // Cargar productos de la categoría
            string filtro = txtBuscar.Text;
            string ordenamiento = ObtenerOrdenamiento();
            await CargarProductosFiltrados(filtro, ordenamiento, _categoriaSeleccionada, false);
        }

        private async void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Nueva Categoría";
                form.Size = new Size(400, 220);
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var lblTitulo = new Label
                {
                    Text = "Crear Nueva Categoría",
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Location = new Point(20, 15),
                    Size = new Size(350, 25)
                };

                var lblNombre = new Label
                {
                    Text = "Nombre de la categoría:",
                    Font = new Font("Segoe UI", 9F),
                    Location = new Point(20, 50),
                    Size = new Size(150, 20)
                };

                var txtNombre = new TextBox
                {
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(20, 75),
                    Size = new Size(340, 25)
                };

                var lblInfo = new Label
                {
                    Text = "La categoría aparecerá cuando crees el primer producto en ella.",
                    Font = new Font("Segoe UI", 8F),
                    ForeColor = Color.Gray,
                    Location = new Point(20, 110),
                    Size = new Size(340, 30)
                };

                var btnAceptar = new Button
                {
                    Text = "Crear",
                    Location = new Point(200, 150),
                    Size = new Size(75, 30),
                    DialogResult = DialogResult.OK,
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                var btnCancelar = new Button
                {
                    Text = "Cancelar",
                    Location = new Point(285, 150),
                    Size = new Size(75, 30),
                    DialogResult = DialogResult.Cancel,
                    BackColor = Color.FromArgb(231, 76, 60),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                form.Controls.Add(lblTitulo);
                form.Controls.Add(lblNombre);
                form.Controls.Add(txtNombre);
                form.Controls.Add(lblInfo);
                form.Controls.Add(btnAceptar);
                form.Controls.Add(btnCancelar);

                txtNombre.Focus();

                if (form.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    var nuevaCategoria = txtNombre.Text.Trim();
                    
                    // Verificar si la categoría ya existe
                    var categoriaExiste = await _context.Productos
                        .AnyAsync(p => p.Activo && p.Categoria.ToLower() == nuevaCategoria.ToLower());

                    if (categoriaExiste)
                    {
                        MessageBox.Show($"La categoría '{nuevaCategoria}' ya existe.", 
                                      "Categoría Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Mostrar mensaje de confirmación y abrir formulario de nuevo producto
                    var resultado = MessageBox.Show($"Categoría '{nuevaCategoria}' lista para usar.\n\n¿Deseas crear un producto ahora en esta categoría?", 
                                  "Categoría Creada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    
                    if (resultado == DialogResult.Yes)
                    {
                        // Agregar la nueva categoría al combo si no existe
                        if (!cmbCategoria.Items.Cast<string>().Contains(nuevaCategoria))
                        {
                            cmbCategoria.Items.Add(nuevaCategoria);
                        }
                        cmbCategoria.SelectedItem = nuevaCategoria;
                        
                        // Abrir formulario de nuevo producto
                        btnNuevo_Click(sender, e);
                    }
                    
                    // Refrescar la vista de categorías
                    MostrarVistaCategorias();
                }
            }
        }

        private async Task MostrarDialogoNuevaCategoria()
        {
            using var dialog = new Form()
            {
                Text = "Nueva Categoría",
                Size = new Size(400, 200),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblTitulo = new Label()
            {
                Text = "Nombre de la nueva categoría:",
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 20),
                Size = new Size(200, 25)
            };

            var txtCategoria = new TextBox()
            {
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 50),
                Size = new Size(340, 25)
            };

            var btnAceptar = new Button()
            {
                Text = "Crear",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(200, 100),
                Size = new Size(80, 35)
            };

            var btnCancelar = new Button()
            {
                Text = "Cancelar",
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(290, 100),
                Size = new Size(80, 35)
            };

            btnAceptar.Click += async (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtCategoria.Text))
                {
                    // Verificar si la categoría ya existe
                    var categoriaExiste = await _context.Productos
                        .AnyAsync(p => p.Categoria.ToLower() == txtCategoria.Text.Trim().ToLower());

                    if (categoriaExiste)
                    {
                        MessageBox.Show("Esta categoría ya existe.", "Categoría Duplicada", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Aquí podrías crear un producto ejemplo para la categoría o simplemente guardar la categoría
                    MessageBox.Show($"Categoría '{txtCategoria.Text.Trim()}' creada correctamente.\n" +
                                   "Ahora puedes crear productos en esta categoría.", 
                                   "Categoría Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    dialog.DialogResult = DialogResult.OK;
                    dialog.Close();

                    // Refrescar vista de categorías
                    await MostrarPanelCategorias();
                }
                else
                {
                    MessageBox.Show("Ingrese un nombre para la categoría.", "Campo Requerido", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            btnCancelar.Click += (s, e) =>
            {
                dialog.DialogResult = DialogResult.Cancel;
                dialog.Close();
            };

            dialog.Controls.AddRange(new Control[] { lblTitulo, txtCategoria, btnAceptar, btnCancelar });
            txtCategoria.Focus();

            dialog.ShowDialog(this);
        }

        private async Task CargarCategoriasDinamicas()
        {
            try
            {
                // Esta función ya no es necesaria ya que las categorías se muestran como tarjetas
                // Simplemente cargar categorías para el combo si es necesario
                var categorias = await _context.Productos
                    .Where(p => p.Activo)
                    .Select(p => p.Categoria)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToListAsync();

                // Actualizar el combo de categorías del formulario
                var categoriasCombo = new List<string> { "Seleccione una categoría..." };
                categoriasCombo.AddRange(categorias);
                
                cmbCategoria.DataSource = null;
                cmbCategoria.Items.Clear();
                cmbCategoria.Items.AddRange(categoriasCombo.ToArray());
                if (cmbCategoria.Items.Count > 0)
                    cmbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando categorías: {ex.Message}");
            }
        }

        private async void AplicarFiltros()
        {
            if (string.IsNullOrEmpty(_categoriaSeleccionada) && !_mostrarStockBajo)
            {
                MostrarVistaCategorias();
            }
            else
            {
                // Mostrar productos en DataGrid
                panelTarjetasCategorias.Visible = false;
                dgvProductos.Visible = true;
                
                string filtro = txtBuscar.Text;
                string ordenamiento = ObtenerOrdenamiento();
                await CargarProductosFiltrados(filtro, ordenamiento, _categoriaSeleccionada, _mostrarStockBajo);
            }
        }

        private async void MostrarVistaCategorias()
        {
            try
            {
                // Verificar que el panel existe
                if (panelTarjetasCategorias == null)
                {
                    // Si el panel no existe, usar el DataGridView para mostrar categorías
                    await MostrarCategoriasEnDataGrid();
                    return;
                }

                // Ocultar DataGrid y mostrar panel de tarjetas
                dgvProductos.Visible = false;
                panelTarjetasCategorias.Visible = true;
                
                // Limpiar tarjetas anteriores
                panelTarjetasCategorias.Controls.Clear();

                // Agregar botones de control en la parte superior
                AgregarBotonesControl();

                // Obtener productos y calcular estadísticas en memoria (solución para SQLite)
                var productos = await _context.Productos
                    .Where(p => p.Activo)
                    .ToListAsync();

                var estadisticasCategoria = productos
                    .GroupBy(p => p.Categoria)
                    .Select(g => new
                    {
                        Categoria = g.Key,
                        TotalProductos = g.Count(),
                        ProductosStockBajo = g.Count(p => p.Stock < 10),
                        ProductosStockCritico = g.Count(p => p.Stock < 5),
                        ValorTotal = g.Sum(p => (decimal)p.Stock * p.Precio),
                        StockTotal = g.Sum(p => p.Stock),
                        PrecioPromedio = g.Any() ? g.Average(p => p.Precio) : 0m
                    })
                    .OrderBy(x => x.Categoria)
                    .ToList();

                // Crear tarjetas de categorías
                int x = 20, y = 60; // Y=60 para dejar espacio para los botones
                int cardWidth = 200, cardHeight = 120;
                int cardsPerRow = Math.Max(1, (panelTarjetasCategorias.Width - 40) / (cardWidth + 20));

                for (int i = 0; i < estadisticasCategoria.Count; i++)
                {
                    var categoria = estadisticasCategoria[i];
                    
                    // Crear panel de tarjeta
                    var cardPanel = new Panel
                    {
                        Size = new Size(cardWidth, cardHeight),
                        Location = new Point(x, y),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Cursor = Cursors.Hand,
                        Tag = categoria.Categoria
                    };

                    // Color de fondo según estado
                    if (categoria.ProductosStockCritico > 0)
                        cardPanel.BackColor = Color.FromArgb(255, 235, 238);
                    else if (categoria.ProductosStockBajo > 0)
                        cardPanel.BackColor = Color.FromArgb(255, 248, 225);
                    else
                        cardPanel.BackColor = Color.FromArgb(232, 245, 233);

                    // Título de categoría
                    var lblTitulo = new Label
                    {
                        Text = $"📁 {categoria.Categoria}",
                        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(52, 73, 94),
                        Location = new Point(10, 10),
                        Size = new Size(180, 25),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    // Información de productos
                    var lblProductos = new Label
                    {
                        Text = $"🏷️ {categoria.TotalProductos} productos",
                        Font = new Font("Segoe UI", 9F),
                        Location = new Point(10, 40),
                        Size = new Size(180, 15)
                    };

                    // Valor total
                    var lblValor = new Label
                    {
                        Text = $"💰 {categoria.ValorTotal:C}",
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(46, 125, 50),
                        Location = new Point(10, 60),
                        Size = new Size(180, 15)
                    };

                    // Estado de stock
                    string estadoTexto = categoria.ProductosStockCritico > 0 ? 
                                       $"🔴 {categoria.ProductosStockCritico} críticos" :
                                       categoria.ProductosStockBajo > 0 ? 
                                       $"🟡 {categoria.ProductosStockBajo} bajos" : 
                                       "🟢 Stock normal";

                    var lblEstado = new Label
                    {
                        Text = estadoTexto,
                        Font = new Font("Segoe UI", 8F),
                        Location = new Point(10, 80),
                        Size = new Size(180, 15)
                    };

                    // Agregar controles a la tarjeta
                    cardPanel.Controls.Add(lblTitulo);
                    cardPanel.Controls.Add(lblProductos);
                    cardPanel.Controls.Add(lblValor);
                    cardPanel.Controls.Add(lblEstado);

                    // Evento click para la tarjeta
                    cardPanel.Click += async (s, e) => await SeleccionarCategoria(categoria.Categoria);
                    
                    panelTarjetasCategorias.Controls.Add(cardPanel);

                    // Calcular posición de la siguiente tarjeta
                    if ((i + 1) % cardsPerRow == 0)
                    {
                        x = 20;
                        y += cardHeight + 20;
                    }
                    else
                    {
                        x += cardWidth + 20;
                    }
                }

                this.Text = $"Gestión de Productos - Vista de Categorías ({estadisticasCategoria.Count} categorías)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}\n\nUsando vista alternativa...", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                // Como fallback, mostrar productos normalmente
                dgvProductos.Visible = true;
                if (panelTarjetasCategorias != null)
                    panelTarjetasCategorias.Visible = false;
                
                // Cargar productos normalmente como backup
                CargarProductos();
            }
        }

        private async Task MostrarCategoriasEnDataGrid()
        {
            try
            {
                dgvProductos.Visible = true;
                if (panelTarjetasCategorias != null)
                    panelTarjetasCategorias.Visible = false;

                // Obtener productos y calcular estadísticas en memoria
                var productos = await _context.Productos
                    .Where(p => p.Activo)
                    .ToListAsync();

                var estadisticasCategoria = productos
                    .GroupBy(p => p.Categoria)
                    .Select(g => new
                    {
                        Categoria = g.Key,
                        TotalProductos = g.Count(),
                        ProductosStockBajo = g.Count(p => p.Stock < 10),
                        ProductosStockCritico = g.Count(p => p.Stock < 5),
                        ValorTotal = g.Sum(p => (decimal)p.Stock * p.Precio),
                        StockTotal = g.Sum(p => p.Stock),
                        PrecioPromedio = g.Any() ? g.Average(p => p.Precio) : 0m
                    })
                    .OrderBy(x => x.Categoria)
                    .ToList();

                // Mostrar categorías en el DataGridView
                dgvProductos.DataSource = estadisticasCategoria.Select(c => new
                {
                    Id = 0,
                    Código = $"CAT-{c.Categoria.Substring(0, Math.Min(3, c.Categoria.Length)).ToUpper()}",
                    Nombre = $"📁 {c.Categoria}",
                    Descripción = $"{c.TotalProductos} productos disponibles",
                    Precio = c.PrecioPromedio.ToString("C"),
                    Stock = c.StockTotal,
                    Categoría = c.Categoria,
                    ValorStock = c.ValorTotal.ToString("C"),
                    FechaCreación = "Categoría",
                    EstadoStock = c.ProductosStockCritico > 0 ? "CRÍTICO" : 
                                 c.ProductosStockBajo > 0 ? "ATENCIÓN" : "NORMAL"
                }).ToList();

                // Ocultar columna ID
                if (dgvProductos.Columns.Contains("Id"))
                    dgvProductos.Columns["Id"].Visible = false;

                // Colorear filas según alertas de stock
                ColorearFilasCategorias();

                this.Text = $"Gestión de Productos - Vista de Categorías ({estadisticasCategoria.Count} categorías)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías en DataGrid: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarBotonesControl()
        {
            // Limpiar botones existentes si los hay
            var botonesExistentes = panelTarjetasCategorias.Controls.OfType<Button>().ToList();
            foreach (var btn in botonesExistentes)
            {
                panelTarjetasCategorias.Controls.Remove(btn);
            }

            // Botón "Nueva Categoría"
            var btnNuevaCategoria = new Button
            {
                Text = "➕ NUEVA CATEGORÍA",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(150, 35),
                Location = new Point(10, 10),
                Cursor = Cursors.Hand
            };
            btnNuevaCategoria.Click += btnNuevaCategoria_Click;

            // Botón "Stock Bajo"  
            var btnStockBajo = new Button
            {
                Text = "⚠️ STOCK BAJO",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 35),
                Location = new Point(170, 10),
                Cursor = Cursors.Hand
            };
            btnStockBajo.Click += btnStockBajo_Click;

            // Botón "Volver" (solo visible cuando estemos en vista de productos específicos)
            var btnVolver = new Button
            {
                Text = "⬅️ VOLVER",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 35),
                Location = new Point(panelTarjetasCategorias.Width - 120, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand,
                Visible = !string.IsNullOrEmpty(_categoriaSeleccionada) || _mostrarStockBajo
            };
            btnVolver.Click += btnVolverCategorias_Click;

            // Agregar botones al panel
            panelTarjetasCategorias.Controls.Add(btnNuevaCategoria);
            panelTarjetasCategorias.Controls.Add(btnStockBajo);
            panelTarjetasCategorias.Controls.Add(btnVolver);
        }

        private Panel? panelVistaCards;

        private async Task MostrarPanelCategorias()
        {
            try
            {
                // Obtener productos y calcular estadísticas en memoria
                var productos = await _context.Productos
                    .Where(p => p.Activo)
                    .ToListAsync();

                var estadisticasCategoria = productos
                    .GroupBy(p => p.Categoria)
                    .Select(g => new
                    {
                        Categoria = g.Key,
                        TotalProductos = g.Count(),
                        ProductosStockBajo = g.Count(p => p.Stock < 10),
                        ProductosStockCritico = g.Count(p => p.Stock < 5),
                        ValorTotal = g.Sum(p => (decimal)p.Stock * p.Precio),
                        StockTotal = g.Sum(p => p.Stock),
                        PrecioPromedio = g.Any() ? g.Average(p => p.Precio) : 0m
                    })
                    .OrderBy(x => x.Categoria)
                    .ToList();

                // Crear panel de cards si no existe
                if (panelVistaCards == null)
                {
                    panelVistaCards = new Panel
                    {
                        Dock = DockStyle.Fill,
                        AutoScroll = true,
                        BackColor = Color.FromArgb(245, 245, 245),
                        Padding = new Padding(20)
                    };
                    this.Controls.Add(panelVistaCards);
                    panelVistaCards.BringToFront();
                }
                else
                {
                    panelVistaCards.Controls.Clear();
                }

                panelVistaCards.Visible = true;

                // Crear cards de categorías
                int x = 30, y = 30, cardWidth = 280, cardHeight = 180;
                int cardsPerRow = (panelVistaCards.Width - 60) / (cardWidth + 20);
                if (cardsPerRow < 1) cardsPerRow = 1;

                // Card para Nueva Categoría
                var cardNuevaCategoria = CrearCardNuevaCategoria();
                cardNuevaCategoria.Location = new Point(x, y);
                cardNuevaCategoria.Size = new Size(cardWidth, cardHeight);
                panelVistaCards.Controls.Add(cardNuevaCategoria);

                // Actualizar posición para siguientes cards
                x += cardWidth + 20;
                if (x + cardWidth > panelVistaCards.Width - 40)
                {
                    x = 30;
                    y += cardHeight + 20;
                }

                // Cards de categorías existentes
                foreach (var categoria in estadisticasCategoria)
                {
                    var card = CrearCardCategoria(categoria.Categoria, categoria.TotalProductos, 
                                                categoria.ValorTotal, categoria.ProductosStockBajo, 
                                                categoria.ProductosStockCritico);
                    card.Location = new Point(x, y);
                    card.Size = new Size(cardWidth, cardHeight);
                    panelVistaCards.Controls.Add(card);

                    x += cardWidth + 20;
                    if (x + cardWidth > panelVistaCards.Width - 40)
                    {
                        x = 30;
                        y += cardHeight + 20;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creando panel de categorías: {ex.Message}");
            }
        }

        private Panel CrearCardNuevaCategoria()
        {
            var card = new Panel
            {
                BackColor = Color.FromArgb(46, 204, 113),
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand
            };

            // Agregar sombra simulada
            card.Paint += (s, e) =>
            {
                var rect = new Rectangle(0, 0, card.Width, card.Height);
                using (var brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(brush, rect.X + 3, rect.Y + 3, rect.Width, rect.Height);
                }
                using (var brush = new SolidBrush(card.BackColor))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };

            var lblIcono = new Label
            {
                Text = "➕",
                Font = new Font("Segoe UI", 36F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 40),
                Size = new Size(280, 60),
                BackColor = Color.Transparent
            };

            var lblTexto = new Label
            {
                Text = "NUEVA CATEGORÍA",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 110),
                Size = new Size(280, 25),
                BackColor = Color.Transparent
            };

            var lblDescripcion = new Label
            {
                Text = "Clic para crear una nueva categoría",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(240, 255, 240),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 135),
                Size = new Size(280, 20),
                BackColor = Color.Transparent
            };

            card.Controls.AddRange(new Control[] { lblIcono, lblTexto, lblDescripcion });

            // Evento click
            card.Click += async (s, e) => await MostrarDialogoNuevaCategoria();
            lblIcono.Click += async (s, e) => await MostrarDialogoNuevaCategoria();
            lblTexto.Click += async (s, e) => await MostrarDialogoNuevaCategoria();
            lblDescripcion.Click += async (s, e) => await MostrarDialogoNuevaCategoria();

            // Efectos hover
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(39, 174, 96);
            card.MouseLeave += (s, e) => card.BackColor = Color.FromArgb(46, 204, 113);

            return card;
        }

        private Panel CrearCardCategoria(string categoria, int totalProductos, decimal valorTotal, 
                                       int stockBajo, int stockCritico)
        {
            Color colorCard = stockCritico > 0 ? Color.FromArgb(231, 76, 60) : 
                             stockBajo > 0 ? Color.FromArgb(243, 156, 18) : 
                             Color.FromArgb(52, 152, 219);

            var card = new Panel
            {
                BackColor = colorCard,
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand,
                Tag = categoria
            };

            // Agregar sombra simulada
            card.Paint += (s, e) =>
            {
                var rect = new Rectangle(0, 0, card.Width, card.Height);
                using (var brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(brush, rect.X + 3, rect.Y + 3, rect.Width, rect.Height);
                }
                using (var brush = new SolidBrush(card.BackColor))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };

            string icono = categoria.ToLower() switch
            {
                var cat when cat.Contains("accesorio") => "🎧",
                var cat when cat.Contains("computadora") => "💻",
                var cat when cat.Contains("software") => "💿",
                var cat when cat.Contains("periferico") => "🖱️",
                var cat when cat.Contains("componente") => "🔧",
                _ => "📦"
            };

            var lblIcono = new Label
            {
                Text = icono,
                Font = new Font("Segoe UI", 24F),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 15),
                Size = new Size(50, 40),
                BackColor = Color.Transparent
            };

            var lblCategoria = new Label
            {
                Text = categoria.ToUpper(),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.TopLeft,
                Location = new Point(70, 15),
                Size = new Size(200, 25),
                BackColor = Color.Transparent
            };

            var lblProductos = new Label
            {
                Text = $"📦 {totalProductos} productos",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(240, 248, 255),
                Location = new Point(15, 65),
                Size = new Size(250, 20),
                BackColor = Color.Transparent
            };

            var lblValor = new Label
            {
                Text = $"💰 {valorTotal:C}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(240, 248, 255),
                Location = new Point(15, 85),
                Size = new Size(250, 20),
                BackColor = Color.Transparent
            };

            var lblEstado = new Label
            {
                Text = stockCritico > 0 ? $"🚨 {stockCritico} críticos" :
                       stockBajo > 0 ? $"⚠️ {stockBajo} stock bajo" : "✅ Stock normal",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 110),
                Size = new Size(250, 20),
                BackColor = Color.Transparent
            };

            var lblAccion = new Label
            {
                Text = "Clic para ver productos →",
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.FromArgb(220, 220, 220),
                Location = new Point(15, 145),
                Size = new Size(250, 15),
                BackColor = Color.Transparent
            };

            card.Controls.AddRange(new Control[] { lblIcono, lblCategoria, lblProductos, lblValor, lblEstado, lblAccion });

            // Evento click para mostrar productos de la categoría
            EventHandler clickHandler = async (s, e) =>
            {
                _categoriaSeleccionada = categoria;
                _mostrarStockBajo = false;
                ActualizarBotonCategorias();
                await CargarCategoriasDinamicas();
                
                // Ocultar vista cards y mostrar productos
                if (panelVistaCards != null)
                    panelVistaCards.Visible = false;
                dgvProductos.Visible = true;
                
                await CargarProductosFiltrados(txtBuscar.Text, ObtenerOrdenamiento(), _categoriaSeleccionada, false);
            };

            card.Click += clickHandler;
            foreach (Control control in card.Controls)
            {
                control.Click += clickHandler;
            }

            // Efectos hover
            Color originalColor = colorCard;
            Color hoverColor = Color.FromArgb(Math.Max(0, originalColor.R - 20),
                                            Math.Max(0, originalColor.G - 20),
                                            Math.Max(0, originalColor.B - 20));

            card.MouseEnter += (s, e) => card.BackColor = hoverColor;
            card.MouseLeave += (s, e) => card.BackColor = originalColor;

            return card;
        }

        private void ColorearFilasCategorias()
        {
            try
            {
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (row.Cells["EstadoStock"].Value != null)
                    {
                        string estadoStock = row.Cells["EstadoStock"].Value?.ToString() ?? "NORMAL";
                        
                        switch (estadoStock)
                        {
                            case "CRÍTICO":
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210);
                                row.DefaultCellStyle.ForeColor = Color.FromArgb(183, 28, 28);
                                break;
                            case "ATENCIÓN":
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 181);
                                row.DefaultCellStyle.ForeColor = Color.FromArgb(251, 140, 0);
                                break;
                            default:
                                row.DefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
                                row.DefaultCellStyle.ForeColor = Color.FromArgb(46, 125, 50);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error coloreando filas de categorías: {ex.Message}");
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosed(e);
        }
    }
}