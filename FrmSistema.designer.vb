<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSistema
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSistema))
        Me.LblSeguridad = New System.Windows.Forms.Label()
        Me.Salida_imagen2 = New System.Windows.Forms.PictureBox()
        Me.Salida_imagen3 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblFactor = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblArrendamiento = New System.Windows.Forms.Label()
        Me.lblTesoreria = New System.Windows.Forms.Label()
        Me.LblCredito = New System.Windows.Forms.Label()
        Me.LblCatalogos = New System.Windows.Forms.Label()
        Me.LblPromocion = New System.Windows.Forms.Label()
        Me.LblRiesgo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Salida_imagen2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Salida_imagen3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblSeguridad
        '
        Me.LblSeguridad.AutoSize = True
        Me.LblSeguridad.BackColor = System.Drawing.Color.Transparent
        Me.LblSeguridad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblSeguridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.LblSeguridad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblSeguridad.Location = New System.Drawing.Point(12, 465)
        Me.LblSeguridad.Name = "LblSeguridad"
        Me.LblSeguridad.Size = New System.Drawing.Size(81, 25)
        Me.LblSeguridad.TabIndex = 7
        Me.LblSeguridad.Text = "Control"
        '
        'Salida_imagen2
        '
        Me.Salida_imagen2.Image = CType(resources.GetObject("Salida_imagen2.Image"), System.Drawing.Image)
        Me.Salida_imagen2.Location = New System.Drawing.Point(710, 503)
        Me.Salida_imagen2.Name = "Salida_imagen2"
        Me.Salida_imagen2.Size = New System.Drawing.Size(37, 37)
        Me.Salida_imagen2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Salida_imagen2.TabIndex = 8
        Me.Salida_imagen2.TabStop = False
        Me.Salida_imagen2.Visible = False
        '
        'Salida_imagen3
        '
        Me.Salida_imagen3.Image = CType(resources.GetObject("Salida_imagen3.Image"), System.Drawing.Image)
        Me.Salida_imagen3.Location = New System.Drawing.Point(710, 503)
        Me.Salida_imagen3.Name = "Salida_imagen3"
        Me.Salida_imagen3.Size = New System.Drawing.Size(37, 37)
        Me.Salida_imagen3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Salida_imagen3.TabIndex = 11
        Me.Salida_imagen3.TabStop = False
        Me.Salida_imagen3.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300000
        '
        'lblFactor
        '
        Me.lblFactor.AutoSize = True
        Me.lblFactor.BackColor = System.Drawing.Color.Transparent
        Me.lblFactor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFactor.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.lblFactor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblFactor.Location = New System.Drawing.Point(12, 403)
        Me.lblFactor.Name = "lblFactor"
        Me.lblFactor.Size = New System.Drawing.Size(102, 25)
        Me.lblFactor.TabIndex = 7
        Me.lblFactor.Text = "Factoraje"
        Me.lblFactor.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(710, 503)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'lblArrendamiento
        '
        Me.lblArrendamiento.AutoSize = True
        Me.lblArrendamiento.BackColor = System.Drawing.Color.Transparent
        Me.lblArrendamiento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblArrendamiento.Font = New System.Drawing.Font("Cooper Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArrendamiento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblArrendamiento.Location = New System.Drawing.Point(590, 453)
        Me.lblArrendamiento.Name = "lblArrendamiento"
        Me.lblArrendamiento.Size = New System.Drawing.Size(188, 24)
        Me.lblArrendamiento.TabIndex = 7
        Me.lblArrendamiento.Text = "Arrendamiento"
        Me.lblArrendamiento.Visible = False
        '
        'lblTesoreria
        '
        Me.lblTesoreria.AutoSize = True
        Me.lblTesoreria.BackColor = System.Drawing.Color.Transparent
        Me.lblTesoreria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTesoreria.Font = New System.Drawing.Font("Cooper Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTesoreria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTesoreria.Location = New System.Drawing.Point(590, 429)
        Me.lblTesoreria.Name = "lblTesoreria"
        Me.lblTesoreria.Size = New System.Drawing.Size(120, 24)
        Me.lblTesoreria.TabIndex = 12
        Me.lblTesoreria.Text = "Tesoreria"
        Me.lblTesoreria.Visible = False
        '
        'LblCredito
        '
        Me.LblCredito.AutoSize = True
        Me.LblCredito.BackColor = System.Drawing.Color.Transparent
        Me.LblCredito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.LblCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblCredito.Location = New System.Drawing.Point(12, 434)
        Me.LblCredito.Name = "LblCredito"
        Me.LblCredito.Size = New System.Drawing.Size(113, 25)
        Me.LblCredito.TabIndex = 13
        Me.LblCredito.Text = "Financiera"
        '
        'LblCatalogos
        '
        Me.LblCatalogos.AutoSize = True
        Me.LblCatalogos.BackColor = System.Drawing.Color.Transparent
        Me.LblCatalogos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblCatalogos.Font = New System.Drawing.Font("Cooper Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCatalogos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblCatalogos.Location = New System.Drawing.Point(449, 381)
        Me.LblCatalogos.Name = "LblCatalogos"
        Me.LblCatalogos.Size = New System.Drawing.Size(123, 24)
        Me.LblCatalogos.TabIndex = 14
        Me.LblCatalogos.Text = "Catalogos"
        '
        'LblPromocion
        '
        Me.LblPromocion.AutoSize = True
        Me.LblPromocion.BackColor = System.Drawing.Color.Transparent
        Me.LblPromocion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblPromocion.Font = New System.Drawing.Font("Cooper Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPromocion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblPromocion.Location = New System.Drawing.Point(449, 405)
        Me.LblPromocion.Name = "LblPromocion"
        Me.LblPromocion.Size = New System.Drawing.Size(135, 24)
        Me.LblPromocion.TabIndex = 15
        Me.LblPromocion.Text = "Promoción"
        Me.LblPromocion.Visible = False
        '
        'LblRiesgo
        '
        Me.LblRiesgo.AutoSize = True
        Me.LblRiesgo.BackColor = System.Drawing.Color.Transparent
        Me.LblRiesgo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblRiesgo.Font = New System.Drawing.Font("Cooper Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRiesgo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblRiesgo.Location = New System.Drawing.Point(590, 405)
        Me.LblRiesgo.Name = "LblRiesgo"
        Me.LblRiesgo.Size = New System.Drawing.Size(183, 24)
        Me.LblRiesgo.TabIndex = 16
        Me.LblRiesgo.Text = "Analisis Riesgo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Cooper Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 551)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 24)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "..."
        '
        'FrmSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = Global.SistemaAcceso.My.Resources.Resources.LOGO
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(802, 584)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblRiesgo)
        Me.Controls.Add(Me.LblPromocion)
        Me.Controls.Add(Me.LblCatalogos)
        Me.Controls.Add(Me.LblCredito)
        Me.Controls.Add(Me.lblTesoreria)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Salida_imagen3)
        Me.Controls.Add(Me.lblArrendamiento)
        Me.Controls.Add(Me.lblFactor)
        Me.Controls.Add(Me.Salida_imagen2)
        Me.Controls.Add(Me.LblSeguridad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSistema"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema"
        CType(Me.Salida_imagen2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Salida_imagen3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblSeguridad As System.Windows.Forms.Label
    Friend WithEvents Salida_imagen2 As System.Windows.Forms.PictureBox
    Friend WithEvents Salida_imagen3 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblFactor As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblArrendamiento As System.Windows.Forms.Label
    Friend WithEvents lblTesoreria As System.Windows.Forms.Label
    Friend WithEvents LblCredito As System.Windows.Forms.Label
    Friend WithEvents LblCatalogos As System.Windows.Forms.Label
    Friend WithEvents LblPromocion As System.Windows.Forms.Label
    Friend WithEvents LblRiesgo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
