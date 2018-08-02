<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.lblcontraseña = New System.Windows.Forms.Label
        Me.lblusuario = New System.Windows.Forms.Label
        Me.btncancelar = New System.Windows.Forms.Button
        Me.btnIngresar = New System.Windows.Forms.Button
        Me.txtcontraseña = New System.Windows.Forms.TextBox
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.AxGrFingerXCtrl1 = New AxGrFingerXLib.AxGrFingerXCtrl
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.cmbEmpresas = New System.Windows.Forms.ComboBox
        Me.lblEmpresa = New System.Windows.Forms.Label
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblcontraseña
        '
        Me.lblcontraseña.Location = New System.Drawing.Point(12, 42)
        Me.lblcontraseña.Name = "lblcontraseña"
        Me.lblcontraseña.Size = New System.Drawing.Size(89, 13)
        Me.lblcontraseña.TabIndex = 48
        Me.lblcontraseña.Text = "Contraseña:"
        Me.lblcontraseña.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblusuario
        '
        Me.lblusuario.Location = New System.Drawing.Point(30, 19)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(71, 13)
        Me.lblusuario.TabIndex = 47
        Me.lblusuario.Text = "Usuario:"
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btncancelar
        '
        Me.btncancelar.Location = New System.Drawing.Point(140, 95)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(103, 28)
        Me.btncancelar.TabIndex = 5
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnIngresar
        '
        Me.btnIngresar.Location = New System.Drawing.Point(15, 95)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(103, 28)
        Me.btnIngresar.TabIndex = 4
        Me.btnIngresar.Text = "Ingresar"
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'txtcontraseña
        '
        Me.txtcontraseña.BackColor = System.Drawing.Color.AliceBlue
        Me.txtcontraseña.Location = New System.Drawing.Point(107, 42)
        Me.txtcontraseña.MaxLength = 15
        Me.txtcontraseña.Name = "txtcontraseña"
        Me.txtcontraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtcontraseña.Size = New System.Drawing.Size(126, 20)
        Me.txtcontraseña.TabIndex = 1
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtUsuario.Location = New System.Drawing.Point(107, 16)
        Me.txtUsuario.MaxLength = 30
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(126, 20)
        Me.txtUsuario.TabIndex = 0
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(12, 4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(38, 17)
        Me.ListBox1.TabIndex = 67
        Me.ListBox1.Visible = False
        '
        'AxGrFingerXCtrl1
        '
        Me.AxGrFingerXCtrl1.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.AxGrFingerXCtrl1.Enabled = True
        Me.AxGrFingerXCtrl1.Location = New System.Drawing.Point(3, 0)
        Me.AxGrFingerXCtrl1.Name = "AxGrFingerXCtrl1"
        Me.AxGrFingerXCtrl1.OcxState = CType(resources.GetObject("AxGrFingerXCtrl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxGrFingerXCtrl1.Size = New System.Drawing.Size(32, 32)
        Me.AxGrFingerXCtrl1.TabIndex = 66
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox2.Location = New System.Drawing.Point(92, 134)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(84, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 65
        Me.PictureBox2.TabStop = False
        '
        'cmbEmpresas
        '
        Me.cmbEmpresas.BackColor = System.Drawing.Color.AliceBlue
        Me.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresas.FormattingEnabled = True
        Me.cmbEmpresas.Location = New System.Drawing.Point(107, 68)
        Me.cmbEmpresas.Name = "cmbEmpresas"
        Me.cmbEmpresas.Size = New System.Drawing.Size(126, 21)
        Me.cmbEmpresas.TabIndex = 2
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Location = New System.Drawing.Point(25, 68)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(76, 13)
        Me.lblEmpresa.TabIndex = 69
        Me.lblEmpresa.Text = "Empresa:"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(253, 194)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.cmbEmpresas)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.AxGrFingerXCtrl1)
        Me.Controls.Add(Me.lblcontraseña)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.txtcontraseña)
        Me.Controls.Add(Me.txtUsuario)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acceso"
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblcontraseña As System.Windows.Forms.Label
    Friend WithEvents lblusuario As System.Windows.Forms.Label
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents txtcontraseña As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents AxGrFingerXCtrl1 As AxGrFingerXLib.AxGrFingerXCtrl
    Private WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents cmbEmpresas As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
End Class
