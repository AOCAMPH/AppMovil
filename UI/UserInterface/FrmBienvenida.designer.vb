<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBienvenida
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBienvenida))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.InicioToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MantenerClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConsultarClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.MantenerProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConsultarProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OrdenesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConsultarOrdenesPorFechasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MantenerOrdenesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InicioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.OrdenCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InicioToolStripMenuItem1, Me.ClienteToolStripMenuItem, Me.ProductoToolStripMenuItem1, Me.OrdenesToolStripMenuItem, Me.SalirToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(393, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'InicioToolStripMenuItem1
        '
        Me.InicioToolStripMenuItem1.Image = CType(resources.GetObject("InicioToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.InicioToolStripMenuItem1.Name = "InicioToolStripMenuItem1"
        Me.InicioToolStripMenuItem1.Size = New System.Drawing.Size(64, 20)
        Me.InicioToolStripMenuItem1.Text = "Inicio"
        '
        'ClienteToolStripMenuItem
        '
        Me.ClienteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MantenerClienteToolStripMenuItem, Me.ConsultarClienteToolStripMenuItem})
        Me.ClienteToolStripMenuItem.Image = Global.UserInterface.My.Resources.Resources.Icono_usuario
        Me.ClienteToolStripMenuItem.Name = "ClienteToolStripMenuItem"
        Me.ClienteToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.ClienteToolStripMenuItem.Text = "Cliente"
        '
        'MantenerClienteToolStripMenuItem
        '
        Me.MantenerClienteToolStripMenuItem.Name = "MantenerClienteToolStripMenuItem"
        Me.MantenerClienteToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.MantenerClienteToolStripMenuItem.Text = "Mantener Cliente"
        '
        'ConsultarClienteToolStripMenuItem
        '
        Me.ConsultarClienteToolStripMenuItem.Name = "ConsultarClienteToolStripMenuItem"
        Me.ConsultarClienteToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ConsultarClienteToolStripMenuItem.Text = "Consultar Cliente"
        '
        'ProductoToolStripMenuItem1
        '
        Me.ProductoToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MantenerProductoToolStripMenuItem, Me.ConsultarProductoToolStripMenuItem})
        Me.ProductoToolStripMenuItem1.Image = Global.UserInterface.My.Resources.Resources.Productos
        Me.ProductoToolStripMenuItem1.Name = "ProductoToolStripMenuItem1"
        Me.ProductoToolStripMenuItem1.Size = New System.Drawing.Size(84, 20)
        Me.ProductoToolStripMenuItem1.Text = "Producto"
        '
        'MantenerProductoToolStripMenuItem
        '
        Me.MantenerProductoToolStripMenuItem.Name = "MantenerProductoToolStripMenuItem"
        Me.MantenerProductoToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.MantenerProductoToolStripMenuItem.Text = "Mantener Producto"
        '
        'ConsultarProductoToolStripMenuItem
        '
        Me.ConsultarProductoToolStripMenuItem.Name = "ConsultarProductoToolStripMenuItem"
        Me.ConsultarProductoToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ConsultarProductoToolStripMenuItem.Text = "Consultar Producto"
        '
        'OrdenesToolStripMenuItem
        '
        Me.OrdenesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConsultarOrdenesPorFechasToolStripMenuItem, Me.MantenerOrdenesToolStripMenuItem})
        Me.OrdenesToolStripMenuItem.Image = Global.UserInterface.My.Resources.Resources.images3
        Me.OrdenesToolStripMenuItem.Name = "OrdenesToolStripMenuItem"
        Me.OrdenesToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.OrdenesToolStripMenuItem.Text = "Ordenes"
        '
        'ConsultarOrdenesPorFechasToolStripMenuItem
        '
        Me.ConsultarOrdenesPorFechasToolStripMenuItem.Name = "ConsultarOrdenesPorFechasToolStripMenuItem"
        Me.ConsultarOrdenesPorFechasToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ConsultarOrdenesPorFechasToolStripMenuItem.Text = "Consultar Ordenes Por Fechas"
        '
        'MantenerOrdenesToolStripMenuItem
        '
        Me.MantenerOrdenesToolStripMenuItem.Name = "MantenerOrdenesToolStripMenuItem"
        Me.MantenerOrdenesToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.MantenerOrdenesToolStripMenuItem.Text = "Mantener Ordenes"
        '
        'SalirToolStripMenuItem1
        '
        Me.SalirToolStripMenuItem1.Image = Global.UserInterface.My.Resources.Resources.images2
        Me.SalirToolStripMenuItem1.Name = "SalirToolStripMenuItem1"
        Me.SalirToolStripMenuItem1.Size = New System.Drawing.Size(57, 20)
        Me.SalirToolStripMenuItem1.Text = "Salir"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(300, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(190, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Usuario Conectado: "
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Image = CType(resources.GetObject("ClientesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'InicioToolStripMenuItem
        '
        Me.InicioToolStripMenuItem.Image = CType(resources.GetObject("InicioToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InicioToolStripMenuItem.Name = "InicioToolStripMenuItem"
        Me.InicioToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.InicioToolStripMenuItem.Text = "Inicio"
        '
        'ProductoToolStripMenuItem
        '
        Me.ProductoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1})
        Me.ProductoToolStripMenuItem.Image = CType(resources.GetObject("ProductoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProductoToolStripMenuItem.Name = "ProductoToolStripMenuItem"
        Me.ProductoToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.ProductoToolStripMenuItem.Text = "Producto"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(57, 6)
        '
        'OrdenCompraToolStripMenuItem
        '
        Me.OrdenCompraToolStripMenuItem.Image = CType(resources.GetObject("OrdenCompraToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OrdenCompraToolStripMenuItem.Name = "OrdenCompraToolStripMenuItem"
        Me.OrdenCompraToolStripMenuItem.Size = New System.Drawing.Size(114, 20)
        Me.OrdenCompraToolStripMenuItem.Text = "Orden Compra"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'FrmBienvenida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(393, 52)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBienvenida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmInicio"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InicioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdenCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents InicioToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdenesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ConsultarOrdenesPorFechasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenerOrdenesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenerClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenerProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
