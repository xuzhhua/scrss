<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimer
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnSet = New System.Windows.Forms.Button()
        Me.txtTimer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbAutoRun = New System.Windows.Forms.CheckBox()
        Me.cbAutoHide = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnSet
        '
        Me.btnSet.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSet.Location = New System.Drawing.Point(124, 10)
        Me.btnSet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(87, 29)
        Me.btnSet.TabIndex = 0
        Me.btnSet.Text = "設定"
        Me.btnSet.UseVisualStyleBackColor = True
        '
        'txtTimer
        '
        Me.txtTimer.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTimer.Location = New System.Drawing.Point(14, 12)
        Me.txtTimer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTimer.MaxLength = 2
        Me.txtTimer.Name = "txtTimer"
        Me.txtTimer.Size = New System.Drawing.Size(63, 23)
        Me.txtTimer.TabIndex = 1
        Me.txtTimer.Text = "3"
        Me.txtTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(84, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "分"
        '
        'cbAutoRun
        '
        Me.cbAutoRun.AutoSize = True
        Me.cbAutoRun.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cbAutoRun.Location = New System.Drawing.Point(13, 54)
        Me.cbAutoRun.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbAutoRun.Name = "cbAutoRun"
        Me.cbAutoRun.Size = New System.Drawing.Size(159, 19)
        Me.cbAutoRun.TabIndex = 3
        Me.cbAutoRun.Text = "Auto run with windows"
        Me.cbAutoRun.UseVisualStyleBackColor = True
        '
        'cbAutoHide
        '
        Me.cbAutoHide.AutoSize = True
        Me.cbAutoHide.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cbAutoHide.Location = New System.Drawing.Point(14, 82)
        Me.cbAutoHide.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbAutoHide.Name = "cbAutoHide"
        Me.cbAutoHide.Size = New System.Drawing.Size(81, 19)
        Me.cbAutoHide.TabIndex = 4
        Me.cbAutoHide.Text = "Auto hide"
        Me.cbAutoHide.UseVisualStyleBackColor = True
        '
        'frmTimer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(223, 106)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbAutoHide)
        Me.Controls.Add(Me.cbAutoRun)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTimer)
        Me.Controls.Add(Me.btnSet)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmTimer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "タイマー設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSet As System.Windows.Forms.Button
    Friend WithEvents txtTimer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbAutoRun As System.Windows.Forms.CheckBox
    Friend WithEvents cbAutoHide As System.Windows.Forms.CheckBox
End Class
