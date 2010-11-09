Namespace _template
    Public Class baseballform
        Inherits repsol.forms.template.BaseForm


        Public Sub New()
            InitializeComponent()
        End Sub


        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(baseballform))
            Me.SuspendLayout()
            '
            'baseballform
            '
            Me.ClientSize = New System.Drawing.Size(292, 273)
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "baseballform"
            Me.ShowIcon = False
            Me.ResumeLayout(False)

        End Sub


    End Class
End Namespace

